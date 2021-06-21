using cwiczenia_5.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_5.Services
{
    public interface IWarehouseService{
         public IEnumerable<Order> GetOrders();
    public IEnumerable<Order> CreateOrder(Order order);
}
public class WarehouseService : IWarehouseService
        
    {
      /*  public IEnumerable<Order> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }*/

        private const string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17297;Integrated Security=True";

        public IEnumerable<Order> CreateOrder(Order order)
        {
            var tempid = 1;
            //Tworzenie połączenia i transakcji
            using SqlConnection cn = new SqlConnection(connectionString);
            using SqlCommand cm = new SqlCommand("select count(1) from product where idproduct = @idproduct", cn);
            cm.Parameters.AddWithValue("idproduct", order.IdProduct);
            cn.Open();
            DbTransaction tran = cn.BeginTransaction();
            cm.Transaction = (SqlTransaction)tran;
            try
            {
                var czyIstniejeProdukt = (int)cm.ExecuteScalar();
                if (czyIstniejeProdukt != 1)
                {
                    tran.Rollback();
                    return null;
                   //400
                }
                cm.Parameters.Clear();
                cm.CommandText = ("select count(1) from warehouse where idwarehouse = @idwarehouse");
                cm.Parameters.AddWithValue("idwarehouse", order.IdWarehouse);
                var czyIstniejeMagazyn = (int)cm.ExecuteScalar();
                if (czyIstniejeMagazyn != 1)
                {
                    tran.Rollback();
                    return null;
                    //400
                }
                cm.Parameters.Clear();
                cm.CommandText = ("select count(1) from \"order\" where idproduct = @idproduct and amount = @amount");
                cm.Parameters.AddWithValue("idproduct", order.IdProduct);
                cm.Parameters.AddWithValue("amount", order.Amount);
                var czyIstniejeZamowienie = (int)cm.ExecuteScalar();
                if (czyIstniejeZamowienie != 1)
                {
                    tran.Rollback();
                    return null;
                    //400
                }
                cm.Parameters.Clear();
                cm.CommandText = ("select count(1) from product_warehouse where idorder = @idorder");
                cm.Parameters.AddWithValue("idorder", order.IdProduct);
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                var czyZrealizowaneZamowienie = (int)cm.ExecuteScalar();
                if (czyZrealizowaneZamowienie != 0)
                {
                    tran.Rollback();
                    return null;
                    //400
                }
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("amount", order.Amount);
                cm.Parameters.AddWithValue("idproduct", order.IdProduct);
                cm.Parameters.AddWithValue("dataTeraz", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                cm.CommandText = ("update \"order\" set fulfilledat = (select getdate()) where amount = @amount and idproduct = @idproduct ");
                cm.ExecuteNonQuery();

                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("amount", order.Amount);
                cm.Parameters.AddWithValue("idproduct", order.IdProduct);
                cm.Parameters.AddWithValue("idwarehouse", order.IdWarehouse);
                cm.CommandText = ("set identity_insert product_warehouse on " +
                    "insert into Product_Warehouse(IdProductWarehouse, IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                    "values(((select max(idproductwarehouse) from Product_Warehouse) + 1)," +
                    " @idwarehouse, " +
                    "@idproduct," +
                    "(select idorder from \"order\" where amount = @amount and idproduct = @idproduct), " +
                    "@amount," +
                    "(select price from product where IdProduct = @idproduct)*@amount, " +
                    "(select getdate())) " +
                    "set identity_insert product_warehouse off");
                cm.ExecuteNonQuery();


                cm.Parameters.Clear();
                cm.CommandText = ("select max(idproductwarehouse) from product_warehouse");
                var idProductWarehouse = (int)cm.ExecuteScalar();
            }
            catch (SqlException)
            {
                tran.Rollback();
                throw new Exception();
                Console.WriteLine("blad w zapytaniu sql");
            }

/*            throw new Exception("sdfa");
*/            return null;
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}

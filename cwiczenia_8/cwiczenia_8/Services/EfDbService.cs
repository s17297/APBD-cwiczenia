using cwiczenia_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8.Models
{
    public class EfDbService : IDbService
    {
        public DoctorDbContext _context { get; set; }
        public EfDbService(DoctorDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetDoctors()
        {
            var list = _context.Doctors.ToList();
            return list;
        }

        public bool AddDoctor(Doctor d)
        {
            try
            {
                _context.Add(d);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ModifyDoctor(Doctor d)
        {
            try
            {
                _context.Attach(d);
                _context.Entry(d).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteDoctor(Doctor d)
        {
            try
            {
                _context.Attach(d);
                _context.Remove(d);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

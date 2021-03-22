using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using cwiczenia_2.Models;

namespace cwiczenia_2
{
    class Program
    {
        public static void ErrorLogging(Exception ex)
        {
            string logpath = @"C:\Users\macius\Log.txt";
            if (!File.Exists(logpath))
            {
                File.Create(logpath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(logpath))
            {
                sw.WriteLine("Error logging");
                sw.WriteLine("Start" + DateTime.Now);
                sw.WriteLine("Error message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("End" + DateTime.Now);
            }
        }

        public static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            try
            {
                string csvpath = @"C:\Users\Macius\APBD-cwiczenia\cwiczenia_2\cwiczenia_2\Data\dane.csv"; // @C:\Users\maksk\Desktop\Dane.csv
                string jsonpath = @"C:\Users\macius\"; // @C:\Users\maksk\Desktop\
                //string json = Console.ReadLine(); // @C:\Users\maksk\Desktop
                string format = "json"; // xml && json

                if(format=="json" && File.Exists(csvpath) && Directory.Exists(jsonpath))
                {
                    string[] source = File.ReadAllLines(csvpath);
                    foreach(string x in source)
                    {
                        string[] str = x.Split(",");
                        Student tmp = new Student
                        {
                            Name = str[0].ToString(),
                            LastName = str[1].ToString(),
                            Index_number = "s" + str[4].ToString(),
                            BirthDate = str[5].ToString(),
                            Email = str[6].ToString(),

                            MothersName = str[7].ToString(),
                            FathersName = str[8].ToString(),
                            Studies = new Studies { Course = str[2].ToString(), Mode = str[3].ToString() }
                        };
                        studentsList.Add(tmp);
                        
                    };
                    Uczelnia uczelnia = new Uczelnia
                    {
                        CreatedAt = DateTime.Now.ToString(),
                        Author = "Maciej Niedzinski",
                        Students = studentsList
                    };
                    string jsonText = JsonSerializer.Serialize(uczelnia);
                    File.WriteAllText(jsonpath + "jsonOut.json", jsonText);
                }
                else
                {
                    if (format !="json")
                    {
                        throw new Exception("unsupported format");
                    }else if (!File.Exists(csvpath))
                    {
                        throw new Exception("File does not exist");
                    }else if (!Directory.Exists(jsonpath))
                    {
                        throw new Exception("Such directory does not exist");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }
        }
    }
}

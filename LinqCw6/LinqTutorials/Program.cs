using LinqTutorials.Models;
using System;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = LinqTasks.Task14();
            //Console.WriteLine(t.ToString());
            foreach(Dept x in t)
            {
                Console.WriteLine(x.Dname);
            }

        }
    }
}

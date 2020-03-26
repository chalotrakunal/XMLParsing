using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC
{
    class Practice
    {
        private string name = "FirstName, LastName";
        private double salary = 100.0;

        public string GetName()
        {
            return name;
        }

        public double Salary
        {
            get { return salary; }
        }
    }
    class PrivateTest
    {
        static void Main()
        {
            var e = new Practice();

            // The data members are inaccessible (private), so
            // they can't be accessed like this:
              //  string n = e.name;
            //   double s = e.salary;

            // 'name' is indirectly accessed via method:
            string n = e.GetName();

            // 'salary' is indirectly accessed via property
            double s = e.Salary;
            Console.WriteLine(n);
            Console.WriteLine(s);
        }
    }
}
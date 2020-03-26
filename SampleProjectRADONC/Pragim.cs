using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC.Pragim
{
    public class Pragim
    {
        public string _name, _place;

        public Pragim()
        {
            Console.WriteLine("default constructor ");
        }
        public Pragim(string myname, string location)
        {
            _name = myname;
            _place = location;
           
        }
        public void GetDetails()
        {
            Console.WriteLine(_name+" "+_place);
        }
        
    }
        class Program
        {
            static void Main(string[] args)
            {
            Pragim detail = new Pragim("kunal", "india");
            detail.GetDetails();
            Pragim default1 = new Pragim();
            

            
            Console.ReadLine();
            }

        }
    
}

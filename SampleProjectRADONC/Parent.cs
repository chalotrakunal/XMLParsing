using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectRADONC.Parent
{
    public class Parent
    {
        public Parent()
        {
            Console.WriteLine("ParentClass Constructor");
        }
        public Parent(string Message)
        {
            Console.WriteLine(Message);
        }
    }

    public class Child:Parent
    {
        public Child() : base("kjfskhfdskj")
        {
            Console.WriteLine("childClass constructor");
        }
    }
    public class Program
    {
        public static void Main()
        {
            Parent c = new Parent("i am here");
            Parent c1 = new Parent();
            Child cc = new Child();
            
        }
    }
}

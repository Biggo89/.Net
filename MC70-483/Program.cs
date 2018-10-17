using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC70_483
{
    class Program
    {
        class Parent
        {
            internal int age = 10;
        }
        class Child : Parent
        {
            public void Dispay()
            {
                Console.WriteLine(age);
            }
        }
        static void Main(string[] args)
        {
            Parent p = new Parent();
            Console.WriteLine(p.age);
        }
    }
}

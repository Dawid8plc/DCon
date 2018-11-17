using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DConExec
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string Name;
            string Surname;

            Console.WriteLine("Welcome, type in your name and then your surname");

            Name = Console.ReadLine();
            Surname = Console.ReadLine();

            Console.WriteLine(Name + " " +  Surname);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}

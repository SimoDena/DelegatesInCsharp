using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSyntax
{
    class Program
    {
        public delegate void Delegato(string saluto);

        static void Main(string[] args)
        {
            Delegato delegato = new Delegato(Saluta);
            delegato("Ciao-Mondo!");
            Console.ReadKey();
        }

        static void Saluta(string saluto)
        {
            Console.WriteLine(saluto);
        }
    }
}

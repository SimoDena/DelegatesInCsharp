using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateInCsharp
{
    //delegate is a function pointer
    //servono per fare codice riutilizzabile
    public delegate bool IsPromuovibile(Impiegato impiegato);

    public class Impiegato
    {
        int id;
        string nome;
        int salario;
        int esperienza;

        public Impiegato(int _id, string _nome, int _salario, int _esperienza)
        {
            id = _id;
            nome = _nome;
            salario = _salario;
            esperienza = _esperienza;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int Salario
        {
            get { return salario; }
            set { salario = value; }
        }
        public int Esperienza
        {
            get { return esperienza; }
            set { esperienza = value; }
        }

        public static void PromuoviImpiegato(List<Impiegato> impLista, IsPromuovibile isPromuovibile)
        {
            foreach (Impiegato impiegato in impLista)
            {
                if (isPromuovibile(impiegato))// in questo modo il metodo PromuoviImpiegato è riutilizzabile (nel senso che è possibile promuovere per Salario, Exp ecc.)
                {
                    Console.WriteLine($"{impiegato.nome} è stato promosso!");
                } 
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Impiegato> listaImpiegati = new List<Impiegato>()
            {
                new Impiegato(1, "Aldo", 1000, 1),
                new Impiegato(2, "Giovanni", 3000, 3),
                new Impiegato(3, "Giacomo", 5000, 5),
                new Impiegato(4, "Pluto", 7000, 7),
                new Impiegato(5, "Pippo", 8000, 8),
                new Impiegato(6, "Paperino", 2000, 2)
            };

            IsPromuovibile isPromuovibile = new IsPromuovibile(PromuoviPerExp);
            Console.WriteLine("Promossi per esperienza: ");
            Impiegato.PromuoviImpiegato(listaImpiegati , isPromuovibile);

            isPromuovibile = new IsPromuovibile(PromuoviPerSalario);
            Console.WriteLine("\nPromossi per salario: ");
            Impiegato.PromuoviImpiegato(listaImpiegati, isPromuovibile);

            //Versione ridotta del codice sopra:
            Console.WriteLine("\nPromosso per esperienza(versione ridotta) :");
            Impiegato.PromuoviImpiegato(listaImpiegati, imp => imp.Esperienza >= 5);

            Console.WriteLine("\nPromosso per salario(versione ridotta) :");
            Impiegato.PromuoviImpiegato(listaImpiegati, imp => imp.Salario >= 1000);

            Console.ReadKey();
        }

        static bool PromuoviPerExp(Impiegato impiegato)
        {
            if (impiegato.Esperienza >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool PromuoviPerSalario(Impiegato impiegato)
        {
            if (impiegato.Salario >= 1000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

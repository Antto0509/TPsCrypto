using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbPremier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCRIBLE ERATOSTHENE :\n");
            Console.WriteLine(Premier.CribleEratosthene(150));
            Console.WriteLine("\nNOMBRE PREMIERS ENTRE EUX :\n");
            Console.WriteLine(Premier.nbPremierEntreEux(2, 6));
            Console.WriteLine("\nDFP :\n");
            Console.WriteLine(Premier.DFP(50));
            Console.WriteLine("\nINDICATEUR EULER :\n");
            Console.WriteLine(Premier.IndicateurEuler(50));
            Console.WriteLine("\nPUISSANCE MODULO :\n");
            Console.WriteLine(Premier.PuissanceModulo(4, 13, 497));
        }
			
    }
}

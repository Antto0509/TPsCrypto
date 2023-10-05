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
            Console.WriteLine(Premier.CribleEratosthene(150));
            Console.WriteLine(Premier.nbPremierEntreEux(2, 6));
            Console.WriteLine(Premier.DFP(50));
            Console.WriteLine(Premier.IndicateurEuler(50));
            Console.WriteLine(Premier.PuissanceModulo(4, 13, 497));
        }
			
    }
}

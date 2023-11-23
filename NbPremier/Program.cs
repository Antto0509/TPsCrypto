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
            /*
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
            */
            Console.WriteLine("\nCRIBLE ERATOSTHENE :\n");
            bool[] cribleResult = Premier.CribleEratosthene(150);
            for (int i = 2; i < cribleResult.Length; i++)
            {
                if (cribleResult[i])
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine("\n\nNOMBRE PREMIERS ENTRE EUX :\n");
            Console.WriteLine(Premier.nbPremierEntreEux(2, 6));

            Console.WriteLine("\n\nDFP :\n");
            var dfpResult = Premier.DFP(50);
            for (int i = 0; i < dfpResult.Item1.Count; i++)
            {
                Console.WriteLine($"{dfpResult.Item1[i]}^{dfpResult.Item2[i]}");
            }

            Console.WriteLine("\n\nINDICATEUR EULER :\n");
            Console.WriteLine(Premier.IndicateurEuler(50));

            Console.WriteLine("\n\nPUISSANCE MODULO :\n");
            Console.WriteLine(Premier.PuissanceModulo(4, 13, 497));

            // Test de la classe RSA
            Console.WriteLine("\nTEST DE LA CLASSE RSA :\n");
            /*
            // Jeux de test
            int p1 = 47, q1 = 71, e1 = 79;
            int p2 = 5, q2 = 17, e2 = 5;
            int p3 = 4, q3 = 11, e3 = 3; // Clé invalide
            int p4 = 3, q4 = 11, e4 = 40; // Clé invalide

            RSA rsa1 = new RSA(p1, q1, e1);
            rsa1.AfficherCleDechiffrement();

            RSA rsa2 = new RSA(p2, q2, e2);
            rsa2.AfficherCleDechiffrement();

            RSA rsa3 = new RSA(p3, q3, e3); // Ne devrait pas être créé
            RSA rsa4 = new RSA(p4, q4, e4); // Ne devrait pas être créé
            */
        }	
    }
}

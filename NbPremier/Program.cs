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
            // Test de AfficherNombresPremiersAvecCribleEratosthene
            int n2 = 30;
            Premier.AfficherNombresPremiersAvecCribleEratosthene(n2);

            // Test de nbPremierEntreEux
            int a = 15;
            int b = 28;
            bool sontPremiers = Premier.nbPremierEntreEux(a, b);

            // Test de DFP
            int n3 = 24;
            var dfpResult = Premier.DFP(n3);

            // Test d'IndicateurEuler
            int n4 = 10;
            int indicateurEulerResult = Premier.IndicateurEuler(n4);

            // Test de PuissanceModulo
            long baseValeur = 2;
            long exposant = 10;
            long modulo = 100;
            long puissanceModuloResult = Premier.PuissanceModulo(baseValeur, exposant, modulo);

            /*
            // Test de création d'une instance RSA
            int p = 61;
            int q = 53;
            int e = 17;
            RSA rsa = new RSA(p, q, e);
            
            // Test de la méthode Valid
            bool isValid = rsa.Valid(p, q);
            Console.WriteLine($"La clé de chiffrement est valide : {isValid}");

            // Test de la méthode ValidPremierEntreEux
            bool isValidPremierEntreEux = rsa.ValidPremierEntreEux(rsa.z, e);
            Console.WriteLine($"Les nombres {rsa.z} et {e} sont premiers entre eux : {isValidPremierEntreEux}");

            // Test de la méthode CalculerD
            int d = rsa.CalculerD();
            Console.WriteLine($"Clé de déchiffrement calculée : {d}");

            // Test de la méthode AfficherCleDechiffrement
            rsa.AfficherCleDechiffrement();
            */

            Console.WriteLine("Tests terminés.");
        }	
    }
}

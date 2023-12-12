using System;

namespace NbPremier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // Test de AfficherCribleEratosthene
            int n2 = 30;
            Premier.AfficherCribleEratosthene(n2);

            // Test de nbPremierEntreEux
            int a = 15;
            int b = 28;
            bool sontPremiers = Premier.nbPremierEntreEux(a, b);

            // Test de DFP
            int n3 = 24;
            var dfpResult = Premier.DFP(n3);

            // Test d'IndicateurEuler
            int phi = 10403;
            int indicateurEulerResult = Premier.IndicateurEuler(phi);

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
            

            // Test de la classe RSA
            Console.WriteLine("\nTEST DE LA CLASSE RSA :\n");

            // Jeux de test
            int p1 = 47, q1 = 71, e1 = 79;
            int p2 = 5, q2 = 17, e2 = 5;
            //int p3 = 4, q3 = 11, e3 = 3; // Clé invalide
            //int p4 = 3, q4 = 11, e4 = 40; // Clé invalide

            RSA rsa1 = new RSA(p1, q1, e1);
            rsa1.AfficherCleDechiffrement();

            RSA rsa2 = new RSA(p2, q2, e2);
            rsa2.AfficherCleDechiffrement();

            //RSA rsa3 = new RSA(p3, q3, e3); // Ne devrait pas être créé
            //RSA rsa4 = new RSA(p4, q4, e4); // Ne devrait pas être créé


            Console.WriteLine("Tests terminés.");
            */
            // Test de AfficherCribleEratosthene
            int n2 = 30;
            Premier.AfficherCribleEratosthene(n2);

            // Test de nbPremierEntreEux
            int a = 15;
            int b = 28;
            bool sontPremiers = Premier.PremierEntreEux(a, b);
            Console.WriteLine(sontPremiers);

            // Test de DFP
            int n3 = 24;
            Premier.DFP(n3);

            // Test d'IndicateurEuler
            int phi = 10403;
            Premier.IndicateurEuler(phi);

            // Test de PuissanceModulo
            long baseValeur = 5;
            long exposant = 11;
            long modulo = 14;
            Console.WriteLine($"Puissance modulaire de {baseValeur}^{exposant} mod {modulo} : {Premier.PuissanceModulo(baseValeur, exposant, modulo)}");

            // Tests de la classe RSA
            Console.WriteLine("\nTEST DE LA CLASSE RSA :\n");

            RSA rsa1 = new RSA(47, 71, 79);
            rsa1.AfficherCleChiffrement();
            rsa1.AfficherCleDechiffrement();

            RSA rsa2 = new RSA(5, 17, 5);
            rsa2.AfficherCleChiffrement();
            rsa2.AfficherCleDechiffrement();

            RSA rsa3 = new RSA(4, 11, 3); // Ne devrait pas être créé
            RSA rsa4 = new RSA(3, 11, 40); // Ne devrait pas être créé

            RSA rsa5 = new RSA(61, 53, 17);
            rsa5.AfficherCleChiffrement();
            rsa5.AfficherCleDechiffrement();

            Console.WriteLine("Tests terminés.");
            
            Console.ReadLine();
        }	
    }
}

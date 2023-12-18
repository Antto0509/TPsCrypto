using System;


namespace NbPremier
{
    internal class Program
    {
        static void Main()
        {
            // Test de AfficherCribleEratosthene
            Premier.AfficherCribleEratosthene(30);

            // Test de nbPremierEntreEux
            Console.WriteLine(Premier.PremierEntreEux(15, 28));

            // Test de DFP
            Premier.DFP(24);

            // Test d'IndicateurEuler
            Premier.IndicateurEuler(10403);

            // Test de PuissanceModulo
            Console.WriteLine($"Puissance modulaire de {5}^{11} mod {14} : {Premier.PuissanceModulo(5, 11, 14)}");

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

            // Test chiffrement et déchiffrement d'entier
            RSA rsa6 = new RSA(47, 71, 79);

            // Chiffrement du message
            Console.WriteLine($"Le message {61} est chiffré en {rsa6.ChiffrerEntier(61)}.\n");

            // Déchiffrement du message chiffré
            Console.WriteLine($"Le message déchiffré de {rsa6.ChiffrerEntier(61)} est {rsa6.DechiffrerEntier(rsa6.ChiffrerEntier(61))}.\n");

            // Chiffrement du message
            Console.WriteLine($"Le message {215} est chiffré en {rsa6.ChiffrerEntier(215)}.\n");

            // Déchiffrement du message chiffré
            Console.WriteLine($"Le message déchiffré de {rsa6.ChiffrerEntier(215)} est {rsa6.DechiffrerEntier(rsa6.ChiffrerEntier(215))}.\n");

            // Appel de la méthode ChiffrerChaine
            string messageAChiffrer = "FLORENCE";
            string messageChiffre = rsa6.ChiffrerChaine(messageAChiffrer);

            // Affichage du résultat
            Console.WriteLine($"Le message '{messageAChiffrer}' est chiffré en {messageChiffre}.\n");
        }	
    }
}

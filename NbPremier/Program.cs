using System;
using System.Collections.Generic;
using System.Security.Cryptography;

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

            // Tests de la classe Chaine
            Console.WriteLine("\nTEST DE LA CLASSE CHAINE :\n");

            // Définition d'un nouvel objet
            Chaine maChaine = new Chaine();

            // Affichage du résultat
            Console.WriteLine($"Le message '{"FLORENCE"}' est chiffré en {maChaine.ChiffrerChaine("FLORENCE")}.\n");

            // Découpage en blocs
            List<int> blocs = Chaine.DecouperEnBlocs(maChaine.ChiffrerChaine("FLORENCE"), 3);

            // Affichage du découpage
            Console.WriteLine("Découpé en blocs :");
            foreach (int bloc in blocs)
            {
                Console.Write(bloc + " ");
            }
            Console.WriteLine("\n");

            // Traduction en chaine
            Console.WriteLine($"Traduction en chaine de caractères : {Chaine.ConvertirListeEnChaine(blocs, 3)}.\n");

            // Traduction en chaine claire
            Console.WriteLine($"Traduction en chaine de caractères claire : {maChaine.DechiffrerChaine(Chaine.ConvertirListeEnChaine(blocs, 3))}.\n");

            // Tests des classes RSA et Chaine
            Console.WriteLine("\nTEST DES CLASSES RSA ET CHAINE :\n");

            RSA florence = new RSA(47, 71, 79);
            List<int> blocsChiffres = florence.ChiffrerChaine("FLORENCE");

            // Affichage des blocs chiffrés
            Console.WriteLine("Chiffrement de la chaine :");
            foreach (int blocChiffre in blocsChiffres)
            {
                Console.Write($"{blocChiffre} ");
            }
            Console.WriteLine("\n");

            // Déchiffrage des blocs
            Console.WriteLine($"Déchiffrage du message : {florence.DechiffrerListeBlocs(blocsChiffres)}");

            RSA viveUnix = new RSA(47, 71, 79);
            blocsChiffres = viveUnix.ChiffrerChaine("VIVE UNIX ET BONNE ANNEE");

            // Affichage des blocs chiffrés
            Console.WriteLine("Chiffrement de la chaine :");
            foreach (int blocChiffre in blocsChiffres)
            {
                Console.Write($"{blocChiffre} ");
            }
            Console.WriteLine("\n");

            // Déchiffrage des blocs
            Console.WriteLine($"Déchiffrage du message : {viveUnix.DechiffrerListeBlocs(blocsChiffres)}");

            Console.ReadLine();
        }	
    }
}

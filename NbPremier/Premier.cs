using System;
using System.Collections.Generic;
using System.Numerics;

namespace NbPremier
{
    internal class Premier
    {
        // Réalisé par Antoine PISSON et Antoine COUTREEL
        // Groupe : INFO2 G2

        // Crible d'Eratosthène
        public static bool[] CribleEratosthene(int n)
        {
            // On initialise le tableau de booléens des nombres premiers
            bool[] listeBiffe = new bool[n + 1];

            for (int i = 2; i <= n; i++)
            {
                listeBiffe[i] = true;
            }

            // On biffe le 1 qui n'est pas un nombre premier
            listeBiffe[1] = false;

            // On biffe les multiples de 2, puis 3...
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                // Si le nombre actuel n'a pas été biffé
                if (listeBiffe[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        listeBiffe[j] = false;
                    }
                }
            }

            return listeBiffe;
        }

        // Affiche crible d'Eratosthène
        public static void AfficherCribleEratosthene(int n)
        {
            bool[] listeBiffe = CribleEratosthene(n);

            Console.WriteLine("Nombres premiers jusqu'à " + n + ":");
            for (int i = 2; i <= n; i++)
            {
                if (listeBiffe[i])
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\n");
        }

        // Premiers entre eux
        public static bool PremierEntreEux(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a == 1;
        }

        // Décomposition en facteurs premiers
        public static (List<int>, List<int>) DFP(int n) // Décomposition en facteurs premiers
        {
            List<int> facteurs = new List<int>();
            List<int> exposants = new List<int>();

            bool[] tab = CribleEratosthene(n);
            int p = 2;

            if (n == 1)
            {
                facteurs.Add(1);
                exposants.Add(1);
            }
            else
            {
                if (tab[n] == true)
                {
                    facteurs.Add(n);
                    exposants.Add(1);
                }
                else
                {
                    while (n != 1)
                    {
                        int expo = 0; // Initialise l'exposant à zéro pour chaque facteur premier
                        if ((n % p) == 0)
                        {
                            facteurs.Add(p);
                            while ((n % p) == 0)
                            {
                                expo++;
                                n /= p;
                            }
                            exposants.Add(expo);
                        }
                        while (p <= n && tab[++p] != true) { }
                    }
                }
            }

            Console.WriteLine("Les facteurs et les exposants :");
            for (int i = 0; i < facteurs.Count; i++)
            {
                Console.WriteLine($"{facteurs[i]}^{exposants[i]}");
            }
            Console.WriteLine("\n");

            return (facteurs, exposants);
        }

        // Indicateur d'Euler
        public static int IndicateurEuler(int n)
        {
            bool[] tab = CribleEratosthene(n);
            List<int> facteurs = DFP(n).Item1;
            List<int> exposants = DFP(n).Item2;
            int resultat = 1;  // Initialiser le résultat à 1

            for (int i = 0; i < facteurs.Count; i++)
            {
                resultat *= (int)Math.Pow(facteurs[i], exposants[i] - 1) * (facteurs[i] - 1);
            }

            Console.WriteLine($"phi({n}) = {resultat}\n");
            return resultat;
        }

        // Exponentiation modulaire
        public static long PuissanceModulo(long baseValeur, long exposant, long modulo)
        {
            // Le résultat est toujours 0 si le modulo est 1.
            if (modulo == 1)
            {
                return 0;
            }

            long resultat = 1;
            baseValeur = baseValeur % modulo;

            string exposantBinaire = Convert.ToString(exposant, 2);

            for (int i = exposantBinaire.Length - 1; i >= 0; i--)
            {
                if (exposantBinaire[i] == '1')
                {
                    resultat = (resultat * baseValeur) % modulo;
                }
                baseValeur = (baseValeur * baseValeur) % modulo;
            }

            return resultat;
        }

    }
}

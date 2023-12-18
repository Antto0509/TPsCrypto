using System;
using System.Collections.Generic;

namespace NbPremier
{
    internal class Premier
    {
        // Réalisé par Antoine PISSON et Antoine COUTREEL
        // Groupe : INFO2 G2

        // Crible d'Eratosthène
        public static bool[] CribleEratosthene(int n)
        {
            int localN = n;
            // On initialise le tableau de booléens des nombres premiers
            bool[] listeBiffe = new bool[localN + 1];

            for (int i = 2; i <= localN; i++)
            {
                listeBiffe[i] = true;
            }

            // On biffe le 1 qui n'est pas un nombre premier
            listeBiffe[1] = false;

            // On biffe les multiples de 2, puis 3...
            for (int i = 2; i <= Math.Sqrt(localN); i++)
            {
                // Si le nombre actuel n'a pas été biffé
                if (listeBiffe[i])
                {
                    for (int j = i * i; j <= localN; j += i)
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
            int localN = n;
            bool[] listeBiffe = CribleEratosthene(localN);

            Console.WriteLine("Nombres premiers jusqu'à " + localN + ":");
            for (int i = 2; i <= localN; i++)
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
            int localA = a, localB = b;
            while (localB != 0)
            {
                int temp = localB;
                localB = localA % localB;
                localA = temp;
            }

            return localA == 1;
        }

        // Décomposition en facteurs premiers
        public static (List<int>, List<int>) DFP(int n) // Décomposition en facteurs premiers
        {
            int localN = n;
            List<int> facteurs = new List<int>();
            List<int> exposants = new List<int>();

            bool[] tab = CribleEratosthene(localN);
            int p = 2;

            if (localN == 1)
            {
                facteurs.Add(1);
                exposants.Add(1);
            }
            else
            {
                if (tab[localN] == true)
                {
                    facteurs.Add(localN);
                    exposants.Add(1);
                }
                else
                {
                    while (localN != 1)
                    {
                        int expo = 0; // Initialise l'exposant à zéro pour chaque facteur premier
                        if ((localN % p) == 0)
                        {
                            facteurs.Add(p);
                            while ((localN % p) == 0)
                            {
                                expo++;
                                localN /= p;
                            }
                            exposants.Add(expo);
                        }
                        while (p <= localN && tab[++p] != true) { }
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
            int localN = n;
            bool[] tab = CribleEratosthene(localN);
            List<int> facteurs = DFP(n).Item1;
            List<int> exposants = DFP(n).Item2;
            int resultat = 1;  // Initialiser le résultat à 1

            for (int i = 0; i < facteurs.Count; i++)
            {
                resultat *= (int)Math.Pow(facteurs[i], exposants[i] - 1) * (facteurs[i] - 1);
            }

            Console.WriteLine($"phi({localN}) = {resultat}\n");
            return resultat;
        }

        // Exponentiation modulaire
        public static long PuissanceModulo(long baseValeur, long exposant, long modulo)
        {
            long localBaseValeur = baseValeur, localExposant = exposant, localModulo = modulo;
            // Le résultat est toujours 0 si le modulo est 1.
            if (localModulo == 1)
            {
                return 0;
            }

            long resultat = 1;
            long baseValeurModif = localBaseValeur % localModulo;

            string exposantBinaire = Convert.ToString(localExposant, 2);

            for (int i = exposantBinaire.Length - 1; i >= 0; i--)
            {
                if (exposantBinaire[i] == '1')
                {
                    resultat = (resultat * baseValeurModif) % localModulo;
                }
                baseValeurModif = (baseValeurModif * baseValeurModif) % localModulo;
            }

            return resultat;
        }

    }
}

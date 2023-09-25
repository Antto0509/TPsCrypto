// Réalisé par Antoine PISSON et Antoine COUTREEL
// Groupe : INFO2 G2

using System;
using System.Collections.Generic;

public static class Premier
{

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
            // Si le nombre actuel n'as pas été biffé
            if (listeBiffe[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    listeBiffe[j] = false;
                }
            }
        }

        // Affichage des nombres premiers
        Console.WriteLine("Nombres premiers jusqu'à " + n + ":");
        for (int i = 2; i <= n; i++)
        {
            if (listeBiffe[i])
            {
                Console.Write(i + " ");
            }
        }

        /*Jeux de test.Les nombres premiers inférieurs à 100 sont:
         * 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97.*/

        return listeBiffe;
    }

    public static bool nbPremierEntreEux(int a, int b)
	{
		int PGCD = 0;
		int r = 0; 

		if (a > b && b != 0)
		{
            while (r != 0)
            {
				r = a % b;

                if (r == 0)
                {
                    PGCD = b;
                }
                else
                {
                    a = b;
                    b = r;
                }
            }

			if(PGCD == 1)
			{
                Console.WriteLine($"{a} et {b} sont premiers entre eux");
			}
        }
		else
		{
			if(b < a)
			{
                int echange = a;
                a = b;
                b = echange;

                Console.WriteLine($"Les valeurs {a} et {b} ont ete echanges pour trouver le PGCD.");

                while(r != 0)
                {
                    r = a % b;

                    if (r == 0)
                    {
                        PGCD = b;
                    }
                    else
                    {
                        a = b;
                        b = r;
                    }
                }

                if (PGCD == 1)
                {
                    Console.WriteLine($"{a} et {b} sont premiers entre eux");
                }
            }
		}
        if (b == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

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

        Console.WriteLine("Les facteurs et les exposants :");
        for (int i = 0; i < facteurs.Count; i++)
        {
            Console.WriteLine($"{facteurs[i]}^{exposants[i]}");
        }

        return (facteurs, exposants);
    }

    public static int IndicateurEuler(int n)
	{
        bool[] tab = CribleEratosthene(n);
        List<int> facteurs = DFP(n).Item1; 
        List<int> exposants = DFP(n).Item2;
        int r = 0;

        while (n != 1) 
        { 
            if(tab[n] == true)
            {
                Console.WriteLine($"phi({n}) = {n-1}");
                return (n - 1);
            }
            else
            {
                for(int i = 0; i < facteurs.Count; i++)
                {
                    r += (int)Math.Pow(facteurs[i], exposants[i] - 1) * (facteurs[i] - 1);
                }
                Console.WriteLine($"phi({n}) = {r}");
                return r;
            }
        }

        return 0;
	}

    // Exercice exponentiation modulaire
    public static long PuissanceModulo(long baseValeur, long exposant, long modulo)
    {
        // Le résultat est toujours 0 si le modulo est 1.
        if (modulo == 1)
        {
            return 0;
        }

        long resultat = 1;
        baseValeur = baseValeur % modulo;

        while (exposant > 0)
        {
            // Si exposant impair
            if (exposant % 2 == 1)
            {
                resultat = (resultat * baseValeur) % modulo;
            }

            baseValeur = (baseValeur * baseValeur) % modulo;
            exposant /= 2;
        }

        return resultat;
    }
}
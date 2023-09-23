// Réalisé par Antoine PISSON et Antoine COUTREEL
// Groupe : INFO2 G2

using System;
using System.Collections.Generic;

public static class Premier
{

	public static void CribleEratosthene(int n)
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
    }

    public static bool[] CribleEratostheneTF(int n)
    {
        int nbDiviseurs;

        int[] listeEntiers = new int[n];
        bool[] listeBool = new bool[n];

        listeBool[0] = false;

        for (int i = 1; i <= n; i++)
        {
            listeEntiers[i - 1] = i;
            //Console.WriteLine(i);
            nbDiviseurs = 0;
            for (int j = 1; j <= n; j++)
            {
                if ((i % j == 0) && (j <= i) && (i != 1))
                {
                    nbDiviseurs++;
                }
            }

            if (nbDiviseurs == 2)
            {
                listeBool[i - 1] = true;
            }
            else
            {
                listeBool[i - 1] = false;
            }
        }
        /*for (int k = 0; k < n; k++)
        {
            Console.WriteLine(listeBool[k]);
        }*/

        return listeBool;
    }

	public static bool nbPremierEntreEux(int a, int b)
	{
		int PGCD = 0;
		int r;

		if (a > b && b != 0)
		{
            do{
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
            } while (r != 0) ;

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

                do{
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
                } while (r != 0) ;

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

	public static (List<int>, List<int>) DFP(int n) // Décomposition en produit de Facteurs Premiers
    {
        List<int> facteurs = new List<int>();
        List<int> exposants = new List<int>();

        bool[] tab = CribleEratostheneTF(n);
        int p = 2;
        int expo = 0;

        facteurs.Add(n);

        while (n != 1)
        {
            if (n % p == 0)
            {
                facteurs.Add(p);
                while(n % p == 0)
                {
                    expo++;
                    n /= p;
                }
                exposants.Add(expo);
            }

            while (tab[p] != true) {}
        }

        /*Console.WriteLine("Les facteurs et les exposants :");
        for(int i = 0; i <= facteurs.Count; i++)
        {
            Console.WriteLine($"{facteurs[i]}  {exposants[i]}");
        }*/

        return (facteurs, exposants);
    }

	public static void IndicateurEuler()
	{

	}
}
﻿// Réalisé par Antoine PISSON et Antoine COUTREEL
// Groupe : INFO2 G2

using System;
using System.Collections.Generic;

public static class Premier
{

	public static void CribleEratosthene(int n)
	{
		int nbDiviseurs;

		int[] listeEntiers = new int[n];
		bool[] listeBiffe = new bool[n];
		for (int i = 1; i <= n; i++)
		{
			listeEntiers[i] = i;
			Console.WriteLine(i);
			nbDiviseurs = 0;

            for (int j = 1; j <= Math.Sqrt(n); j++)
            {
				if((i%j == 0) && (i!= 1))
				{
					nbDiviseurs++;
				}
            }
			
			if(nbDiviseurs <= 2)
			{
				listeBiffe[i-1] = true;
			}
			else
			{
				listeBiffe[i - 1] = false;
			}

        }

        /*Jeux de test.Les nombres premiers inférieurs à 100 sont: 
         * 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97.*/
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

	public static void DFP(int n) // Décomposition en produit de Facteurs Premiers
    {
        List<int> facteurs = new List<int>();
        List<int> exposants = new List<int>();

        do
        {

        } while (n >= 1);
    }

	public static void IndicateurEuler()
	{

	}
}
// Réalisé par Antoine PISSON et Antoine COUTREEL
// Groupe : INFO2 G2

using System;

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
				if((i%j == 0) and i!= 1)
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

	public static nbPremierEntreEux()
	{

	}

	public static DFP() // Décomposition en produit de Facteurs Premiers
    {

	}

	public static IndicateurEuler()
	{

	}
}
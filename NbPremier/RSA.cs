using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbPremier
{
    internal class RSA
    {
        private int p;
        private int q;
        private int e;
        private int n;
        private int d;
        private int z;

        // Constructeur
        public RSA(int p, int q, int e)
        {
            if (Valid(p, q))
            {
                this.p = p;
                this.q = q;
                this.e = e;
                n = p * q;
                z = Premier.IndicateurEuler(n);
                d = CalculerD();
            }
            else
            {
                Console.WriteLine("Clé de chiffrement invalide.");
            }
        }

        // Méthode pour vérifier la validité de la clé de chiffrement
        private bool Valid(int p, int q)
        {
            return true;
        }

        // Méthode pour calculer la clé de déchiffrement d
        private int CalculerD()
        {
            d = AlgorithmeEuclidienEtendu(e, z);
            if (d < 0)
            {
                d += z; // Assurer que d est positif
            }
            return d;
        }

        // Algorithme d'Euclide étendu
        private int AlgorithmeEuclidienEtendu(int a, int b)
        {
            int x0 = 1, x1 = 0, y0 = 0, y1 = 1;
            while (b != 0)
            {
                int q = a / b;
                int temp = b;
                b = a % b;
                a = temp;
                temp = x0;
                x0 = x1;
                x1 = temp - q * x1;
                temp = y0;
                y0 = y1;
                y1 = temp - q * y1;
            }
            return x0;
        }

        // Méthode pour afficher la clé de déchiffrement
        public void AfficherCleDechiffrement()
        {
            if (d != 0)
            {
                Console.WriteLine($"Clé de déchiffrement : {d}");
            }
            else
            {
                Console.WriteLine("Clé de déchiffrement non calculée.");
            }
        }
    }
}
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

        // Constructeur
        public RSA(int p, int q, int e)
        {
            if (EstValid(p, q, e))
            {
                this.p = p;
                this.q = q;
                this.e = e;
                this.n = p * q;
                this.d = CalculerD();
            }
            else
            {
                Console.WriteLine("Clé de chiffrement invalide.");
            }
        }

        // Méthode pour vérifier la validité de la clé de chiffrement
        private bool EstValid(int p, int q, int e)
        {
            int phiN = (p - 1) * (q - 1);
            return Premier.nbPremierEntreEux((int)e, (int)phiN) && p > 1 && q > 1 && e > 1 && n > 1;
        }

        // Méthode pour calculer la clé de déchiffrement d
        private int CalculerD()
        {
            int phiN = (p - 1) * (q - 1);
            int d = AlgorithmeEuclidienEtendu(e, phiN);
            if (d < 0)
            {
                d += phiN; // Assurer que d est positif
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
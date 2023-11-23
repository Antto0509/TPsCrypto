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
        public bool Valid(int p, int q)
        {
            int compteur = 0;
            bool[] tab;

            if (p > q)
            {
                tab = Premier.CribleEratosthene(p);
            }
            else
            {
                tab = Premier.CribleEratosthene(q);
            }

            for (int i = 2; i <= n; i++)
            {
                if (tab[i])
                {
                    if (i==p || i == q)
                    {
                        compteur++;
                    }
                }
            }
            if (compteur == 2)
            {
                return true;
            }
            return false;
        }

        // Méthode pour calculer la clé de déchiffrement d
        public int CalculerD()
        {
            d = (int)Premier.PuissanceModulo(e, Premier.IndicateurEuler(z) - 1, z);
            if (d < 0)
            {
                d += z; // Assurer que d est positif
            }
            return d;
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
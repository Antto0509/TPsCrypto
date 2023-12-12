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
        private int indicateurEuler;

        // Constructeur
        public RSA(int p, int q, int e)
        {
            this.p = p;
            this.q = q;
            this.e = e;
            n = p * q;

            if (!IsValidKey(p, q))
            {
                throw new ArgumentException("Clé de chiffrement invalide.");
            }

            indicateurEuler = CalculerIndicateurEuler(p, q);

            if (!IsValidPublicKey(indicateurEuler, e))
            {
                throw new ArgumentException("Clé de chiffrement invalide.");
            }

            d = CalculerD();
        }

        // Méthode pour vérifier la validité de la clé de chiffrement
        private bool IsValidKey(int p, int q)
        {
            int compteur = 0;
            bool[] tab;

            int max = Math.Max(p, q);
            tab = Premier.CribleEratosthene(max);

            for (int i = 2; i <= max; i++)
            {
                if (tab[i] && (i == p || i == q))
                {
                    compteur++;
                }
            }

            return compteur == 2;
        }


        private bool IsValidPublicKey(int z, int e)
        {
            return Premier.nbPremierEntreEux(z, e);
        }

        // Méthode pour calculer la clé de déchiffrement d
        private int CalculerD()
        {
            int dCalcule = (int)Premier.PuissanceModulo(e, indicateurEuler - 1, n);
            return (dCalcule < 0) ? dCalcule + n : dCalcule;
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

        // Méthode pour calculer l'indicateur Euler
        private int CalculerIndicateurEuler(int p, int q)
        {
            return Premier.IndicateurEuler(p) * Premier.IndicateurEuler(q);
        }
    }
}

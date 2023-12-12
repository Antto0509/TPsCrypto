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
            // Vérification de la validité de la clé de chiffrement et de la clé publique
            if (!EstCleChiffrementValide(p, q) || !EstClePubliqueValide(p, q, e))
            {
                throw new ArgumentException("Clé de chiffrement invalide.");
            }

            // Initialisation des attributs
            this.p = p;
            this.q = q;
            this.e = e;
            n = p * q;
            indicateurEuler = CalculerIndicateurEuler(p, q);
            d = CalculerD();
        }

        // Propriété publique pour accéder à d
        public long CleDechiffrement => d;

        // Méthode pour vérifier la validité de la clé de chiffrement
        private bool EstCleChiffrementValide(int p, int q)
        {
            int compteur = 0;
            bool[] tab;

            // Utilisation du crible d'Ératosthène pour trouver les nombres premiers jusqu'au maximum de p et q
            int max = Math.Max(p, q);
            tab = Premier.CribleEratosthene(max);

            // Vérification que p et q sont des nombres premiers distincts
            for (long i = 2; i <= max; i++)
            {
                if (tab[i] && (i == p || i == q))
                {
                    compteur++;
                }
            }

            return compteur == 2;
        }

        // Méthode pour vérifier la validité de la clé publique
        private bool EstClePubliqueValide(int p, int q, int e)
        {
            // Vérification que e est premier avec l'indicateur Euler
            return Premier.nbPremierEntreEux(CalculerIndicateurEuler(p, q), e);
        }

        // Méthode pour calculer la clé de déchiffrement d
        private int CalculerD()
        {
            int dCalcule = (int)Premier.PuissanceModulo(e, indicateurEuler - 1, n);
            return (dCalcule < 0) ? dCalcule + n : dCalcule;
        }

        // Méthode pour calculer l'indicateur Euler
        private int CalculerIndicateurEuler(int p, int q)
        {
            return Premier.IndicateurEuler(p) * Premier.IndicateurEuler(q);
        }
    }
}

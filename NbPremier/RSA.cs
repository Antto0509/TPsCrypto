using System;

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
            bool[] tab = Premier.CribleEratosthene(Math.Max(p, q));

            try
            {
                // Vérification de la validité des nombres premiers
                if (!tab[p] || !tab[q] || p == q)
                {
                    throw new ArgumentException("p et q doivent être des nombres premiers distincts.");
                }

                // Vérification de la validité de e et z
                int z = Premier.IndicateurEuler(p * q);
                if (!Premier.PremierEntreEux(z, e))
                {
                    throw new ArgumentException("e et z doivent être premiers entre eux.");
                }

                // Calcul de la clé de chiffrement (e, n)
                this.p = p;
                this.q = q;
                this.e = e;
                this.n = p * q;

                // Calcul de la clé de déchiffrement d
                this.d = CalculerD(e, z);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erreur dans la création de la clé RSA : {ex.Message}\n");
                // Vous pouvez choisir de lever à nouveau l'exception ou de prendre d'autres mesures.
            }
        }

        // Méthode pour calculer la clé de déchiffrement d
        private int CalculerD(int e, int z)
        {
            int dCalcule = (int)Premier.PuissanceModulo(e, Premier.IndicateurEuler(z) - 1, z);
            return (dCalcule < 0) ? dCalcule + z : dCalcule;
        }

        // Méthode pour afficher la clé de chiffrement
        public void AfficherCleChiffrement()
        {
            Console.WriteLine($"Clé de chiffrement : ({e}, {n})\n");
        }

        // Méthode pour afficher la clé de déchiffrement
        public void AfficherCleDechiffrement()
        {
            Console.WriteLine($"Clé de déchiffrement : {d}\n");
        }
    }
}

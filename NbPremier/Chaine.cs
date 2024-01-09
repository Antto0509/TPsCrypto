using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NbPremier
{
    internal class Chaine
    {
        public string ChiffrerChaine(string message)
        {
            try
            {
                // Vérification de la validité du message
                if (string.IsNullOrEmpty(message))
                {
                    throw new ArgumentException("Le message ne peut pas être vide ou nul.");
                }

                // Traduction du message en suite de nombres
                string messageChiffre = "";
                foreach (char caractere in message.ToUpper())
                {
                    if (caractere == ' ')
                    {
                        messageChiffre += "00";
                    }
                    else if (caractere >= 'A' && caractere <= 'Z')
                    {
                        int valeur = caractere - 'A' + 1;
                        messageChiffre += valeur.ToString("D2");
                    }
                    else
                    {
                        throw new ArgumentException($"Caractère non pris en charge : {caractere}");
                    }
                }

                return messageChiffre.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chiffrement de la chaîne : {ex.Message}");
                return string.Empty;
            }
        }

        public static List<int> DecouperEnBlocs(string chaineChiffre, int longueurBloc)
        {
            List<int> blocs = new List<int>();

            for (int i = 0; i < chaineChiffre.Length; i += longueurBloc)
            {
                string bloc = chaineChiffre.Substring(i, Math.Min(longueurBloc, chaineChiffre.Length - i));
                bloc = bloc.PadRight(longueurBloc, '0'); // Ajouter des zéros pour égaliser la longueur
                blocs.Add(Int32.Parse(bloc));
            }

            return blocs;
        }

        public static string ConvertirListeEnChaine(List<int> listeEntiers, int longueurSousChaine)
        {
            StringBuilder resultat = new StringBuilder();

            foreach (int entier in listeEntiers)
            {
                string sousChaine = entier.ToString("D" + longueurSousChaine);
                resultat.Append(sousChaine);
            }

            return resultat.ToString();
        }

        public static string DechiffrerChaine(string chaineChiffree)
        {
            StringBuilder messageClaire = new StringBuilder();

            for (int i = 0; i < chaineChiffree.Length; i += 2)
            {
                string bloc = chaineChiffree.Substring(i, 2);
                if (bloc == "00")
                {
                    messageClaire.Append(' '); // Ajouter un espace pour le bloc "00"
                }
                else
                {
                    int valeur = int.Parse(bloc);
                    char caractere = (char)('A' + valeur - 1);
                    messageClaire.Append(caractere);
                }
            }

            return messageClaire.ToString();
        }

    }
}

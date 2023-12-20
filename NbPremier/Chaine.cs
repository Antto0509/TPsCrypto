using System;
using System.Collections.Generic;
using System.Linq;

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

        public static List<int> DecouperEnBlocs(string chaine, int longueurBloc)
        {
            List<int> blocs = new List<int>();

            for (int i = 0; i < chaine.Length; i += longueurBloc)
            {
                string bloc = chaine.Substring(i, Math.Min(longueurBloc, chaine.Length - i));
                bloc = bloc.PadRight(longueurBloc, '0'); // Ajouter des zéros pour égaliser la longueur
                blocs.Add(int.Parse(bloc));
            }

            return blocs;
        }
    }
}

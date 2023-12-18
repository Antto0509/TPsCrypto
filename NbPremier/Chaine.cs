using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        messageChiffre += "00 ";
                    }
                    else if (caractere >= 'A' && caractere <= 'Z')
                    {
                        int valeur = caractere - 'A' + 1;
                        messageChiffre += valeur.ToString("D2") + " ";
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

    }
}

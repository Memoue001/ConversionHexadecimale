using System;
using System.Collections.Generic;

namespace ConversionHexadecimale
{
    internal class Program
    {
        // Dictionnaire pour stocker les conversions effectuées
        static Dictionary<int, string> conversions = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Programme de conversion d'entiers en hexadécimal.");
            Console.WriteLine("Saisissez un entier positif (ou tapez -1 pour quitter) :");

            while (true)
            {
                Console.Write("Entrez un entier : ");
                int entier;


                if (!int.TryParse(Console.ReadLine(), out entier) || entier < -1)
                {
                    Console.WriteLine("Veuillez entrer un entier valide (ou -1 pour quitter).");
                    continue;
                }

  
                if (entier == -1)
                {
                    Console.WriteLine("\n=== Liste des conversions ===");
                    foreach (var conversion in conversions)
                    {
                        Console.WriteLine($"{conversion.Key} -> {conversion.Value}");
                    }
                    Console.WriteLine("Fin du programme.");
                    break;
                }

            
                string hexadecimale = ConvertirEnHexadecimal(entier);
                Console.WriteLine($"Hexadécimal de {entier} : {hexadecimale}");

              
                conversions[entier] = hexadecimale;
            }
        }

        static string ConvertirEnHexadecimal(int nombre)
        {
            if (nombre == 0) return "0"; // Cas particulier pour 0

            string resultat = "";
            string hexDigits = "0123456789ABCDEF"; // Chiffres hexadécimaux

            while (nombre > 0)
            {
                int reste = nombre % 16; // Calculer le reste
                resultat = hexDigits[reste] + resultat; // Ajouter le chiffre au début de la chaîne
                nombre /= 16; // Diviser le quotient par 16
            }

            return resultat;
        }
    }
}

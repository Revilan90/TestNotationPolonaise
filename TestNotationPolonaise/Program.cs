/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        static string Polonaise(string form)
        {
            string erreur = "NaN";
            float resultat;
            string addition = "resultat = *4+2;";
            try
            {
                /*ce que j'envisage c'est de casser la formule en petits poceau grace à .Split
                 * puis on sépare les parties signes (/ + * etc) et les chiffres
                 * ensuite on applique les formule en utilisant des if tel que if(tableau[x]==/) alors valeur1 / valeur2
                 * 
                 * on part de la fin du tableau et on revient vers la gauche, on cherche les signes, quand on en trouve un on prend les 2 cases à droite, on fait l'opération des deux case par le symbole
                 * */
                string[] tableau = form.Split(' '), signe;
                int taille = tableau.Length, z;
                for (int y = taille - 1; y >= 0; y--)
                {
                    if (tableau[y] == "+" || tableau[y] == "-" || tableau[y] == "*" || tableau[y] == "/")
                    {
                        switch (tableau[y])
                        {
                            case "+":
                                tableau[y] = (float.Parse(tableau[y + 1]) + float.Parse(tableau[y + 2])).ToString();
                                break;
                            case "-":
                                tableau[y] = (float.Parse(tableau[y + 1]) - float.Parse(tableau[y + 2])).ToString();
                                break;
                            case "*":
                                tableau[y] = (float.Parse(tableau[y + 1]) * float.Parse(tableau[y + 2])).ToString();
                                break;
                            case "/":
                                tableau[y] = (float.Parse(tableau[y + 1]) / float.Parse(tableau[y + 2])).ToString();
                                break;
                        }
                        z = y;
                        while ((z + 3) < taille)
                        {
                            tableau[z + 1] = tableau[z + 3];

                            z++;
                        }
                        tableau[z + 2] = "";
                        tableau[z + 1] = "";
                    }
                }
                resultat = float.Parse(tableau[0]);
                if (tableau[0] == "∞")
                {
                    return erreur;
                }
                return tableau[0];
            }
            catch
            {
                return erreur;
            }
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}

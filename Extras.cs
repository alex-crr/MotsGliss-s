using System;

namespace MotsGlissés
{
    /// <summary>
    /// Classe contenant des méthodes supplémentaires. Elles sont statiques et ne nécessitent pas d'instanciation.
    /// </summary>
    public class Extras
    {
        /// <summary>
        /// Coupe un tableau de string en deux parties 
        /// Le polymorphisme n'a pas été implémenté
        /// </summary>
        /// <param name="tab">Tableau à couper</param>
        /// <returns>(string[], string []): les tableaux coupés, dans l'ordre de coupe</returns>
        public static (string[], string[]) Split(string[] tab)
        {
            int length = tab.Length;
            string[] firstArray, secondArray;
            firstArray = tab.Take(length / 2).ToArray();
            secondArray = tab.Skip(length / 2).ToArray();
            return (firstArray, secondArray);
        }

        /// <summary>
        /// Implémentation simple du Tri fusion
        /// </summary>
        /// <param name="tab">Tableau de string à trier</param>
        /// <returns>string[] tableau d'entrée trié</returns>
        public static string[] Fusion(string[] tab)
        {
            int length = tab.Length;
            if (length <= 1) return tab;

            static string[] Merge(string[] tab1, string[] tab2)
            {
                int l1 = tab1.Length;
                int l2 = tab2.Length;
                int lTot = l1 + l2;

                string[] res = new string[lTot];

                int i = 0;
                int j = 0;
                int cpt = 0;
                while (i < l1 && j < l2)
                {
                    if (String.Compare(tab1[i], tab2[j]) < 0)
                    {
                        res[cpt] = tab1[i];
                        i++;
                    }
                    else
                    {
                        res[cpt] = tab2[j];
                        j++;
                    }
                    cpt++;
                }
                if (j < l2)
                {
                    while (cpt < lTot)
                    {
                        res[cpt] = tab2[j];
                        j++;
                        cpt++;
                    }
                }
                if (i < l1)
                {
                    while (cpt < lTot)
                    {
                        res[cpt] = tab1[i];
                        i++;
                        cpt++;
                    }
                }
                return res;

            }


            (string[] array1, string[] array2) = Split(tab);
            return Merge(Fusion(array1), Fusion(array2));
        }
<<<<<<< Updated upstream
=======

        /// <summary>
        /// Représente une position dans un espace bidimensionnel.
        /// </summary>
>>>>>>> Stashed changes
        public struct Position
        {
            int x;
            int y;

            /// <summary>
            /// Propriété publique en lecture seule de la position en x
            /// </summary>
            /// <value>this.x</value>
            public int X { get => x; }
            /// <summary>
            /// Propriété publique en lecture seule de la position en y
            /// </summary>
            /// <value>this.y</value>
            public int Y { get => y; }

            /// <summary>
            /// Constructeur de la structure Position
            /// </summary>
            /// <param name="x">entier représentant la position dans la largeur de la console</param>
            /// <param name="y">entier représentant la position dans la hauteur de la console</param>
            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            /// <summary>
            /// Override de la méthode Equals pour comparer deux positions
            /// </summary>
            /// <param name="obj">objet que l'on compare</param>
            /// <returns></returns>
            public override bool Equals(object? obj)
            {
                if (obj is null) return false;
                if (obj is Position other)
                {
                    return x == other.x && y == other.y;
                }
                return false;
            }

            /// <summary>
            /// Override l'opérateur ==
            /// </summary>
            /// <param name="left">position 1</param>
            /// <param name="right">position 2</param>
            /// <returns>bool: vrai si les positions sont égales en x et y</returns>
            public static bool operator ==(Position left, Position right)
            {
                return left.Equals(right);
            }

            /// <summary>
            /// Override l'opérateur !=
            /// </summary>
            /// <param name="left">position 1</param>
            /// <param name="right">position 2</param>
            /// <returns>bool: vrai si les positions sont différentes en x et/ou y</returns>
            public static bool operator !=(Position left, Position right)
            {
                return !left.Equals(right);
            }

            /// <summary>
            /// Calcule un code de hachage pour l'objet actuel en fonction de ses valeurs x et y.
            /// </summary>
            /// <returns>Un code de hachage pour l'objet actuel.</returns>
            public override int GetHashCode()
            {
                return HashCode.Combine(x, y);
            }
        }
<<<<<<< Updated upstream
=======

        /// <summary>
        /// Equivalent de ReadLine mais avec un timeout
        /// </summary>
        /// <param name="timeout">La durée maximale d'attente pour une entrée.</param>
        /// <returns>La chaîne de caractères saisie par l'utilisateur, ou null si aucune saisie n'a été effectuée dans le délai imparti.</returns>
        public static string? ReadLine(TimeSpan timeout)
        {
            DateTime startTime = DateTime.Now;
            Stack<char> inputStack = new Stack<char>();
            string output = "";
            do
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.Backspace && inputStack.Any())
                    {
                        inputStack.Pop();
                    }
                    else
                    {
                        char c = key.KeyChar;
                        if (char.IsLetter(c)) inputStack.Push(c);
                    }
                    output = new string(inputStack.Reverse().ToArray());
                    Console.Write("\r                                                                          ");//clear line
                    Console.Write("\r{0}", output);
                }
            } while ((DateTime.Now - startTime) < timeout);

            Console.WriteLine();
            return (output.Length > 0) ? output.ToUpper() : null;
        }
>>>>>>> Stashed changes
    }
}
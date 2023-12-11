namespace MotsGlissés
{
    /// <summary>
    /// Cete classe contient des méthodes utiles pour le projet.
    /// Elles ne sont pas directement liées au jeu, mais rendent sont développement plus facile.
    /// Elles sont statiques pour pouvoir être appelées sans instancier la classe, et appelables depuis n'importe où.
    /// </summary>
    public class Extras
    {
        /// <summary>
        /// Méthode permettant de couper en deux un tableau de chaînes de caractères.
        /// Le polymorphisme est simple à ajouter, mais n'est pas nécessaire pour le projet.
        /// </summary>
        /// <param name="tab">Le plateau à couper</param>
        /// <returns>(string[], string[]): un tuple des tableaux coupés, dans l'ordre de coupe</returns>
        public static (string[], string[]) Split(string[] tab)
        {
            int length = tab.Length;
            string[] firstArray, secondArray;
            firstArray = tab.Take(length / 2).ToArray();
            secondArray = tab.Skip(length / 2).ToArray();
            return (firstArray, secondArray);
        }

        /// <summary>
        /// Implémentation récursive du tri fusion sur un tableau de string.
        /// Le polymorphisme est simple à ajouter, mais n'est pas nécessaire pour le projet.
        /// </summary>
        /// <param name="tab">Tableau à trier</param>
        /// <returns>string[]: le tableau qui a été trié</returns>
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

        /// <summary>
        /// Represents a position in a two-dimensional space.
        /// </summary>
        public struct Position
        {
            int x;
            int y;

            /// <summary>
            /// Propriété en lecture seule pour lire la position X, qui se réfère à la largeur de la console.
            /// </summary>
            /// <value></value>
            public int X { get => x; }
            /// <summary>
            /// Propriété en lecture seule pour lire la position Y, qui se réfère à la hauteur de la console.
            /// </summary>
            /// <value></value>
            public int Y { get => y; }

            /// <summary>
            /// Constructeur de la structure Position
            /// </summary>
            /// <param name="x">La position en x</param>
            /// <param name="y">La position en y</param>
            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            /// <summary>
            /// Override de la méthode Equals pour tester l'égalité de deux positions
            /// </summary>
            /// <param name="obj">Objet à tester</param>
            /// <returns>bool: vrai si les positions sont égales en x et y, faux dans le cas contraire, ou si elle est nulle.</returns>
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
            /// Override de l'opérateur == pour tester l'égalité de deux positions
            /// </summary>
            /// <param name="left">Première position</param>
            /// <param name="right">Seconde position</param>
            /// <returns>bool: vrai si les deux positions sont égales</returns>
            public static bool operator ==(Position left, Position right)
            {
                return left.Equals(right);
            }

            /// <summary>
            /// Override de l'opérateur != pour tester l'inégalité de deux positions
            /// </summary>
            /// <param name="left">Première position</param>
            /// <param name="right">Seconde position</param>
            /// <returns>bool: vrai si l'inégalité est vérifiée, faux snn</returns>
            public static bool operator !=(Position left, Position right)
            {
                return !left.Equals(right);
            }
        }

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
                    // ajouter check si c'est une lettre
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
                    Console.Write("\r                                                                          ");
                    Console.Write("\r{0}", output);
                }
            } while ((DateTime.Now - startTime) < timeout);

            Console.WriteLine();
            return (output.Length > 0) ? output.ToUpper() : null;
        }
    }
}
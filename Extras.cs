﻿namespace MotsGlissés
{
    public class Extras
    {
        public static (string[], string[]) Split(string[] tab)
        {
            int length = tab.Length;
            string[] firstArray, secondArray;
            firstArray = tab.Take(length / 2).ToArray();
            secondArray = tab.Skip(length / 2).ToArray();
            return (firstArray, secondArray);
        }
        public static (int[], int[]) Split(int[] tab)
        {
            int length = tab.Length;
            int[] firstArray, secondArray;
            firstArray = tab.Take(length / 2).ToArray();
            secondArray = tab.Skip(length / 2).ToArray();
            return (firstArray, secondArray);
        }

        public static int[] Fusion(int[] tab)
        {
            int length = tab.Length;
            if (length <= 1) return tab;

            static int[] Merge(int[] tab1, int[] tab2)
            {
                int l1 = tab1.Length;
                int l2 = tab2.Length;
                int lTot = l1 + l2;

                int[] res = new int[lTot];

                int i = 0;
                int j = 0;
                int cpt = 0;
                while (i < l1 && j < l2)
                {
                    if (tab1[i] < tab2[j])
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

            (int[] array1, int[] array2) = Split(tab);
            return Merge(Fusion(array1), Fusion(array2));
        }

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

            public int X { get => x; }
            public int Y { get => y; }

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override bool Equals(object obj)
            {
                if (obj is Position other)
                {
                    return x == other.x && y == other.y;
                }
                return false;
            }
            public static bool operator ==(Position left, Position right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Position left, Position right)
            {
                return !left.Equals(right);
            }
        }

        /// <summary>
        /// Reads a line of input from the console with a specified timeout.
        /// </summary>
        /// <param name="timeout">The maximum amount of time to wait for input.</param>
        /// <returns>The input string entered by the user, or null if no input was received within the timeout.</returns>
        public static string ReadLine(TimeSpan timeout)
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
                        if(char.IsLetter(c)) inputStack.Push(c);
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

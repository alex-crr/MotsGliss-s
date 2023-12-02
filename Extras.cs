using System;

namespace MotsGlissés
{
    class Extras
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

            int[] Merge(int[] tab1, int[] tab2)
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

            string[] Merge(string[] tab1, string[] tab2)
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
    }
}

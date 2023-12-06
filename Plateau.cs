using System;
using System.Text.RegularExpressions;
using System.IO;

namespace MotsGlissés
{
    public class Plateau
    {
        char[,] plat;
        Random r = new Random();

        public Plateau(int lignes, int colonnes)
        {
            plat = new char[lignes, colonnes];
        }

        public string toString()
        {
            string s = "";
            for (int i = 0;i< plat.GetLength(0);i++)
            {
                for (int j = 0;j< plat.GetLength(1);j++)
                {
                    s += plat[i, j];
                }
                s += "\n";
            }
            return s;
        }

        public void toFile(string nomfile)
        {
            StreamWriter s = new StreamWriter(nomfile);
            for (int i = 0; i< plat.GetLength(0);i++)
            {
                for(int j = 0; j< plat.GetLength(1);j++)
                {
                    s.Write(plat[i,j]);
                }
                s.WriteLine();
            }
            s.Close();
        }

        public void toRead(string nomfile)
        {

        }


    }
}

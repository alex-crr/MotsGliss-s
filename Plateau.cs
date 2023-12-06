using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace MotsGlissés
{
    public class Plateau
    {
        // faire une liste avec le nombre de lettre possible ,
        // choisir un element au hasard liste[r.Next(1,liste.count)]
        // et le supprimer de la liste
        char[,] plat;
        Random r = new Random();

        public Plateau(int lignes, int colonnes)
        {
            plat = new char[lignes, colonnes];
        }
        /// <summary>
        /// crée un plateau de maniere aleatoire
        /// </summary>
        public void alea()
        {
            List<char> lettre = new List<char>();
            string[] lines = File.ReadAllLines("lettre.txt"); // tableau de ligne 
            foreach (string line in lines)
            {
                string[] temp = line.Split(','); //[A;10;0]
                for (int i = 0; i < Convert.ToInt32(temp[1]); i++)
                {
                    lettre.Add(temp[0][0]);
                }
            }
            for(int i =0; i < plat.GetLength(0);i++)
            {
                for(int j = 0; j < plat.GetLength(1);j++)
                {
                    int nb = r.Next(lettre.Count());
                    plat[i, j] = lettre[nb];
                    lettre.Remove(lettre[nb]);
                }
            }
        }
        /// <summary>
        /// retourne une chaîne de caractères qui décrit le plateau
        /// </summary>
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
        /// <summary>
        /// sauvegarde l’instance du plateau dans un fichier en respectant la structure précisée
        /// </summary>
        /// <param name="nomfile">nom du fichier</param>
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
        /// <summary>
        /// fonction lit le fichier et met chacun des éléments dans la plateau
        /// </summary>
        /// <param name="nomfile">nom du fichier</param>
        public void toRead(string nomfile)
        {
            //pas de trycatch car le verification
          
            string[] lines = File.ReadAllLines(nomfile);
            string[][] lines2 = new string[lines.Length][];
            int var  = 0;
            foreach (string line in lines) // remplie la lines2
            {
                lines2[var] = line.Split(';'); 
            }
            for (int i = 0; i < lines2.GetLength(0); i++)
            {
                for (int j = 0; j < lines2[i].GetLength(1); j++)
                {
                    plat[i, j] = lines2[i][j][0]; // met les éléments de lines2 dans plateau
                }
            }
           
        }
        /// <summary>
        /// met a jour la matrice en fonction du mot trouvé
        /// </summary>
        public void Maj_plateau(string mot) { }
    }
}

using System;

namespace MotsGlissés
{
    public class Plateau
    {
        // faire une liste avec le nombre de lettre possible ,
        // choisir un element au hasard liste[r.Next(1,liste.count)]
        // et le supprimer de la liste
        
        char[,] _plateau;
        Random r = new Random();

        public Plateau(string filepath)
        {

        }

        /// <summary>
        /// crée un plateau de maniere aleatoire
        /// </summary>
        public Plateau()
        {
            string filePath  = Path.Combine("..", "..", "..", "Resources", "Lettre.txt");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Plateau: couldn't find {filePath}.");
            }
            _plateau = new char[8, 8]; // à faire en fonction de la taille limite
            List<char> lettre = new List<char>();
            string[] lines = File.ReadAllLines(filePath); // tableau de ligne 
            foreach (string line in lines)
            {
                string[] temp = line.Split(','); //[A,10,0]
                for (int i = 0; i < Convert.ToInt32(temp[1]); i++)
                {
                    lettre.Add(temp[0][0]);
                }
            }
            for (int i = 0; i < _plateau.GetLength(0); i++)
            {
                for (int j = 0; j < _plateau.GetLength(1); j++)
                {
                    int nb = r.Next(lettre.Count());
                    _plateau[i, j] = lettre[nb];
                    lettre.Remove(lettre[nb]);
                }
            }
        }

        /// <summary>
        /// retourne une chaîne de caractères qui décrit le plateau
        /// </summary>
        public string toString()
        {
            string output = "";
            for (int i = 0; i < _plateau.GetLength(0); i++)
            {
                for (int j = 0; j < _plateau.GetLength(1); j++)
                {
                    output += $"| {_plateau[i, j]} ";
                }
                output += "|\n";
            }
            return output;
        }
        
        /// <summary>
        /// sauvegarde l’instance du plateau dans un fichier en respectant la structure précisée
        /// </summary>
        /// <param name="nomfile">nom du fichier</param>
        public void toFile(string nomfile)
        {
            StreamWriter s = new StreamWriter(nomfile);
            for (int i = 0; i < _plateau.GetLength(0); i++)
            {
                for (int j = 0; j < _plateau.GetLength(1); j++)
                {
                    s.Write(_plateau[i, j]);
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
            int var = 0;
            foreach (string line in lines) // remplie la lines2
            {
                lines2[var] = line.Split(';');
            }
            for (int i = 0; i < lines2.GetLength(0); i++)
            {
                for (int j = 0; j < lines2[i].GetLength(1); j++)
                {
                    _plateau[i, j] = lines2[i][j][0]; // met les éléments de lines2 dans plateau
                }
            }

        }

        /// <summary>
        /// met a jour la matrice en fonction du mot trouvé
        /// </summary>
        public void Maj_plateau(string mot) { throw new NotImplementedException();}

        public struct Position
        {
            int x;
            int y;
            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public (bool, List<Position>) Recherche_Mot(string mot, Position lastPos, int cpt){
            throw new NotImplementedException();
            if(cpt == 0){
                
            }
        }
    }
}

using System;
using static MotsGlissés.Extras;

namespace MotsGlissés
{
    public class Plateau
    {
        // faire une liste avec le nombre de lettre possible ,
        // choisir un element au hasard liste[r.Next(1,liste.count)]
        // et le supprimer de la liste

        char[,] _plateau; // avec [Y, la hauteur et largeur respectivement
        Random r = new Random();

        /// <summary>
        /// crée le plateau à partir d'un csv
        /// </summary>
        /// <param name="filepath"></param>
        public Plateau(string filepath)
        {
            ToRead(filepath);
        }

        /// <summary>
        /// crée un plateau de maniere aleatoire
        /// </summary>
        public Plateau()
        {
            string filePath = Path.Combine("..", "..", "..", "Resources", "Lettre.txt");
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
        public void ToFile(string nomfile)
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
        /// <param name="filepath">nom du fichier</param>
        public void ToRead(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"Plateau: couldn't find {filepath}.");
            }
            string[] lines = File.ReadAllLines(filepath);
            _plateau = new char[lines.Length, lines[0].Split(';').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(';');
                for (int j = 0; j < temp.Length; j++)
                {
                    _plateau[i, j] = temp[j].ToUpper()[0];
                }
            }

        }

        /// <summary>
        /// met a jour la matrice en fonction du mot trouvé
        /// </summary>
        public void Maj_plateau(string mot) { throw new NotImplementedException(); }


        public (bool, Stack<Position>) Recherche_Mot(string mot)
        {
            if (mot is null)
            {
                throw new ArgumentNullException(nameof(mot));
            }
            else if (mot.Length == 0)
            {
                Console.WriteLine("mot de taille nulle");
                return (false, new Stack<Position>());
            }
            else
            {
                mot = mot.ToUpper();
                int height = _plateau.GetLength(0) - 1; //pos de la dernière ligne
                bool found = false; // mot trouvé ou pas
                Stack<Position> pos = new Stack<Position>();
                int i = 0;
                int Length = _plateau.GetLength(1);
                while (!found && i < Length)
                {
                    if (mot[0] == _plateau[height, i])
                    {
                        Stack<Position> positions = new Stack<Position>();
                        (found, pos) = Recherche_Aux(0, positions, mot, new Position(i, height));
                    }
                    i++;
                }
                return (found, pos);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpt">position dans le mot</param>
        /// <param name="positions">liste des précédentes positions</param>
        /// <param name="mot">mot qu'on cherche</param>
        /// <param name="pos">position qu'on teste</param>
        /// <returns></returns>
        private (bool, Stack<Position>) Recherche_Aux(int cpt, Stack<Position> positions, string mot, Position pos)
        {
            if (cpt == mot.Length) return (true, positions);
            //Position latsPos = positions.Peek();
            bool found = false;
            if (pos.X >= 0 && pos.X < _plateau.GetLength(1) && pos.Y >= 0 && pos.Y < _plateau.GetLength(0) && _plateau[pos.Y, pos.X] == mot[cpt])
            {
                Console.WriteLine($"lettre trouvée: {mot[cpt]}, longueur du mot: {mot.Length}, position: {pos.X}, {pos.Y}");
                (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X, pos.Y - 1)); //recherche en haut
                if (!found)
                {
                    (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X - 1, pos.Y)); //recherche à gauche
                    if (!found)
                    {
                        (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X + 1, pos.Y));//recherche verticale
                        if (!found)
                        {
                            (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X - 1, pos.Y -1));//recherche verticale
                            if (!found)
                            {
                                (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X + 1, pos.Y - 1));//recherche verticale
                            }
                        }
                    }

                }
            }
            return (found, positions);
        }
    }
}

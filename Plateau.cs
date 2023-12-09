namespace MotsGlissés
{
    public class Plateau
    {
        // faire une liste avec le nombre de lettre possible ,
        // choisir un element au hasard liste[r.Next(1,liste.count)]
        // et le supprimer de la liste

        char[,] _plateau; // avec [Y,X] la hauteur et largeur respectivement
        Random r = new Random();
        int _nbLettres = 0;
        Dictionary<char, int> _scoreLettres = new Dictionary<char, int>()
        {
            {'A', 1},{'I', 1},{'E', 1},{'L', 1},{'N', 1},{'O', 1},{'R', 1},{'S', 1},{'T', 1},{'U', 1},
            {'D', 2},{'G', 2},{'M', 2},
            {'B', 3},{'C', 3},{'P', 3},
            {'F', 4},{'H', 4},{'V', 4},        
            {'J', 8},{'Q', 8},
            {'K', 10},{'W', 10},{'X', 10},{'Y', 10},{'Z', 10},
        }; // valeurs du scrabble
        
        public int NbLettres
        {
            get { return _nbLettres; }
        }

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

            _nbLettres = 64;
            _plateau = new char[8, 8]; // à faire en fonction de la taille limite
            List<char> lettres = new List<char>();
            _scoreLettres = new Dictionary<char, int>();
            string[] lines = File.ReadAllLines(filePath); // tableau de ligne 
            foreach (string line in lines)
            {
                string[] temp = line.Split(','); //[A,10,0]
                for (int i = 0; i < Convert.ToInt32(temp[1]); i++)
                {
                    lettres.Add(temp[0][0]);
                }
                _scoreLettres.Add(temp[0][0], Convert.ToInt32(temp[2]));

            }
            for (int i = 0; i < _plateau.GetLength(0); i++)
            {
                for (int j = 0; j < _plateau.GetLength(1); j++)
                {
                    int nb = r.Next(lettres.Count());
                    _plateau[i, j] = lettres[nb];
                    lettres.Remove(lettres[nb]);
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
                    s.Write(_plateau[i, j] + ";");
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
                    _nbLettres++;
                }
            }

        }

        /// <summary>
        /// met a jour la matrice en fonction du mot trouvé
        /// </summary>
        public void Maj_Plateau(Stack<Position> positions)
        {
            int height = _plateau.GetLength(1) - 1;
            while (positions.Count() != 0)
            {
                Position pos = positions.Pop();
                _nbLettres--;
                _plateau[pos.Y, pos.X] = ' ';
                for(int i = pos.Y; i >= 1; i--){
                    (_plateau[i, pos.X], _plateau[i - 1, pos.X])  = (_plateau[i - 1, pos.X], _plateau[i, pos.X]);
                }
            }
        }

        /// <summary>
        /// Initie un arbre de recherche sur toutes les cases de la ligne en bas du plateau. 
        /// Un test est efectué dans la recherche arbre pour savoir si la case correspondà ce qu'on attend. 
        /// Assez opti
        /// </summary>
        /// <param name="mot">mot à chercher</param>
        /// <returns>bool : si le mot a été trouvé, Stack<Position> : représentation du chemin pris</returns>
        public (bool, Stack<Position>) Recherche_Mot(string mot)
        {
            if (mot is null)
            {
                throw new ArgumentNullException(nameof(mot));
            }
            else if (mot.Length == 0) // handled par la recherche dans le dico qui renvoie faux
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
                    Stack<Position> positions = new Stack<Position>();
                    (found, pos) = Recherche_Aux(0, positions, mot, new Position(i, height));

                    i++;
                }
                return (found, pos);
            }
        }

        /// <summary>
        /// Principe de recherche récursive dans un arbre. 
        /// </summary>
        /// <param name="cpt">position dans le mot</param>
        /// <param name="positions">liste des précédentes positions</param>
        /// <param name="mot">mot qu'on cherche</param>
        /// <param name="pos">position qu'on teste</param>
        /// <returns></returns>
        private (bool, Stack<Position>) Recherche_Aux(int cpt, Stack<Position> positions, string mot, Position pos)
        {
            if (cpt == mot.Length) return (true, positions); // Si on a compté le bon nombre de lettres valides, c'est qu'on a trouvé le mot
            if (positions.Contains(pos)) return (false, positions);// si on est déjà passé par là, on arrête

            bool found = false;
            if (pos.X >= 0 && pos.X < _plateau.GetLength(1) && pos.Y >= 0 && pos.Y < _plateau.GetLength(0) && _plateau[pos.Y, pos.X] == mot[cpt])
            {   
                positions.Push(pos);
                (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X, pos.Y - 1)); //recherche en haut
                if (!found)
                {
                    (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X - 1, pos.Y)); //recherche à gauche
                    if (!found)
                    {
                        (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X + 1, pos.Y));//recherche droite
                        if (!found)
                        {
                            (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X - 1, pos.Y - 1));//recherche diag gauche
                            if (!found)
                            {
                                (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Position(pos.X + 1, pos.Y - 1));//recherche diag droite
                            }
                        }
                    }

                }
            }
            return (found, positions);
        }

        public int GetScore(string mot)
        {
            int score = 0;
            foreach (char c in mot)
            {
                score += _scoreLettres[c];
            }
            return score;
        }
    }
}

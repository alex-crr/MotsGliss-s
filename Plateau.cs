namespace MotsGlissés
{
    /// <summary>
    /// Classe représentant un plateau de jeu
    /// </summary>
    public class Plateau
    {
        // faire une liste avec le nombre de lettre possible ,
        // choisir un element au hasard liste[r.Next(1,liste.count)]
        // et le supprimer de la liste

        //attributs
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

        /// <summary>
        /// Propriété en lecture seule représentant le nombre de lettres restantes sur le plateau
        /// </summary>
        /// <value></value>
        public int NbLettres
        {
            get { return _nbLettres; }
        }

        /// <summary>
        /// Constructeur qui crée un plateau à partir d'un fichier .csv
        /// Se référer à ToRead 
        /// </summary>
        /// <param name="filePath"></param>
        public Plateau(string filePath)
        {
            ToRead(filePath);
        }

        /// <summary>
        /// Crée un plateau de maniere aleatoire à partir d'un fichier .txt conforme au sujet
        /// Prochaine implémentations : sélection du fichier et de la taille du plateau
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
                _scoreLettres.Add(temp[0][0], Convert.ToInt32(temp[2]));//dcitionnaire de score ici car lecture du fichier via streamreader

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
        /// Retourne une chaîne de caractères qui représente le plateau
        /// </summary>
        /// <returns>Chaîne de caractère représentant le tableau de jeu</returns>
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
        /// Sauvegarde l’instance du plateau dans un fichier en respectant la structure précisée
        /// </summary>
        /// <param name="filePath">Chemin du fichier d'écriture</param>
        public void ToFile(string filePath)
        {

            StreamWriter s = new StreamWriter(filePath);
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
        /// Lecture d'un fichier .csv et remplissage du plateau
        /// </summary>
        /// <param name="filePath">Chemin vers le fichier</param>
        public void ToRead(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Plateau: couldn't find {filePath}.");
            }
            string[] lines = File.ReadAllLines(filePath);
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
        /// Mise à jour de la matrice représentant le plateau selon les positions données
        /// Remplace les positions par des espaces et fait descendre les lettres
        /// Les positions sont données dans une stack pour éviter les modifications intempestives des positions
        /// </summary>
        /// <param name="positions">Pile des positions à modifier</param>
        public void Maj_Plateau(Stack<Pos> positions)
        {
            int height = _plateau.GetLength(1) - 1;
            while (positions.Count() != 0)
            {
                Pos pos = positions.Pop();
                _nbLettres--;
                _plateau[pos.Y, pos.X] = ' ';
                for (int i = pos.Y; i >= 1; i--)
                {
                    (_plateau[i, pos.X], _plateau[i - 1, pos.X]) = (_plateau[i - 1, pos.X], _plateau[i, pos.X]);
                }
            }
        }

        /// <summary>
        /// Initie un arbre de recherche sur toutes les cases de la ligne en bas du plateau. 
        /// Un test est efectué dans la recherche arbre pour savoir si la case correspond à ce que l'on attend. 
        /// Assez opti
        /// </summary>
        /// <param name="mot">Mot à chercher</param>
        /// <returns>bool : Vrai si le mot a été trouvé, Stack<Position> : représentation du chemin pris, utilisé par Maj_Plateau()</returns>
        public (bool, Stack<Pos>) Recherche_Mot(string mot)
        {
            if (mot is null)
            {
                throw new ArgumentNullException(nameof(mot));
            }
            else if (mot.Length == 0) // handled par la recherche dans le dico qui renvoie faux mais bon
            {
                Console.WriteLine("mot de taille nulle");
                return (false, new Stack<Pos>());
            }
            else
            {
                //mot = mot.ToUpper(); // théoriquement géré par le dico
                int height = _plateau.GetLength(0) - 1; //pos de la dernière ligne
                bool found = false; // mot trouvé ou pas
                Stack<Pos> pos = new Stack<Pos>();
                int i = 0;
                int Length = _plateau.GetLength(1);
                while (!found && i < Length)
                {
                    Stack<Pos> positions = new Stack<Pos>();
                    (found, pos) = Recherche_Aux(0, positions, mot, new Pos(i, height));

                    i++;
                }
                return (found, pos);
            }
        }

        /// <summary>
        /// Principe de recherche récursive dans un arbre. 
        /// </summary>
        /// <param name="cpt">Nombre de lettres trouvés du mot, représente la position dans le mot</param>
        /// <param name="positions">Liste des positions précédentes</param>
        /// <param name="mot">Mot cherché</param>
        /// <param name="pos">Position actuelle que l'on teste</param>
        /// <returns>bool: Vrai si le mot a été trouvé, Stack<Position>: chemin du mot dans la matrice </returns>
        private (bool, Stack<Pos>) Recherche_Aux(int cpt, Stack<Pos> positions, string mot, Pos pos)
        {
            if (cpt == mot.Length) return (true, positions); // Si on a compté le bon nombre de lettres valides, c'est qu'on a trouvé le mot
            if (positions.Contains(pos)) return (false, positions);// si on est déjà passé par là, on arrête

            bool found = false;
            if (pos.X >= 0 && pos.X < _plateau.GetLength(1) && pos.Y >= 0 && pos.Y < _plateau.GetLength(0) && _plateau[pos.Y, pos.X] == mot[cpt])
            {
                positions.Push(pos);
                (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Pos(pos.X, pos.Y - 1)); //recherche en haut
                if (!found)
                {
                    (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Pos(pos.X - 1, pos.Y)); //recherche à gauche
                    if (!found)
                    {
                        (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Pos(pos.X + 1, pos.Y));//recherche droite
                        if (!found)
                        {
                            (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Pos(pos.X - 1, pos.Y - 1));//recherche diag gauche
                            if (!found)
                            {
                                (found, positions) = Recherche_Aux(cpt + 1, positions, mot, new Pos(pos.X + 1, pos.Y - 1));//recherche diag droite
                            }
                        }
                    }

                }
            }
            return (found, positions);
        }

        /// <summary>
        /// Récupère le score d'un mot en fonction des valeurs des lettres
        /// </summary>
        /// <param name="mot">Mot dont on cherche le scor associé</param>
        /// <returns>int: valeur Scrabble du mot choisi</returns>
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

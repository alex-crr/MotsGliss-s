namespace MotsGlissés
{
    /// <summary>
    /// Classe représentant un dictionnaire. Elle ne contient que le chemin vers le fichier représentant le dictionnaire.
    /// </summary>
    public class Dictionnaire
    {
        // attributs
        string _chemin; // chemin vers le fichier contenant le dictionnaire

        /// <summary>
        /// Constructeur de la classe Dictionnaire
        /// </summary>
        /// <param name="chemin">Chemin vers le fichier représentant le dictionnaire</param>
        public Dictionnaire(string chemin)
        {
            if (!File.Exists(chemin))
            {
                throw new FileNotFoundException($"Dictionnaire: couldn't find {chemin}.");
            }
            _chemin = chemin;
        }

        /// <summary>
        /// Effectue un Tri Fusion sur chacune des lignes du dictionnaire
        /// Possible de le faire grâce à des streams
        /// Implémentation de Fusion dans Extras.cs
        /// </summary>
        public void Tri_Fusion()
        {
            string[] lines = File.ReadAllLines(_chemin);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');
                words = Extras.Fusion(words);
                lines[i] = string.Join(" ", words);
            }
            File.WriteAllLines(_chemin, lines);
        }

        /// <summary>
        /// Recherche un mot dans le dictionnaire, via un stream, en accédant itérativement à la ligne correspondante au premier caractère du mot
        /// Nécessite que le dictionnaire soit trié, et que le format du fichier soit correct et en accord avec le sujet
        /// </summary>
        /// <param name="input">Mot recherché</param>
        /// <returns>bool: Vrai si la mot a été trouvé, faux si le mot n'est pas trouvé, ou est nul, de taille nulle, ou ne contient pas que des lettres</returns>
        public bool RechDichoRecursif(string input)
        {
            if (input == null) return false;
            if (input.Length == 0) return false;
            if (!input.All(Char.IsLetter)) return false;
            else
            {
                //input = input.ToUpper();// théoriquement géré par ReadLine()
                using (StreamReader sr = new StreamReader(_chemin))
                {
                    string line;
                    int cpt = 0;
                    while ((line = sr.ReadLine()) != null && cpt < 26)
                    {
                        if (cpt == input[0] - 65)
                        {
                            string[] lineContent = line.Split(" ");

                            bool Cherche(int borneInf, int borneSup)
                            {
                                int middle = (borneInf + borneSup) / 2;
                                if (borneInf > borneSup) return false;
                                if (lineContent[middle] == input) return true;

                                int compared = lineContent[middle].CompareTo(input);
                                if (compared > 0) return Cherche(borneInf, middle - 1);
                                else return Cherche(middle + 1, borneSup);
                            }

                            return Cherche(0, lineContent.Length - 1);
                        }
                        cpt++;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Représente le dictionnaire sous forme de chaîne de caractères
        /// Affiche la langue du dictionnaire (français par défaut ), puis le nombre de mots par lettre
        /// Implémenté avec un stream
        /// Assume que le dictionnaire soit conforme au format donné dans le sujet
        /// </summary>
        /// <returns>string: la chaîne de caractère</returns>
        public string toString()
        {
            using (StreamReader sr = new StreamReader(_chemin))
            {
                string line;
                int cpt = 65;
                string res = "Langue Française\n";
                while ((line = sr.ReadLine()) != null)
                {

                    res += $"{(char)cpt} : {line.Split(" ").Length} mots\n";
                    cpt++;
                }
                return res;
            }
        }
    }
}

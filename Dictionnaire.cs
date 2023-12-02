using System;

namespace MotsGlissés
{
    class Dictionnaire
    {
        string _chemin;
        public Dictionnaire(string chemin)
        {
            if (!File.Exists(chemin))
            {
                throw new FileNotFoundException();
            }
            _chemin = chemin;
        }

        public void Sort()
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

        public bool Exists(string input)
        {
            if (input == null) return false;
            if (input.Length == 0) return false;
            if (!input.All(Char.IsLetter)) return false;
            else
            {
                input = input.ToUpper();
                using (StreamReader sr = new StreamReader(_chemin))
                {
                    string line;
                    int cpt = 0;
                    while ((line = sr.ReadLine()) != null && cpt < 26)
                    {
                        if (cpt == input[0] - 65)
                        {
                            string[] lineContent = line.Split(" ");

                            bool Cherche(int borneInf, int borneSup) //pas dingue car cherche 1 puis 2, pas de comparaisons sur pivot central
                            {
                                int middle = borneInf + ((borneSup - borneInf) / 2);
                                int compared = string.Compare(lineContent[middle], input);
                                if (compared == 0) return input == lineContent[middle];
                                else if (compared < 0) return Cherche(middle + 1, borneSup);
                                else return Cherche(0, middle - 1);
                            }

                            return Cherche(0, lineContent.Length - 1);
                        }
                        cpt++;
                    }
                }
                return false;
            }
        }
    }
}

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
                    while ((line = sr.ReadLine()) != null && cpt != input[0] - 65)
                    {
                        cpt++;
                    }
                    bool Cherche(string[] tab) //pas dingue car cherche 1 puis 2, pas de comparaisons sur pivot central
                    {
                        if (tab.Length == 0) return false;
                        if (tab.Length == 1) return tab[0] == input;
                        else
                        {
                            (string[] arr1, string[] arr2) = Extras.Split(tab);
                            return Cherche(arr1) || Cherche(arr2);
                        }
                    }
                    return Cherche(line.Split(" "));
                    sr.Close();
                }
                return false;
            }
        }
    }
}

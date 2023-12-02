using System;

namespace MotsGlissés
{
    class Dictionnaire
    {
        string _chemin;
        public string[][] _lettres;

        public Dictionnaire(string filePath)
        {
            _chemin = filePath;
            if (!File.Exists(filePath))
            {
                Console.WriteLine("ReadFile: file not found");
            }

            else
            {
                string[] readText = File.ReadAllLines(filePath);
                _lettres = new string[26][];
                if(readText.Length != 26) { throw new Exception("Dictionnaire: Invalid file structure"); }
                for(int i = 0; i < readText.Length; i++)
                {
                    _lettres[i] = readText[i].Split(" ");
                }
            }
        }

        public void Sort()
        {
            for(int i = 0; i <  _lettres.Length; i++)
            {
                _lettres[i] = Extras.Fusion(_lettres[i]);
            }
        }

        public bool Exists(string input)
        {
            if (input == null) return false;
            if (input.Length == 0) return false;
            if (!input.All(Char.IsLetter)) return false;
            else
            {
                input = input.ToUpper();
                bool Cherche(string[] tab)
                {
                    if (tab.Length == 0) return false;
                    if (tab.Length == 1) return tab[0] == input;
                    else
                    {
                        (string[] arr1, string[] arr2) = Extras.Split(tab);
                        return Cherche(arr1) && Cherche(arr2);
                    }
                }
                Console.WriteLine(input[0]- 65);
                return Cherche(_lettres[input[0]- 65]);
            }
        }

        
    }
}

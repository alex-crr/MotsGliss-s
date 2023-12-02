﻿using System;

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

                            bool Cherche( int borneInf, int borneSup)
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
    }
}
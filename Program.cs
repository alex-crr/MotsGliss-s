using System;

namespace MotsGlissés
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionnaire dico = new Dictionnaire("Mots_Français.txt");
            dico.Sort();
            foreach(var mot in dico._lettres[2]){
                Console.WriteLine(mot);
            }
            Console.WriteLine(dico.Exists("ojerghpuioahfggh"));
            Console.WriteLine(dico.Exists("cheval"));
        }
    }
}
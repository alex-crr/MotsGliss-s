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
            Console.WriteLine(dico.Exists("ojerghpuioahfggh"));
            Console.WriteLine(dico.Exists("cheval"));
        }
    }
}
using System;
namespace MotsGlissés
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filePath = Path.Combine("..", "..", "..", "Resources", "Mots_Français.txt");
            Dictionnaire dico = new Dictionnaire(filePath);
            dico.Sort(); 
            Console.WriteLine(dico.Exists("ojerghpuioahfggh"));
            Console.WriteLine(dico.Exists("cheval"));
        }
    }
}
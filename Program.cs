﻿using System;
namespace MotsGlissés
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            string filePath = Path.Combine("..", "..", "..", "Resources", "Mots_Français.txt");
            Dictionnaire dico = new Dictionnaire(filePath);
            dico.Tri_Fusion(); 
            Console.WriteLine(dico.RechDichoRecursif("ojerghpuioahfggh"));
            Console.WriteLine(dico.RechDichoRecursif("cheval"));
            Console.WriteLine(dico.toString());*/
            string filePath = Path.Combine("..", "..", "..", "Resources", "TestRight.csv");
            Plateau p = new Plateau(filePath);
            Console.WriteLine(p.toString());
            Console.WriteLine(p.Recherche_Mot("maison"));   
        }
    }
}
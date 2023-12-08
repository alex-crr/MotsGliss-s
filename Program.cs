using System;
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
            Console.WriteLine(dico.toString());
            string filePath = Path.Combine("..", "..", "..", "Resources", "Test1.csv");
            Plateau p = new Plateau(filePath);
            Console.WriteLine(p.toString());
            (bool found, var tits) = p.Recherche_Mot("maison");
            p.Maj_plateau(tits);
            Console.WriteLine(p.toString());*/

            string filePath = Path.Combine("..", "..", "..", "Resources", "Mots_Français.txt");
            Dictionnaire dico = new Dictionnaire(filePath);
            dico.Tri_Fusion(); 
            string filepath = Path.Combine("..", "..", "..", "Resources", "Test1.csv");
            Plateau p = new Plateau(filepath);

            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(new Joueur("Marina"));
            joueurs.Add(new Joueur("Alexandre"));
            TimeSpan tempsjeu = TimeSpan.FromSeconds(60);

            Jeu jeu = new Jeu(dico, p, joueurs, tempsjeu );
            jeu.play();

            


        }
    }
}
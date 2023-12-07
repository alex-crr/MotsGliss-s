using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotsGlissés
{
    public class Jeu
    {
        Dictionnaire dico;
        Plateau plateau;
        Joueur joueur;
        int tempsjoueur ;
        int tempsjeu = 120;

    }
    public Jeu(Dictionnaire dico, Plateau plateau,Joueur joueur, int tempsjoueur)
    {
        this.dico = dico;
        this.plateau1 = plateau;
        this.joueur1 = joueur;
        this.tempsjoueur = tempsjoueur;

    }



    public void play()
    {
        DateTime startGame= DateTime.Now;
        TimeSpan tempsEcoule = TimeSpan.Zero;

        while(tempsEcoule < tempsjeu )
        {
            foreach(Joueur j in joueur)
            {
                Console.WriteLine($"{j.Nom} a toi de jouer !");
                DateTime debuttour = DateTime.Now;
                TimeSpan tempsrestant = tempsjoueur;

            }
        }
    }
}

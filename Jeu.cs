using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotsGlissés
{
    public class Jeu
    {
        private Dictionnaire dico1;
        Plateau plateau1;
        Joueur joueur1;
        int tempsjoueur ;
        int tempsjeu = 120;

    }
    public Jeu(Dictionnaire dico, Plateau plateau1,Joueur joueur1, int tempsjoueur)
    {
        this.dico = dico;
        this.plateau1 = plateau1;
        this.joueur1 = joueur1;
        this.tempsjoueur = tempsjoueur

    }



    public void play()
    {
        DateTime startGame= DateTime.Now;
        TimeSpan tempsEcoule = TimeSpan.Zero;

        while(DateTime.Now -)
    }
}

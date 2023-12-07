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
        TimeSpan tempsjoueur ;
        TimeSpan tempsjeu = (120);

    }
    public Jeu(Dictionnaire dico, Plateau plateau,Joueur joueur, TimeSpan tempsjoueur)
    {
        this.dico = dico;
        this.plateau1 = plateau;
        this.joueur1 = joueur;
        this.tempsjoueur = tempsjoueur;

    }



    public void play()
    {
        DateTime startGame= DateTime.Now;
       DateTime temps = TimeSpan.Zero;

        while(startGame < tempsjeu )
        {
            foreach(Joueur j in joueur)
            {
                Console.WriteLine($"{j.Nom} a toi de jouer !");
                DateTime debuttour = DateTime.Now;
                TimeSpan tempsrestant = tempsjoueur;
                string motcherche = "";
                while(debuttour<tempsrestant && motcherche=="")
                {
                    Console.WriteLine("entre un mot");
                    motcherche = Console.ReadLine();
                    if( motcherche dans dictionnaire et existe dans plateau)
                        {
                            this.joueur.score = addition;
                            supprimer/decaler matrice
                        }
                    else
                    {
                        Console.WriteLine("le mot n'existe pas")
                    }
                }

            }

        }
    }
}

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
        List<Joueur> joueur;
        TimeSpan tempsjoueur ;
        TimeSpan tempsjeu = (120);

    }
    public Jeu(Dictionnaire dico, Plateau plateau,List<Joueur> joueur, TimeSpan tempsjoueur)
    {
        this.dico = dico;
        this.plateau1 = plateau;
        this.joueur = joueur;
        this.tempsjoueur = tempsjoueur;

    }



    public void play()
    {
        DateTime startGame= DateTime.Now;
        DateTime finjeu = startGame.Add(tempsjeu);
        while(startGame < finjeu )
        {
            foreach(Joueur j in joueur)
            {
                Console.WriteLine($"{j.Nom} a toi de jouer !");
                DateTime debuttour = DateTime.Now;
                TimeSpan tempsrestant = tempsjoueur;
                string motcherche = "";
                while(DateTime.Now<debuttour.Add(tempsrestant) && motcherche=="")
                {
                    Console.WriteLine("entre un mot");
                    motcherche = Console.ReadLine();
                    if(dico.RechDichoRecursif(motrecherche) && Joueur.Contient(motcherche) && Plateau.Recherche_Mot(motcherche))
                    {

                        Joueur.Add_Mot(motcherche);
                        joueur.score += ;
                        supprimer / decaler matrice
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MotsGlissés
{
    public class Jeu
    {
        Dictionnaire _dico;
        Plateau _plateau;
        List<Joueur> _joueurs;
        TimeSpan _tempsjoueur;
        TimeSpan tempsjeu = TimeSpan.FromSeconds(120);


        public Jeu(Dictionnaire dico, Plateau plateau, List<Joueur> joueur, TimeSpan tempsjoueur)
        {
            this._dico = dico;
            this._plateau = plateau;
            this._joueurs = joueur;
            this._tempsjoueur = tempsjoueur;

        }



        public void play()
        {
            DateTime startGame = DateTime.Now;
            DateTime finjeu = startGame.Add(tempsjeu);
            while (startGame < finjeu)
            {
                foreach (Joueur j in joueur)
                {
                    Console.WriteLine($"{j.Nom} a toi de jouer !");
                    DateTime debuttour = DateTime.Now;
                    TimeSpan tempsrestant = tempsjoueur;
                    string motcherche = "";
                    while (DateTime.Now < debuttour.Add(tempsrestant) && motcherche == "")
                    {
                        Console.WriteLine("entre un mot");
                        motcherche = Console.ReadLine();
                        if (dico.RechDichoRecursif(motrecherche) && Joueur.Contient(motcherche) && Plateau.Recherche_Mot(motcherche))
                        {

                            _joueur.Add_Mot(motcherche);
                            //joueur.score += ;
                            _plateau.Maj_Plateau(motcherche);
                        }
                        else
                        {
                            Console.WriteLine("le mot n'existe pas");
                        }
                    }

                }
            }
            Console.WriteLine("jeu terminer voici les resultat");
            foreach (Joueur j in _joueurs)
            {
                Console.WriteLine(j.toString);
            }


        }
    }
}

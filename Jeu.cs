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


        /// <summary>
        /// défini le temps de jeu les les resultats
        /// </summary>
        public void play()
        {
            DateTime startGame = DateTime.Now; //temps maintenant
            DateTime finjeu = startGame.Add(tempsjeu);//temps definie au préalable
            while (startGame < finjeu)
            {
                foreach (Joueur j in _joueurs)
                {
                    Console.WriteLine($"{j.Nom} a toi de jouer !");
                    DateTime debuttour = DateTime.Now;
                    TimeSpan tempsrestant = _tempsjoueur;
                    string motcherche = "";
                    while (DateTime.Now < debuttour.Add(tempsrestant) && motcherche == "")
                    {
                        Console.WriteLine("entre un mot");
                        motcherche = Console.ReadLine();
                        if (_dico.RechDichoRecursif(motcherche) && Plateau.Recherche_Mot(motcherche)) //vérifie que le mot existe dans le dictionniaire et sur le plateau
                        {

                            j.Add_Mot(motcherche);
                            for (int i = 0; i < motcherche.Length; i++)
                            {
                                // trouver la fonction
                            }
                            j.Add_Score += ;
                            _plateau.Maj_Plateau(motcherche);
                        }
                        else
                        {
                            Console.WriteLine("le mot n'existe pas");
                        }
                    }

                }
            }
            Console.WriteLine("le jeu est terminer voici les resultat");
            foreach (Joueur j in _joueurs)
            {
                Console.WriteLine(_joueurs[i].toString);
            }
            // for (int i = 0; i < _joueurs.Count; i++) mettre si plus de joueurs
            // { }
            if (_joueurs[0].score > _jouurs[1].score)
                Console.WriteLine(_joueurs[0].Nom + " a gagné");
            else 
                Console.WriteLine(_joueurs[1].Nom +" a gagné");
          
        }

        public Dictionary<char, int> point(string nomfile)
        {
            Dictionary<char,int> ppl = new Dictionary
        }
    }
}

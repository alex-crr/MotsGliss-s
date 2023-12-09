
namespace MotsGlissés
{
    public class Jeu
    {
        Dictionnaire _dico;
        Plateau _plateau;
        List<Joueur> _joueurs;
        TimeSpan _tJoueur;
        TimeSpan tJeu = TimeSpan.FromSeconds(90);


        public Jeu(Dictionnaire dico, Plateau plateau, List<Joueur> joueur, TimeSpan tempsJoueur, TimeSpan tempsJeu)
        {
            this._dico = dico;
            this._plateau = plateau;
            this._joueurs = joueur;
            this._tJoueur = tempsJoueur;
            this.tJeu = tempsJeu;

        }


        /// <summary>
        /// défini le temps de jeu les les resultats
        /// </summary>
        public void play()
        {
            DateTime startGame = DateTime.Now; //temps maintenant
            DateTime endGame = startGame.Add(tJeu);//temps definie au préalable
            while (DateTime.Now < endGame && _plateau.NbLettres > 0)
            {
                foreach (Joueur joueur in _joueurs)
                {
                    Console.WriteLine(_plateau.toString());
                    Console.WriteLine($"{joueur.Nom} a toi de jouer !");
                    {
                        string motCherché = ReadLine(_tJoueur);
                        if (motCherché != null)
                        {
                            //inclure des tests sur l'input 
                            if (joueur.Contient(motCherché))
                            {
                                Console.WriteLine("Le mot a déjà été trouvé, tu passes ton tour");
                            }
                            else if (!_dico.RechDichoRecursif(motCherché))
                            {
                                Console.WriteLine("Le mot n'existe pas, tu passes ton tour");
                            }
                            else
                            {
                                var res = _plateau.Recherche_Mot(motCherché);
                                if (res.Item1)
                                {
                                    _plateau.Maj_Plateau(res.Item2);
                                    joueur.Add_Mot(motCherché);
                                    joueur.Add_Score(_plateau.GetScore(motCherché) + 5);//bonus de 5 pour avoir trouvé un mot
                                }
                                else
                                {
                                    Console.WriteLine("Le mot n'existe pas");
                                }
                            }
                        }
                        else Console.WriteLine("Temps écoulé, tu passes ton tour");

                    }

                }
            }
            Console.WriteLine("Fin de la partie");
            Console.WriteLine($"Résultats :\n - {_joueurs[0].Nom} : {_joueurs[0].Score}\n - {_joueurs[1].Nom} : {_joueurs[1].Score}");
            if (_joueurs[0].Score < _joueurs[1].Score)
            {
                Console.WriteLine($"{_joueurs[1].Nom} a gagné");
            }
            else if (_joueurs[0].Score > _joueurs[1].Score)
            {
                Console.WriteLine($"{_joueurs[0].Nom} a gagné");
            }
            else
            {
                Console.WriteLine("Egalité");
            }
        }
    }
}



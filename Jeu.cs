
namespace MotsGlissés
{
    /// <summary>
    /// Instancation d'un jeu, équivalent à une partie
    /// </summary>
    public class Jeu
    {
        // attributs
        Dictionnaire _dico;
        Plateau _plateau;
        List<Joueur> _joueurs;
        TimeSpan _tJoueur;
        TimeSpan tJeu = TimeSpan.FromSeconds(90);


        // constructeur
        /// <summary>
        /// Instancie le jeu. Sa fonction principal est de run play()
        /// </summary>
        /// <param name="dico">Le dictionnaire qui servira à valider les mots</param>
        /// <param name="plateau">Le plateau</param>
        /// <param name="joueur">Liste des joueurs </param>
        /// <param name="tempsJoueur">Temps maximal autorisé pour qu'un joueur trouve un mot</param>
        /// <param name="tempsJeu">Temps maximal de la partie</param>
        public Jeu(Dictionnaire dico, Plateau plateau, List<Joueur> joueur, TimeSpan tempsJoueur, TimeSpan tempsJeu)
        {
            this._dico = dico;
            this._plateau = plateau;
            this._joueurs = joueur;
            this._tJoueur = tempsJoueur;
            this.tJeu = tempsJeu;

        }

        /// <summary>
        /// Méthode de jeu
        /// </summary>
        public void play()
        {
            DateTime startGame = DateTime.Now; //temps maintenant
            DateTime endGame = startGame.Add(tJeu);//temps definie au préalable
            bool first = true;
            while (DateTime.Now < endGame && _plateau.NbLettres > 0)
            {
                foreach (Joueur joueur in _joueurs)
                {
                    if(!first) Thread.Sleep(1000);
                    first = false;
                    Core.ClearContent();
                    Core.WriteContinuousString(_plateau.toString(), 10, false, 250);
                    Console.WriteLine($"{joueur.Nom} it's your turn to shine !");
                    {
                        string? motCherché = ReadLine(_tJoueur);
                        if (motCherché != null)
                        {
                            //inclure des tests sur l'input 
                            if (joueur.Contient(motCherché))
                            {
                                Console.WriteLine("You've already found this word, you skip your turn ...");
                            }
                            else if (!_dico.RechDichoRecursif(motCherché))
                            {
                                Console.WriteLine("The word you're looking for doesn't exist, you skip your turn ...");
                            }
                            else
                            {
                                var res = _plateau.Recherche_Mot(motCherché);
                                if (res.Item1)
                                {
                                    _plateau.Maj_Plateau(res.Item2);
                                    joueur.Add_Mot(motCherché);
                                    joueur.Add_Score(_plateau.GetScore(motCherché) + 5);//bonus de 5 pour avoir trouvé un mot
                                    Console.WriteLine($"You found the word {motCherché} and earned {_plateau.GetScore(motCherché) + 5} points !");
                                }
                                else
                                {
                                    Console.WriteLine("Too bad, the word you're looking for doesn't exist on the table, you skip your turn ...");
                                }
                            }
                        }
                        else Console.WriteLine("Time's up for you");

                    }

                }
            }
            Thread.Sleep(2000);
            Core.ClearContent();
            Core.WriteContinuousString("Time is up !", 10, false, 500);
            Core.WriteContinuousString("The results are in", 11, false, 500); 
            Core.WritePositionedString($"{_joueurs[0].Nom} has {_joueurs[0].Score}", Placement.Center, default, 12, default);
            Core.WritePositionedString($"{_joueurs[1].Nom} has {_joueurs[1].Score}", Placement.Center, default, 13, default);
            if (_joueurs[0].Score < _joueurs[1].Score)
            {
                Core.WritePositionedString($"{_joueurs[1].Nom} has won", Placement.Center, default, 14, default);
            }
            else if (_joueurs[0].Score > _joueurs[1].Score)
            {
                Core.WritePositionedString($"{_joueurs[0].Nom} has won", Placement.Center, default, 14, default);
            }
            else
            {
                Core.WritePositionedString("It's a tie", Placement.Center, default, 14, default);
            }
            Core.WritePositionedString("Press any key to continue", Placement.Center, default, 15, default);
            Console.ReadKey();
        }
    }
}



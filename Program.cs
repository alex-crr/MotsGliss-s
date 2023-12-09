using System;
namespace MotsGlissés
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.WriteFullScreen("MotGlissé", footer: ("Alexandre COURRIEU", "2023-2024", "Adrien Scazzola"));
            Core.ChangeForeground(ConsoleColor.Blue);
            Core.WriteContinuousString("A long time ago in a galaxy far, far away....", 10);
            Core.ChangeForeground(ConsoleColor.White);
            Core.WriteContinuousString("Nah I'm playing, it's just a game about words", 12);
            Core.ClearMultipleLines(10, 12);


            List<Joueur> joueurs = new List<Joueur>();
            var inputJoueur1 = Core.WritePrompt("How may I call you, Player1? ", "Player1", 10);
            joueurs.Add(new Joueur(inputJoueur1.Item2));
            Core.ClearMultipleLines(10, 12);
            var inputJoueur2 = Core.WritePrompt("How may I call you, Player2?", "Player2", 10);
            joueurs.Add(new Joueur(inputJoueur2.Item2));
            Core.ClearMultipleLines(10, 12);

            var inputTimeGame = Core.ScrollingNumberSelector("How long should the game last?", 30, 180, start: 30, step: 15, line: 10);
            TimeSpan tempsJeu = TimeSpan.FromSeconds(inputTimeGame.Item2);
            var inputTimePlayer = Core.ScrollingNumberSelector("How long should each player have to find a word?", 5, 30, start: 10, step: 5, line: 10);
            TimeSpan tempsJoueur = TimeSpan.FromSeconds(inputTimePlayer.Item2);

            while (true)
            {
                Core.ClearContent();
                var inputGameMode = Core.ScrollingMenuSelector("What do you want to do ?", default, default, "Play from a preloaded file", "Play from a randomly generated file", "Quit");
                Plateau p = new Plateau();
                switch (inputGameMode.Item2)
                {
                    case 0:
                        bool correctPath = false;
                        do
                        {
                            var inputPlateauPath = Core.WritePrompt("Please enter the path to the file you want to play with (leave empty for us to choose)", default, 10);
                            string plateauName = inputPlateauPath.Item2;
                            if (plateauName.Length == 0)
                            {
                                //add randomnness to file selection, see input from teachers
                                plateauName = "Test1.csv";
                            }
                            string plateauPath = Path.Combine("..", "..", "..", "Resources", plateauName);
                            try
                            {
                                p = new Plateau(plateauPath);
                                correctPath = true;
                            }
                            catch (Exception e)
                            {
                                Core.ClearMultipleLines(12, 14);
                                Core.WritePositionedString("The provided file was not found. Hit any key to start again.", Placement.Center, default, 12, default);
                                Console.ReadKey();
                                Core.ClearMultipleLines(12, 14);
                            }
                        } while (!correctPath);
                        break;
                    case 1:
                        p = new Plateau();
                        break;
                    case 2:
                        Core.ExitProgram();
                        break;
                    default:
                        throw new Exception("This should never happen");
                }
                Core.ClearContent();

                string dicoPath = Path.Combine("..", "..", "..", "Resources", "Mots_Français.txt");
                Dictionnaire dico = new Dictionnaire(dicoPath);
                dico.Tri_Fusion();

                Jeu jeu = new Jeu(dico, p, joueurs, tempsJoueur, tempsJeu);
                jeu.play();
            }

        }
    }
}
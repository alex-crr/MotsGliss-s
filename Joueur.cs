using System;
using System.Reflection.Metadata.Ecma335;

namespace MotsGlissés
{
    /// <summary>
    /// Instanciation d'un joueur
    /// </summary>
    public class Joueur
    {
        private string _nom;
        private int _score;
        private List<string> _mots;

<<<<<<< Updated upstream
=======
        /// <summary>
        /// Propriété publique en lecture seule du score du joueur
        /// </summary>
        public int Score => _score;
        /// <summary>
        /// Propriété publique en lecture seule du nom du joueur
        /// </summary>
        public string Nom => _nom;

        /// <summary>
        /// Constructeur simple d'un joueur
        /// </summary>
        /// <param name="nom">Nom assigné au joueur</param>
        public Joueur(string nom)
        {
            this._nom = nom;
            this._score = 0;
            this._mots = new List<string>();
        }

        /// <summary>
        /// Constructeur complet d'un joueur, utilisé pour le debugage
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="score">Score de départ du joueur</param>
        /// <param name="listeMotTrouver">Liste des mots à trouver</param>
>>>>>>> Stashed changes
        public Joueur(string nom, int score, List<string> listeMotTrouver)
        {
            this._nom = nom;
            this._score = score;
            this._mots = listeMotTrouver;
        }

        public string Nom => _nom;

        public void Add_Mot(string mot)
        {
            _mots.Add(mot);
        }

        public string toString()
        {
            return $"nom = {this._nom}\nscore = {this._score}\nLa liste des mots trouvés est : {this._mots}";
        }

        public void Add_Score(int val)
        {
            _score = +val;
        }

        public bool Contient(string mot)
        {
            return _mots.Contains(mot);
        }

    }
}
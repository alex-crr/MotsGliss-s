namespace MotsGlissés
{
    /// <summary>
    /// Classe représentant un joueur
    /// </summary>
    public class Joueur
    {
        // attributs
        private string _nom;
        private int _score;
        private List<string> _mots;

        /// <summary>
        /// Propriété Score en lecture seule
        /// </summary>
        public int Score => _score;
        
        /// <summary>
        /// Propriété Nom en lecture seule
        /// </summary>
        public string Nom => _nom;

        /// <summary>
        /// Cosntructeur simple de la classe Joueur
        /// Tout est mis à 0
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        public Joueur(string nom)
        {
            this._nom = nom;
            this._score = 0;
            this._mots = new List<string>();
        }

        /// <summary>
        /// Constructeur de la classe Joueur
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="score">Score initial du joueur</param>
        /// <param name="listeMotTrouver">Liste initiale des mots trouvés</param>
        public Joueur(string nom, int score, List<string> listeMotTrouver)
        {
            this._nom = nom;
            this._score = score;
            this._mots = listeMotTrouver;
        }

        /// <summary>
        /// Ajoute un mot à la liste des mots trouvés par le joueur, seulement si ce mot n'a pas déjà été trouvé
        /// </summary>
        /// <param name="mot">Mot qu'il faut ajouter à la liste des mots trouvés</param>
        public void Add_Mot(string mot)
        {
            if (!Contient(mot)) _mots.Add(mot);
        }

        /// <summary>
        /// Condense les informations du joueur en une chaine de caractère
        /// </summary>
        /// <returns>La chaîne de caractère représentant le joueur</returns>
        public string toString()
        {
            return $"nom = {this._nom}\nscore = {this._score}\nLa liste des mots trouvés est : {this._mots}";
        }

        /// <summary>
        /// Ajoute un score au score du joueur
        /// Le score est calculé depuis plateau, à partir du poids des lettres et d'un bonus de 5 points pour avoir trouvé un mot
        /// </summary>
        /// <param name="val">Valeur à ajouter</param>
        public void Add_Score(int val)
        {
            _score += val;
        }

        /// <summary>
        /// Test si un mot a déjà été trouvé par le joueur
        /// </summary>
        /// <param name="mot">Le mot qu'on teste</param>
        /// <returns>vrai si le mot a déjà été trouvé, faux sinon</returns>
        public bool Contient(string mot)
        {
            return _mots.Contains(mot);
        }

    }
}



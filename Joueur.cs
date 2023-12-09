namespace MotsGlissés
{
    public class Joueur
    {
        private string _nom;
        private int _score;
        private List<string> _mots;

        public int Score => _score;
        public Joueur(string nom)
        {
            this._nom = nom;
            this._score = 0;
            this._mots = new List<string>();
        }
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
            _score += 
            val;
        }

        public bool Contient(string mot)
        {
            return _mots.Contains(mot);
        }

    }
}



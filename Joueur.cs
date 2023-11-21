﻿using System;

namespace MotsGlissés
{
    class Joueur
    {
        private string _nom;
        private int _score;
        private List<string> _mots;

        public Joueur(string nom, int score, List<string> listeMotTrouver)
        {
            this._nom = nom;
            this._score = score;
            this._mots = listeMotTrouver;
        }

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



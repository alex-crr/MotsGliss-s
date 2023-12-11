namespace TestProject2
{
    class JoueurTest1
    {

        [Test]
        [TestCase("Marina")]
        public void TestName(string input)
        {
            Joueur joueur = new Joueur(input, 0, new List<string>());
            Assert.That(joueur.Nom, Is.EqualTo(input));
        }

        [Test]
        [TestCase("Marina")]
        public void TestScore(string input)
        {
            Joueur joueur = new Joueur(input, 0, new List<string>());
            Assert.That(joueur.Nom, Is.EqualTo(input));
        }

        [Test]
        [TestCase("Marina")]
        public void TestWord(string input)
        {
            Joueur joueur = new Joueur(input, 0, new List<string>());
            Assert.That(joueur.Nom, Is.EqualTo(input));
        }
    }
}

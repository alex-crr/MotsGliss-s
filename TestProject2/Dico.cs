using System;

namespace TestProject2
{
    class Dico
    {
        static string filepath = Path.Combine("..", "..", "..", "..", "Resources", "Mots_Français.txt");
        Dictionnaire dico = new Dictionnaire(filepath);

        [Test]
        [TestCase("cheval", true)]
        public void RechercheDico(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }
    }
}

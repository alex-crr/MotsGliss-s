using System;

namespace TestProject2
{
    class Dico
    {
        static string filepath = Path.Combine("..", "..", "..", "..", "Resources", "Mots_Français.txt");
        Dictionnaire dico = new Dictionnaire(filepath);

        [Test]
        [TestCase("ABRICOT", true)]
        [TestCase("AYITIGHREUQR", false)] // Word starting with 'a'
        public void RechercheDico_A(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("BANANE", true)]  // Word starting with 'b'
        public void RechercheDico_B(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("CITRON", true)]  // Word starting with 'c'
        public void RechercheDico_C(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("DAUPHIN", true)]  // Word starting with 'd'
        public void RechercheDico_D(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("ELEPHANT", true)]  // Word starting with 'e'
        [TestCase("ECHELLE", true)]
        public void RechercheDico_E(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("FRAISE", true)]  // Word starting with 'f'
        public void RechercheDico_F(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("GRENOUILLE", true)]  // Word starting with 'g'
        public void RechercheDico_G(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("HIBOU", true)]  // Word starting with 'h'
        public void RechercheDico_H(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("IGLOO", true)]  // Word starting with 'i'
        public void RechercheDico_I(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("JARDIN", true)]  // Word starting with 'j'
        public void RechercheDico_J(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("KOALA", true)]  // Word starting with 'k'
        public void RechercheDico_K(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("LAMPE", true)]  // Word starting with 'l'
        public void RechercheDico_L(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("MARMOTTE", true)]  // Word starting with 'm'
        public void RechercheDico_M(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("NUAGE", true)]  // Word starting with 'n'
        public void RechercheDico_N(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("ORANGE", true)]  // Word starting with 'o'
        public void RechercheDico_O(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("PAPILLON", true)]  // Word starting with 'p'
        public void RechercheDico_P(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("QUICHE", true)]  // Word starting with 'q'
        public void RechercheDico_Q(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("RENARD", true)]  // Word starting with 'r'
        public void RechercheDico_R(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("SOLEIL", true)]  // Word starting with 's'
        public void RechercheDico_S(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("TIGRE", true)]  // Word starting with 't'
        public void RechercheDico_T(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("UNIFORME", true)]  // Word starting with 'u'
        public void RechercheDico_U(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("VACHE", true)]  // Word starting with 'v'
        public void RechercheDico_V(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("WAGON", true)]  // Word starting with 'w'
        public void RechercheDico_W(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("XYLOPHONE", true)]  // Word starting with 'x'
        public void RechercheDico_X(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("YOGOURT", true)]  // Word starting with 'y'
        public void RechercheDico_Y(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

        [Test]
        [TestCase("ZEBRE", true)]  // Word starting with 'z'
        public void RechercheDico_Z(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }


        [Test]
        [TestCase("", false)]
        public void RechercheDicoEmpty(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.RechDichoRecursif(input)));
        }

    }
}

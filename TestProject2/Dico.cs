using System;

namespace TestProject2
{
    class Dico
    {
        static string filepath = Path.Combine("..", "..", "..", "..", "Resources", "Mots_Français.txt");
        Dictionnaire dico = new Dictionnaire(filepath);

        [Test]
        [TestCase("abricot", true)]  // Word starting with 'a'
        public void RechercheDico_A(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("banane", true)]  // Word starting with 'b'
        public void RechercheDico_B(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("citron", true)]  // Word starting with 'c'
        public void RechercheDico_C(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("dauphin", true)]  // Word starting with 'd'
        public void RechercheDico_D(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("elephant", true)]  // Word starting with 'e'
        [TestCase("echelle", true)]
        public void RechercheDico_E(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("fraise", true)]  // Word starting with 'f'
        public void RechercheDico_F(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("grenouille", true)]  // Word starting with 'g'
        public void RechercheDico_G(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("hibou", true)]  // Word starting with 'h'
        public void RechercheDico_H(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("igloo", true)]  // Word starting with 'i'
        public void RechercheDico_I(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("jardin", true)]  // Word starting with 'j'
        public void RechercheDico_J(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("koala", true)]  // Word starting with 'k'
        public void RechercheDico_K(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("lampe", true)]  // Word starting with 'l'
        public void RechercheDico_L(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("marmotte", true)]  // Word starting with 'm'
        public void RechercheDico_M(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("nuage", true)]  // Word starting with 'n'
        public void RechercheDico_N(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("orange", true)]  // Word starting with 'o'
        public void RechercheDico_O(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("papillon", true)]  // Word starting with 'p'
        public void RechercheDico_P(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("quiche", true)]  // Word starting with 'q'
        public void RechercheDico_Q(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("renard", true)]  // Word starting with 'r'
        public void RechercheDico_R(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("soleil", true)]  // Word starting with 's'
        public void RechercheDico_S(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("tigre", true)]  // Word starting with 't'
        public void RechercheDico_T(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("uniforme", true)]  // Word starting with 'u'
        public void RechercheDico_U(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("vache", true)]  // Word starting with 'v'
        public void RechercheDico_V(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("wagon", true)]  // Word starting with 'w'
        public void RechercheDico_W(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("xylophone", true)]  // Word starting with 'x'
        public void RechercheDico_X(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("yogourt", true)]  // Word starting with 'y'
        public void RechercheDico_Y(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }

        [Test]
        [TestCase("zebre", true)]  // Word starting with 'z'
        public void RechercheDico_Z(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }


        [Test]
        [TestCase("", false)]
        public void RechercheDicoN(string input, bool expected)
        {
            Assert.That(expected, Is.EqualTo(dico.Exists(input)));
        }
    }
}

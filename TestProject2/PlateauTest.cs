using System;

namespace TestProject2
{
    class PlateauTest
    {
        static string filepath = Path.Combine("..", "..", "..", "..", "Resources");

        [Test]
        [TestCase("TestUp.csv")]
        [TestCase("TestUp.csv")]
        [TestCase("TestRight.csv")]
        [TestCase("TestLeft.csv")]
        [TestCase("TestSDiagLeft.csv")]
        [TestCase("TestSDiagRight.csv")]
        [TestCase("TestDiagLeft.csv")]
        [TestCase("TestDiagRight.csv")]
        public void TestBasic(string fileName)
        {
            string àChercher = "maison";
            string file = Path.Combine(filepath, fileName);
            Plateau p = new Plateau(file);
            var res = p.Recherche_Mot(àChercher);
            Assert.That(res.Item1, Is.EqualTo(true));
        }

        [Test]
        [TestCase("TestRetour.csv")]
        public void TestRetour(string fileName){
            string àChercher = "ana";
            string file = Path.Combine(filepath, fileName);
            Plateau p = new Plateau(file);
            var res = p.Recherche_Mot(àChercher);
            Assert.That(res.Item1, Is.EqualTo(false));
        }
    }
}

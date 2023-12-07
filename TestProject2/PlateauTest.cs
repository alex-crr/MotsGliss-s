using System;

namespace TestProject2
{
    class PlateauTest
    {
        static string filepath = Path.Combine("..", "..", "..", "..", "Resources");

        [Test]
        [TestCase( "TestUp.csv", "maison", true)]
        [TestCase( "TestUp.csv", "maison", true)]
        [TestCase( "TestRight.csv", "maison", true)]
        [TestCase( "TestLeft.csv", "maison", true)]
        [TestCase( "TestSDiagLeft.csv", "maison", true)]
        [TestCase( "TestSDiagRight.csv", "maison", true)]
        [TestCase( "TestDiagLeft.csv", "maison", true)]
        [TestCase( "TestDiagRight.csv", "maison", true)]
        public void TestBasic(string fileName, string àChercher, bool expected)
        {
            string file = Path.Combine(filepath, fileName);
            Plateau p = new Plateau(file);
            var res = p.Recherche_Mot(àChercher);
            Assert.That(res.Item1, Is.EqualTo(expected));
        }
    }
}

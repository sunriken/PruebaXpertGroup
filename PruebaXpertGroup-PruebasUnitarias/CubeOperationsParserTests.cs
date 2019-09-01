using NUnit.Framework;
using PruebaXpertGroup.Models;

namespace Tests
{
    public class CubeOperationsParserTests
    {

        private CubeOperationsParser cubeParser;

        [SetUp]
        public void Setup()
        {
            cubeParser = new CubeOperationsParser();
        }

        [Test]
        public void Test1_TextoNulo()
        {
            string texto = null;

            string resultado = cubeParser.ParseCode(texto);

            Assert.AreEqual(resultado, "");

            Assert.Pass();
        }

        [Test]
        public void Test2_TextoEnBlanco()
        {
            string texto = "";

            string resultado = cubeParser.ParseCode(texto);

            Assert.AreEqual(resultado, "");

            Assert.Pass();
        }

        [Test]
        public void Test3_TextoConSintaxisIncorrecta()
        {
            string texto = "mkdslfds uu94jowernk";

            string resultado = cubeParser.ParseCode(texto);

            Assert.IsTrue(resultado.Contains("[ERROR]"));

            Assert.Pass();
        }


        [Test]
        public void Test4_EjecucionNormal()
        {
            string texto =  "2" + "\n" +
                            "4 5" + "\n" +
                            "UPDATE 2 2 2 4" + "\n" +
                            "QUERY 1 1 1 3 3 3" + "\n" +
                            "UPDATE 1 1 1 23" + "\n" +
                            "QUERY 2 2 2 4 4 4" + "\n" + 
                            "QUERY 1 1 1 3 3 3" + "\n" +
                            "2 4" + "\n" +
                            "UPDATE 2 2 2 1" + "\n" +
                            "QUERY 1 1 1 1 1 1" + "\n" +
                            "QUERY 1 1 1 2 2 2" + "\n" +
                            "QUERY 2 2 2 2 2 2";

            string salidaEsperada = "4" + "\n" +
                                    "4" + "\n" +
                                    "27" + "\n" +
                                    "0" + "\n" +
                                    "1" + "\n" +
                                    "1";

            string resultado = cubeParser.ParseCode(texto);

            Assert.IsTrue(resultado.Contains(salidaEsperada));

            Assert.Pass();
        }

        [Test]
        public void Test5_EjecucionProblemasFronteras()
        {
            string texto = "2" + "\n" +
                            "4 5" + "\n" +
                            "UPDATE 20 2 2 4" + "\n" +
                            "QUERY 1 1 556 3 3 3" + "\n" +
                            "UPDATE 1 13 1 23" + "\n" +
                            "QUERY 2 2 2 4 4 4" + "\n" +
                            "QUERY 1 1 1 3 3 3" + "\n" +
                            "2 4" + "\n" +
                            "UPDATE 2 2 2 1" + "\n" +
                            "QUERY 9 1 1 1 1 1" + "\n" +
                            "QUERY 9 1 1 2 2 2" + "\n" +
                            "QUERY 20 2 2 2 2 2";

            string salidaEsperada = "4" + "\n" +
                                    "4" + "\n" +
                                    "27" + "\n" +
                                    "0" + "\n" +
                                    "1" + "\n" +
                                    "1";

            string resultado = cubeParser.ParseCode(texto);

            Assert.IsFalse(resultado.Contains(salidaEsperada));

            Assert.Pass();
        }
    }
}
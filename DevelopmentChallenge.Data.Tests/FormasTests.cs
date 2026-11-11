using System;
using DevelopmentChallenge.Data.Classes.Formas;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class FormasTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void TestCuadradoConLadoInvalido(decimal lado)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Cuadrado(lado));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestCirculoConDiametroInvalido(decimal diametro)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circulo(diametro));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestTrianguloEquilateroConLadoInvalido(decimal lado)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TrianguloEquilatero(lado));
        }

        [TestCase]
        public void TestAreaYPerimetroDelRectangulo()
        {
            var rectangulo = new Rectangulo(2, 3);

            Assert.AreEqual(6m, rectangulo.CalcularArea());
            Assert.AreEqual(10m, rectangulo.CalcularPerimetro());
        }

        [TestCase(0, 3)]
        [TestCase(2, 0)]
        [TestCase(-2, 3)]
        public void TestRectanguloConMedidasInvalidas(decimal ancho, decimal alto)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangulo(ancho, alto));
        }

        [TestCase]
        public void TestAreaYPerimetroDelTrapecio()
        {
            var trapecio = new Trapecio(6, 4, 2);

            Assert.AreEqual(10m, trapecio.CalcularArea());
            Assert.AreEqual(14.47m, Math.Round(trapecio.CalcularPerimetro(), 2));
        }

        [TestCase(0, 4, 2)]
        [TestCase(6, 0, 2)]
        [TestCase(6, 4, 0)]
        public void TestTrapecioConMedidasInvalidas(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Trapecio(baseMayor, baseMenor, altura));
        }

        [TestCase(4, 6)]
        [TestCase(5, 5)]
        public void TestTrapecioConBaseMenorNoMenorQueBaseMayor(decimal baseMayor, decimal baseMenor)
        {
            Assert.Throws<ArgumentException>(() => new Trapecio(baseMayor, baseMenor, 2));
        }
    }
}

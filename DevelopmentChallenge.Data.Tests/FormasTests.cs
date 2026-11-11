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
    }
}

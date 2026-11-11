using System;
using System.Collections.Generic;
using System.Linq;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class TraduccionesTests
    {
        private static IEnumerable<TestCaseData> FormasPorIdioma()
        {
            var tipos = typeof(FormaGeometrica).Assembly.GetTypes().Where(t => !t.IsAbstract && !t.IsInterface).ToList();
            var formas = tipos.Where(t => typeof(FormaGeometrica).IsAssignableFrom(t)).ToList();
            var idiomas = tipos.Where(t => typeof(IIdioma).IsAssignableFrom(t)).ToList();

            return from idioma in idiomas
                   from forma in formas
                   select new TestCaseData(idioma, forma).SetName($"TestTraduccion_{idioma.Name}_{forma.Name}");
        }

        [TestCaseSource(nameof(FormasPorIdioma))]
        public void TestTodasLasFormasEstanTraducidas(Type tipoIdioma, Type tipoForma)
        {
            var idioma = (IIdioma)Activator.CreateInstance(tipoIdioma);

            Assert.IsNotEmpty(idioma.NombreForma(tipoForma, 1));
            Assert.IsNotEmpty(idioma.NombreForma(tipoForma, 2));
        }
    }
}

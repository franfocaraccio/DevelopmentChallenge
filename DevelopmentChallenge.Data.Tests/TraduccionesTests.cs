using System;
using System.Collections.Generic;
using System.Linq;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Idiomas;
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

        [TestCase]
        public void TestFormaExternaSinTraduccion()
        {
            var formas = new List<FormaGeometrica> { new FormaExterna() };

            Assert.Throws<InvalidOperationException>(() => new ReporteFormas(new Castellano()).Imprimir(formas));
        }

        [TestCase]
        public void TestFormaExternaConTraduccionAgregada()
        {
            var formas = new List<FormaGeometrica> { new FormaExterna(), new FormaExterna() };
            var idioma = new Castellano().AgregarForma<FormaExterna>("Forma externa", "Formas externas");

            var resumen = new ReporteFormas(idioma).Imprimir(formas);

            Assert.AreEqual("<h1>Reporte de Formas</h1>2 Formas externas | Area 24 | Perimetro 20 <br/>TOTAL:<br/>2 formas Perimetro 20 Area 24", resumen);
        }

        private class FormaExterna : FormaGeometrica
        {
            public override decimal CalcularArea() => 12;

            public override decimal CalcularPerimetro() => 10;
        }
    }
}

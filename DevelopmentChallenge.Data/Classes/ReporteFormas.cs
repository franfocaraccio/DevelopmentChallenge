using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class ReporteFormas
    {
        private static readonly NumberFormatInfo FormatoNumeros = new NumberFormatInfo { NumberDecimalSeparator = "," };

        private readonly IIdioma _idioma;

        public ReporteFormas(IIdioma idioma)
        {
            _idioma = idioma ?? throw new ArgumentNullException(nameof(idioma));
        }

        public string Imprimir(IEnumerable<FormaGeometrica> formas)
        {
            var lista = formas.ToList();

            if (!lista.Any())
                return $"<h1>{_idioma.ListaVacia}</h1>";

            var sb = new StringBuilder();
            sb.Append($"<h1>{_idioma.TituloReporte}</h1>");

            foreach (var grupo in lista.GroupBy(f => f.GetType()))
            {
                var cantidad = grupo.Count();
                var area = grupo.Sum(f => f.CalcularArea());
                var perimetro = grupo.Sum(f => f.CalcularPerimetro());

                sb.Append($"{cantidad} {_idioma.NombreForma(grupo.Key, cantidad)} | {_idioma.Area} {Formatear(area)} | {_idioma.Perimetro} {Formatear(perimetro)} <br/>");
            }

            sb.Append($"{_idioma.Total}:<br/>");
            sb.Append($"{lista.Count} {_idioma.Formas} ");
            sb.Append($"{_idioma.Perimetro} {Formatear(lista.Sum(f => f.CalcularPerimetro()))} ");
            sb.Append($"{_idioma.Area} {Formatear(lista.Sum(f => f.CalcularArea()))}");

            return sb.ToString();
        }

        private static string Formatear(decimal valor) => valor.ToString("#.##", FormatoNumeros);
    }
}

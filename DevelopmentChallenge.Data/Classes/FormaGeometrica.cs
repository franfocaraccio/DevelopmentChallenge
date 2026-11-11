/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO:
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo.
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Classes.Formas;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        private static readonly Type[] TiposEnReporte =
        {
            typeof(Cuadrado),
            typeof(Circulo),
            typeof(TrianguloEquilatero)
        };

        protected static decimal ValidarMedida(decimal valor, string nombre)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException(nombre, valor, "La medida debe ser mayor a cero.");

            return valor;
        }

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();

        public static string Imprimir(List<FormaGeometrica> formas, IIdioma idioma)
        {
            if (!formas.Any())
                return $"<h1>{idioma.ListaVacia}</h1>";

            var sb = new StringBuilder();
            sb.Append($"<h1>{idioma.TituloReporte}</h1>");

            foreach (var tipo in TiposEnReporte)
            {
                var formasDelTipo = formas.Where(f => f.GetType() == tipo).ToList();
                if (!formasDelTipo.Any())
                    continue;

                var cantidad = formasDelTipo.Count;
                var area = formasDelTipo.Sum(f => f.CalcularArea());
                var perimetro = formasDelTipo.Sum(f => f.CalcularPerimetro());

                sb.Append($"{cantidad} {idioma.NombreForma(tipo, cantidad)} | {idioma.Area} {area:#.##} | {idioma.Perimetro} {perimetro:#.##} <br/>");
            }

            sb.Append($"{idioma.Total}:<br/>");
            sb.Append($"{formas.Count} {idioma.Formas} ");
            sb.Append($"{idioma.Perimetro} {formas.Sum(f => f.CalcularPerimetro()):#.##} ");
            sb.Append($"{idioma.Area} {formas.Sum(f => f.CalcularArea()):#.##}");

            return sb.ToString();
        }
    }
}

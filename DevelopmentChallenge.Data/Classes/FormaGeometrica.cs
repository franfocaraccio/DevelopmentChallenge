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
        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        private static readonly Type[] TiposEnReporte =
        {
            typeof(Cuadrado),
            typeof(Circulo),
            typeof(TrianguloEquilatero)
        };

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                foreach (var tipo in TiposEnReporte)
                {
                    var formasDelTipo = formas.Where(f => f.GetType() == tipo).ToList();

                    sb.Append(ObtenerLinea(
                        formasDelTipo.Count,
                        formasDelTipo.Sum(f => f.CalcularArea()),
                        formasDelTipo.Sum(f => f.CalcularPerimetro()),
                        tipo,
                        idioma));
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(formas.Count + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
                sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + formas.Sum(f => f.CalcularPerimetro()).ToString("#.##") + " ");
                sb.Append("Area " + formas.Sum(f => f.CalcularArea()).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Type tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(Type tipo, int cantidad, int idioma)
        {
            if (tipo == typeof(Cuadrado))
            {
                if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                return cantidad == 1 ? "Square" : "Squares";
            }

            if (tipo == typeof(Circulo))
            {
                if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                return cantidad == 1 ? "Circle" : "Circles";
            }

            if (tipo == typeof(TrianguloEquilatero))
            {
                if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }
    }
}

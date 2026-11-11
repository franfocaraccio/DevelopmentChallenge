using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes.Formas;

namespace DevelopmentChallenge.Data.Classes.Idiomas
{
    public class Ingles : IIdioma
    {
        private static readonly Dictionary<Type, string[]> NombresDeFormas = new Dictionary<Type, string[]>
        {
            { typeof(Cuadrado), new[] { "Square", "Squares" } },
            { typeof(Circulo), new[] { "Circle", "Circles" } },
            { typeof(TrianguloEquilatero), new[] { "Triangle", "Triangles" } }
        };

        public string ListaVacia => "Empty list of shapes!";
        public string TituloReporte => "Shapes report";
        public string Formas => "shapes";
        public string Area => "Area";
        public string Perimetro => "Perimeter";
        public string Total => "TOTAL";

        public string NombreForma(Type tipoForma, int cantidad) => NombresDeFormas[tipoForma][cantidad == 1 ? 0 : 1];
    }
}

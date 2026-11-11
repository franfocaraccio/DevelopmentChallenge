using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes.Formas;

namespace DevelopmentChallenge.Data.Classes.Idiomas
{
    public class Castellano : IIdioma
    {
        private static readonly Dictionary<Type, string[]> NombresDeFormas = new Dictionary<Type, string[]>
        {
            { typeof(Cuadrado), new[] { "Cuadrado", "Cuadrados" } },
            { typeof(Circulo), new[] { "Círculo", "Círculos" } },
            { typeof(TrianguloEquilatero), new[] { "Triángulo", "Triángulos" } }
        };

        public string ListaVacia => "Lista vacía de formas!";
        public string TituloReporte => "Reporte de Formas";
        public string Formas => "formas";
        public string Area => "Area";
        public string Perimetro => "Perimetro";
        public string Total => "TOTAL";

        public string NombreForma(Type tipoForma, int cantidad) => NombresDeFormas[tipoForma][cantidad == 1 ? 0 : 1];
    }
}

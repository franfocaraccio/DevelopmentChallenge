using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes.Formas;

namespace DevelopmentChallenge.Data.Classes.Idiomas
{
    public class Italiano : IIdioma
    {
        private static readonly Dictionary<Type, string[]> NombresDeFormas = new Dictionary<Type, string[]>
        {
            { typeof(Cuadrado), new[] { "Quadrato", "Quadrati" } },
            { typeof(Circulo), new[] { "Cerchio", "Cerchi" } },
            { typeof(TrianguloEquilatero), new[] { "Triangolo", "Triangoli" } },
            { typeof(Rectangulo), new[] { "Rettangolo", "Rettangoli" } },
            { typeof(Trapecio), new[] { "Trapezio", "Trapezi" } }
        };

        public string ListaVacia => "Lista vuota di forme!";
        public string TituloReporte => "Rapporto delle forme";
        public string Formas => "forme";
        public string Area => "Area";
        public string Perimetro => "Perimetro";
        public string Total => "TOTALE";

        public string NombreForma(Type tipoForma, int cantidad) => NombresDeFormas[tipoForma][cantidad == 1 ? 0 : 1];
    }
}

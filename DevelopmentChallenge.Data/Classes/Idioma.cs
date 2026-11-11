using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class Idioma : IIdioma
    {
        private readonly Dictionary<Type, string[]> _nombresDeFormas = new Dictionary<Type, string[]>();

        public abstract string ListaVacia { get; }
        public abstract string TituloReporte { get; }
        public abstract string Formas { get; }
        public abstract string Area { get; }
        public abstract string Perimetro { get; }
        public abstract string Total { get; }

        public Idioma AgregarForma<T>(string singular, string plural) where T : FormaGeometrica
        {
            _nombresDeFormas[typeof(T)] = new[] { singular, plural };
            return this;
        }

        public string NombreForma(Type tipoForma, int cantidad)
        {
            if (!_nombresDeFormas.TryGetValue(tipoForma, out var nombres))
                throw new InvalidOperationException($"El idioma {GetType().Name} no tiene traducción para la forma {tipoForma.Name}.");

            return cantidad == 1 ? nombres[0] : nombres[1];
        }
    }
}

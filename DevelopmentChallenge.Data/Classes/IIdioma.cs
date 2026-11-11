using System;

namespace DevelopmentChallenge.Data.Classes
{
    public interface IIdioma
    {
        string ListaVacia { get; }
        string TituloReporte { get; }
        string Formas { get; }
        string Area { get; }
        string Perimetro { get; }
        string Total { get; }

        string NombreForma(Type tipoForma, int cantidad);
    }
}

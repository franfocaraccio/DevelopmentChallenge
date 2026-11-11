using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public decimal Lado { get; }

        public TrianguloEquilatero(decimal lado)
        {
            Lado = ValidarMedida(lado, nameof(lado));
        }

        public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;

        public override decimal CalcularPerimetro() => Lado * 3;
    }
}

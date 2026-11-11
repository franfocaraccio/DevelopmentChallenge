using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Circulo : FormaGeometrica
    {
        public decimal Diametro { get; }

        public Circulo(decimal diametro)
        {
            Diametro = diametro;
        }

        public override decimal CalcularArea() => (decimal)Math.PI * (Diametro / 2) * (Diametro / 2);

        public override decimal CalcularPerimetro() => (decimal)Math.PI * Diametro;
    }
}

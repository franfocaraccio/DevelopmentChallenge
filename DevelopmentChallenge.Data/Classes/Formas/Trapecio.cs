using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Trapecio : FormaGeometrica
    {
        public decimal BaseMayor { get; }
        public decimal BaseMenor { get; }
        public decimal Altura { get; }

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            BaseMayor = ValidarMedida(baseMayor, nameof(baseMayor));
            BaseMenor = ValidarMedida(baseMenor, nameof(baseMenor));
            Altura = ValidarMedida(altura, nameof(altura));

            if (BaseMenor >= BaseMayor)
                throw new ArgumentException("La base menor debe ser menor que la base mayor.", nameof(baseMenor));
        }

        public decimal Lado
        {
            get
            {
                var proyeccion = (BaseMayor - BaseMenor) / 2;
                return (decimal)Math.Sqrt((double)(Altura * Altura + proyeccion * proyeccion));
            }
        }

        public override decimal CalcularArea() => (BaseMayor + BaseMenor) / 2 * Altura;

        public override decimal CalcularPerimetro() => BaseMayor + BaseMenor + 2 * Lado;
    }
}

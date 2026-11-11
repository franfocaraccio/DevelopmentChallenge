namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Cuadrado : FormaGeometrica
    {
        public decimal Lado { get; }

        public Cuadrado(decimal lado)
        {
            Lado = ValidarMedida(lado, nameof(lado));
        }

        public override decimal CalcularArea() => Lado * Lado;

        public override decimal CalcularPerimetro() => Lado * 4;
    }
}

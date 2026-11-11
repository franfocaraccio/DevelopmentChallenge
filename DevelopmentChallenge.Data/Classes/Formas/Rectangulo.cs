namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Rectangulo : FormaGeometrica
    {
        public decimal Ancho { get; }
        public decimal Alto { get; }

        public Rectangulo(decimal ancho, decimal alto)
        {
            Ancho = ValidarMedida(ancho, nameof(ancho));
            Alto = ValidarMedida(alto, nameof(alto));
        }

        public override decimal CalcularArea() => Ancho * Alto;

        public override decimal CalcularPerimetro() => 2 * (Ancho + Alto);
    }
}

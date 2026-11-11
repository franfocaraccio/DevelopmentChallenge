using DevelopmentChallenge.Data.Classes.Formas;

namespace DevelopmentChallenge.Data.Classes.Idiomas
{
    public class Castellano : Idioma
    {
        public Castellano()
        {
            AgregarForma<Cuadrado>("Cuadrado", "Cuadrados");
            AgregarForma<Circulo>("Círculo", "Círculos");
            AgregarForma<TrianguloEquilatero>("Triángulo", "Triángulos");
            AgregarForma<Rectangulo>("Rectángulo", "Rectángulos");
            AgregarForma<Trapecio>("Trapecio", "Trapecios");
        }

        public override string ListaVacia => "Lista vacía de formas!";
        public override string TituloReporte => "Reporte de Formas";
        public override string Formas => "formas";
        public override string Area => "Area";
        public override string Perimetro => "Perimetro";
        public override string Total => "TOTAL";
    }
}

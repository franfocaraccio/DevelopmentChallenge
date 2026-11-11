using DevelopmentChallenge.Data.Classes.Formas;

namespace DevelopmentChallenge.Data.Classes.Idiomas
{
    public class Ingles : Idioma
    {
        public Ingles()
        {
            AgregarForma<Cuadrado>("Square", "Squares");
            AgregarForma<Circulo>("Circle", "Circles");
            AgregarForma<TrianguloEquilatero>("Triangle", "Triangles");
            AgregarForma<Rectangulo>("Rectangle", "Rectangles");
            AgregarForma<Trapecio>("Trapezoid", "Trapezoids");
        }

        public override string ListaVacia => "Empty list of shapes!";
        public override string TituloReporte => "Shapes report";
        public override string Formas => "shapes";
        public override string Area => "Area";
        public override string Perimetro => "Perimeter";
        public override string Total => "TOTAL";
    }
}

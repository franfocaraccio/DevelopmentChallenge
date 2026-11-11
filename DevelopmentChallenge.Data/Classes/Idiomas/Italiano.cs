using DevelopmentChallenge.Data.Classes.Formas;

namespace DevelopmentChallenge.Data.Classes.Idiomas
{
    public class Italiano : Idioma
    {
        public Italiano()
        {
            AgregarForma<Cuadrado>("Quadrato", "Quadrati");
            AgregarForma<Circulo>("Cerchio", "Cerchi");
            AgregarForma<TrianguloEquilatero>("Triangolo", "Triangoli");
            AgregarForma<Rectangulo>("Rettangolo", "Rettangoli");
            AgregarForma<Trapecio>("Trapezio", "Trapezi");
        }

        public override string ListaVacia => "Lista vuota di forme!";
        public override string TituloReporte => "Rapporto delle forme";
        public override string Formas => "forme";
        public override string Area => "Area";
        public override string Perimetro => "Perimetro";
        public override string Total => "TOTALE";
    }
}

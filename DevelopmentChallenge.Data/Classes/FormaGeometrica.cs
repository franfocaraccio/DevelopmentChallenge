/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO:
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo.
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        protected static decimal ValidarMedida(decimal valor, string nombre)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException(nombre, valor, "La medida debe ser mayor a cero.");

            return valor;
        }

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();
    }
}

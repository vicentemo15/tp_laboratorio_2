using System;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepcion de sin profesor con mensaje por defecto
        /// </summary>
        public SinProfesorException() : base("No hay Profesor para la clase.")
        {
        }

        /// <summary>
        /// Excepcion de sin profesor  con mensaje
        /// </summary>
        /// <param name="message"></param>
        public SinProfesorException(string message) : base(message)
        {
        }
    }
}

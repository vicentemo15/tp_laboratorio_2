using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion de alumno repetido con mensaje por defecto
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {
        }

        /// <summary>
        /// Excepcion de alumno repetido con mensaje
        /// </summary>
        /// <param name="message"></param>
        public AlumnoRepetidoException(string message) : base(message)
        {
        }
    }
}
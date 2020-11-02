using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Excepcion de formato de DNI con mensaje por defecto
        /// </summary>
        public DniInvalidoException() : base("Formato de DNI incorrecto")
        {
        }

        /// <summary>
        /// Excepcion de formato de DNI con mensaje de excepcion
        /// </summary>
        /// <param name="e"> Excepcion </param>
        public DniInvalidoException(Exception e) : base(e.ToString())
        {
        }

        /// <summary>
        /// Excepcion de formato de DNI con mensaje
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message)
        {
        }

        /// <summary>
        /// Excepcion de formato de DNI con mensaje y excepcion
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : this(message + e.ToString())
        {
        }
    }
}
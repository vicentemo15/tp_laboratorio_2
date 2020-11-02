using System;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepcion de formato de Nacionalidad con mensaje por defecto
        /// </summary>
        public NacionalidadInvalidaException() : base("La Nacionalidad no coincide con el numero de DNI")
        {
        }

        /// <summary>
        /// Excepcion de formato de Nacionalidad con mensaje
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
    }
}
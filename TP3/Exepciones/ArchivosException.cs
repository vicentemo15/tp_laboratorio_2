using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepcion de archivo con mensaje por defecto
        /// </summary>
        public ArchivosException() : base("Error de archivo")
        {
        }

        /// <summary>
        /// Excepcion de archivo  con mensaje
        /// </summary>
        /// <param name="message"></param>
        public ArchivosException(string message) : base(message)
        {
        }

        /// <summary>
        /// Excepcion de archivo  con exception
        /// </summary>
        /// <param name="e"></param>
        public ArchivosException(Exception e) : base(e.ToString())
        {
        }
    }
}
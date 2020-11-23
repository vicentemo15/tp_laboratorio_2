using System;

namespace Entidades
{
    /// <summary>
    /// Excepcion lanzara si hay un error al manipular un archivo.
    /// </summary>
    public class ErrorArchivoException : Exception
    {
        #region CONSTRUCTORES
        public ErrorArchivoException() : base("Error al intentar guardar o leer el archivo.")
        {
        }

        public ErrorArchivoException(string message) : base(message)
        {
        }
        #endregion
    }
}

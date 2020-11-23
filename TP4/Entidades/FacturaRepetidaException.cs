using System;

namespace Entidades
{
    /// <summary>
    /// Excepcion lanzara si ya existe una factura con el mismo numero.
    /// </summary>
    public class FacturaRepetidaException : Exception
    {
        #region CONSTRUCTORES
        public FacturaRepetidaException() : base("La factura ya ha sido emitida.")
        {
        }

        public FacturaRepetidaException(string message) : base(message)
        {
        }
        #endregion
    }
}

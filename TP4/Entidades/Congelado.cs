using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene los datos del producto tipo Congelado
    /// </summary>
    public class Congelado : Producto
    {
        #region ATRIBUTOS
        public DateTime vencimiento;
        #endregion

        #region PROPIEDADES
        public override bool TieneDescuento { get { return false; } }
        #endregion

        #region CONSTRUCTORES
        public Congelado() : base()
        {
        }

        public Congelado(int id, string nombre, string marca, double precioUnitario, DateTime vencimiento) : base(id, nombre, marca, precioUnitario)
        {
            this.vencimiento = vencimiento;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Devuelve la cadena con los datos del producto tipo congelado
        /// </summary>
        /// <returns>Datos del producto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}\nVencimiento: {1}\nDescuento: {2}", base.ToString(), this.vencimiento.ToString("dd-MM-yyyy"), (this.TieneDescuento) ? "SI" : "NO");
            return sb.ToString();
        }
        #endregion
    }
}
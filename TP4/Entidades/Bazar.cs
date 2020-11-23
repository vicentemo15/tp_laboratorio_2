using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene los datos del producto tipo Bazar
    /// </summary>
    public class Bazar : Producto
    {
        #region ATRIBUTOS
        public EMaterial material;
        #endregion

        #region ENUMERADOS
        public enum EMaterial
        {
            Plastico,
            Vidrio,
            Madera
        }
        #endregion

        #region PROPIEDADES
        public override bool TieneDescuento { get { return true; } }
        #endregion

        #region CONSTRUCTORES
        public Bazar() : base()
        {
        }

        public Bazar(int id, string nombre, string marca, double precioUnitario, EMaterial material) : base(id, nombre, marca, precioUnitario)
        {
            this.material = material;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Devuelve la cadena con los datos del producto tipo bazar
        /// </summary>
        /// <returns>Datos del producto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}\nMaterial: {1}\nDescuento: {2}", base.ToString(), this.material, (this.TieneDescuento) ? "SI" : "NO");
            return sb.ToString();
        }
        #endregion
    }
}
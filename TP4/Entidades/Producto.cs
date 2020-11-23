using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene los datos generales del producto
    /// </summary>
    [XmlInclude(typeof(Congelado))]
    [XmlInclude(typeof(Bazar))]
    public abstract class Producto
    {
        #region ATRIBUTOS
        public int id;
        public string nombre;
        public string marca;
        public double precioUnitario;
        #endregion

        #region PROPIEDADES
        public abstract bool TieneDescuento { get; }
        #endregion

        #region CONSTRUCTORES
        public Producto()
        {
        }

        public Producto(int id, string nombre, string marca, double precioUnitario) : this()
        {
            this.id = id;
            this.nombre = nombre;
            this.marca = marca;
            this.precioUnitario = precioUnitario;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Devuelve la cadena con los datos del producto
        /// </summary>
        /// <returns>Datos del producto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Id: {0}\nNombre: {1}\nMarca: {2}\nPrecio Unitario: {3}", this.id, this.nombre, this.marca, this.precioUnitario);

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si poseen el mismo ID.
        /// </summary>
        /// <param name="p1"> Producto 1 </param>
        /// <param name="p2"> Producto 2 </param>
        /// <returns>true si los productos son iguales</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1.id == p2.id;
        }

        /// <summary>
        /// Dos productos son distintos si poseen distinto ID.
        /// </summary>
        /// <param name="p1"> Producto 1 </param>
        /// <param name="p2"> Producto 2 </param>
        /// <returns>true si los productos son distintos</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Override del metodo Equals para productos.
        /// </summary>
        /// <param name="p"> Objeto a comparar</param>
        /// <returns>true si los productos son iguales</returns>
        public override bool Equals(object p)
        {
            if (p != null && p is Producto producto && producto == this)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
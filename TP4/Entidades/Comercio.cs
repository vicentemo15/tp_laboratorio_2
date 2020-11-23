using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene la lista de ventas y lista de hilos que procesan las ventas
    /// </summary>
    public class Comercio
    {
        #region ATRIBUTOS
        private List<Thread> thVentas;
        private List<Venta<Producto>> ventas;
        #endregion

        #region PROPIEDADES
        public List<Venta<Producto>> Ventas
        {
            get { return this.ventas; }
        }
        #endregion

        #region CONSTRUCTORES
        public Comercio()
        {
            this.thVentas = new List<Thread>();
            this.ventas = new List<Venta<Producto>>();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Finaliza todos los hilos activos al finalizar la aplicacion
        /// </summary>
        /// <returns></returns>
        public void FinalizarVentas()
        {
            if (this.thVentas != null)
            {
                foreach (Thread item in this.thVentas)
                {
                    if (item.IsAlive)
                    {
                        item.Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Devuelve la cadena con los datos de las ventas agregadas
        /// </summary>
        /// <returns>Datos de las ventas</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LISTADO DE VENTAS:\n");

            foreach (Venta<Producto> v in this.ventas)
            {
                sb.AppendFormat("{0}\n***************\n", v.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga que agrega una venta al comercio. Inserta la venta en la base y crea el hilo que procesa dicha venta.
        /// Si la venta ya existe, genera una excepcion.
        /// </summary>
        /// <param name="c"> Comercio </param>
        /// <param name="v"> Venta </param>
        /// <returns>Comercio con la venta enlistada</returns>
        public static Comercio operator +(Comercio c, Venta<Producto> v)
        {
            if (!Equals(c, null) && !Equals(v, null))
            {
                foreach (Venta<Producto> item in c.ventas)
                {
                    if (item == v)
                    {
                        throw new FacturaRepetidaException("La factura " + item.factura + " ya ha sido emitida.");
                    }
                }

                BaseDatos.InsertarVenta(v);
                c.ventas.Add(v);

                Thread newThread = new Thread(v.ProcesarVenta);
                c.thVentas.Add(newThread);
                newThread.Start();
            }

            return c;
        }
        #endregion
    }
}
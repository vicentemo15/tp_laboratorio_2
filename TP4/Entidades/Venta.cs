using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entidades
{
    /// <summary>
    /// Clase generica que representa la venta con sus datos y la lista de productos
    /// </summary>
    public class Venta<T> where T : Producto
    {
        #region ATRIBUTOS
        protected List<T> productos;
        protected EEstado estado;
        protected DateTime fechaVenta;
        public ECaja caja;
        public int factura;
        public string cliente;
        #endregion

        #region ENUMERADOS
        public enum EEstado
        {
            Iniciada,
            Procesando,
            Finalizada
        }

        public enum ECaja
        {
            CajaUno,
            CajaDos,
            CajaTres
        }
        #endregion

        #region PROPIEDADES
        public List<T> Productos { get { return this.productos; } }

        public EEstado Estado { get { return this.estado; } }

        public DateTime FechaVenta { get { return this.fechaVenta; } }

        public double TotalVenta
        {
            get
            {
                double total = 0;
                foreach (T item in productos)
                {
                    total += item.precioUnitario;
                }

                return total;
            }
        }
        #endregion

        #region DELEGADOS
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region EVENTOS
        public event DelegadoEstado CambioEstado;
        #endregion

        #region CONSTRUCTORES
        public Venta()
        {
            this.estado = EEstado.Iniciada;
            productos = new List<T>();
            this.fechaVenta = DateTime.Now;
        }

        public Venta(int factura, string cliente, ECaja caja) : this()
        {
            this.factura = factura;
            this.cliente = cliente;
            this.caja = caja;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo que sera llamado ejecutado en el hilo y sera el encargado de actualizar el estado de la venta.
        /// El cambio de estado es una simulacion, automaticamente se cambia al siguiente estado luego de 3 segundos.
        /// Cuando la venta se cambia de estado, el evento CambioEstado (delegado) es llamado y se realizaran las actualizaciones
        /// en la interfaz grafica y base de datos asi como logs.
        /// Se le envia al evento la venta.
        /// </summary>
        /// <returns></returns>
        public void ProcesarVenta()
        {
            try
            {
                Thread.Sleep(1000);
                this.CambioEstado(this, EventArgs.Empty);
                while (this.estado != EEstado.Finalizada)
                {
                    if (this.estado == EEstado.Iniciada)
                    {
                        Thread.Sleep(3000);
                        this.estado = EEstado.Procesando;                        
                    }
                    else
                    {
                        Thread.Sleep(3000);
                        this.estado = EEstado.Finalizada;
                    }

                    this.CambioEstado(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Devuelve la cadena con los datos de la venta y productos
        /// </summary>
        /// <returns>Datos de la venta</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("FACTURA NRO: {0}\nFecha emisión: {1}\nCliente: {2}\nCaja: {3}\nEstado: {4}\nLISTADO DE PRODUCTOS:\n\n", this.factura, this.fechaVenta.ToString("dd-MM-yyyy"), this.cliente, this.caja.ToString(), this.estado.ToString());

            foreach (Producto p in this.productos)
            {
                sb.AppendFormat("{0}\n---------------\n", p.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga que agrega un producto a la venta
        /// </summary>
        /// <param name="v"> Venta </param>
        /// <param name="p"> Producto </param>
        /// <returns>Venta con el producto agregado</returns>
        public static Venta<T> operator +(Venta<T> v, T p)
        {
            v.productos.Add(p);
            return v;
        }

        /// <summary>
        /// Dos ventas son iguales si tienen el mismo numero de factura
        /// </summary>
        /// <param name="v1"> Venta 1 </param>
        /// <param name="v2"> Venta 2 </param>
        /// <returns>true si las ventas son iguales</returns>
        public static bool operator ==(Venta<T> v1, Venta<T> v2)
        {
            return v1.factura == v2.factura;
        }

        /// <summary>
        /// Dos ventas son distintas si tienen distintos numero de factura
        /// </summary>
        /// <param name="v1"> Venta 1 </param>
        /// <param name="v2"> Venta 2 </param>
        /// <returns>true si las ventas son distintas</returns>
        public static bool operator !=(Venta<T> v1, Venta<T> v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Override del metodo Equals para ventas.
        /// </summary>
        /// <param name="v"> Objeto a comparar</param>
        /// <returns>true si las ventas son iguales</returns>
        public override bool Equals(object v)
        {
            if (v != null && v is Venta<T> venta && venta == this)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
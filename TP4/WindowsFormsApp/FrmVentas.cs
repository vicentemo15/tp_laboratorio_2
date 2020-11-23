using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    /// <summary>
    /// Formulario principal de ventas
    /// </summary>
    public partial class FrmVentas : Form
    {
        #region ATRIBUTOS
        private Comercio comercio;
        private DataTable dtVentas;
        #endregion

        #region CONSTRUCTORES
        public FrmVentas()
        {
            InitializeComponent();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo LOAD del formulario. Genera el comercio y data table para ventas.
        /// </summary>
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            Logger.CrearArchivo();
            this.comercio = new Comercio();

            this.dtVentas = new DataTable("Ventas");
            this.dtVentas.Columns.Add("Factura", typeof(int));
            this.dtVentas.Columns.Add("Fecha", typeof(DateTime));
            this.dtVentas.Columns.Add("Cliente", typeof(string));
            this.dtVentas.Columns.Add("Total", typeof(double));
            this.dtVentas.Columns.Add("Estado", typeof(string));
            dgvVentas.DataSource = this.dtVentas;
        }

        /// <summary>
        /// Obtiene datos del log y setea el string al texto del rich text box
        /// </summary>
        private void btnLogs_Click(object sender, EventArgs e)
        {
            try
            {
                rtbVenta.Text = Logger.Leer();
            }
            catch (ErrorArchivoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        /// <summary>
        /// Genera un nuevo exportador para ventas y guarda en el escritorio el archivo XML con todas las ventas generadas
        /// </summary>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador<List<Venta<Producto>>> exp = new Exportador<List<Venta<Producto>>>();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ventas.xml";

            try
            {
                if(comercio.Ventas.Count > 0)
                {
                    exp.Exportar(archivo, comercio.Ventas);
                    MessageBox.Show("Se han exportado las ventas correctamente al archivo " + archivo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay ventas generadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ErrorArchivoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el formulario para generar una nueva venta, obtiene la venta y luego lo agrega al data table de ventas
        /// </summary>
        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            FrmNuevaVenta frmNuevaVenta = new FrmNuevaVenta();

            frmNuevaVenta.ShowDialog();

            Venta<Producto> venta = frmNuevaVenta.VentaRealizada;
            if(!object.Equals(venta, null))
            {
                venta.CambioEstado += venta_EventoCambioEstado;
                try
                {
                    comercio += venta;
                    DataRow fila = this.dtVentas.Rows.Add();
                    fila.SetField(0, venta.factura);
                    fila.SetField(1, venta.FechaVenta);
                    fila.SetField(2, venta.cliente);
                    fila.SetField(3, venta.TotalVenta);
                    fila.SetField(4, venta.Estado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
            }
        }

        /// <summary>
        /// Evento ejecutado cuando la venta cambie de estado.
        /// Actualiza el estado de la venta en el data table
        /// Guarda el cambio de estado en el log
        /// Guarda el nuevo estado en la base de datos
        /// </summary>
        private void venta_EventoCambioEstado(object sender, EventArgs e)
        {
            Venta<Producto> v = sender as Venta<Producto>;

            foreach (DataRow fila in this.dtVentas.Rows)
            {
                int id;

                if(Int32.TryParse(fila["Factura"].ToString(), out id))
                {
                    if (id == v.factura)
                    {
                        fila.SetField(4, v.Estado);
                    }
                }
            }

            try
            {
                Logger.Guardar("La venta " + v.factura + " cambio de estado a " + v.Estado);
                BaseDatos.ActualizarEstadoVenta(v);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga en el rich text box el detalle de la venta seleccionada en la grilla
        /// </summary>
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if(dgvVentas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvVentas.SelectedRows[0];
                int factura = int.Parse(fila.Cells[0].Value.ToString());

                foreach (Venta<Producto> venta in comercio.Ventas)
                {
                    if(venta.factura == factura)
                    {
                        rtbVenta.Text = venta.ToString();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Finaliza los hilos en ejecucion al cerrar el formulario principal.
        /// </summary>
        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.comercio.FinalizarVentas();
        }
        #endregion
    }
}
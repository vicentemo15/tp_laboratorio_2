using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
using static Entidades.Bazar;
using static Entidades.Venta<Entidades.Producto>;

namespace WindowsFormsApp
{
    /// <summary>
    /// Formulario para generar nueva venta
    /// </summary>
    public partial class FrmNuevaVenta : Form
    {
        #region ATRIBUTOS
        private DataTable dtProductos;
        private DataTable dtProductosVenta;
        private Venta<Producto> venta;
        #endregion

        #region PROPIEDADES
        public Venta<Producto> VentaRealizada 
        { 
            get 
            { 
                return this.venta;  
            } 
        }
        #endregion

        #region CONSTRUCTORES
        public FrmNuevaVenta()
        {
            InitializeComponent();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Evento Load de formulario. Genera Datasource de los controles y el data table para los productos vendidos
        /// </summary>
        private void FrmNuevaVenta_Load(object sender, EventArgs e)
        {
            this.dtProductos = BaseDatos.ObtenerProductos();
            cmbProductos.DataSource = this.dtProductos;
            cmbProductos.DisplayMember = "Nombre";
            cmbCajas.SelectedIndex = 0;

            this.dtProductosVenta = new DataTable("ProductoaVenta");
            this.dtProductosVenta.Columns.Add("Id", typeof(int));
            this.dtProductosVenta.Columns.Add("Nombre", typeof(string));
            this.dtProductosVenta.Columns.Add("Marca", typeof(string));
            this.dtProductosVenta.Columns.Add("PrecioUnitario", typeof(double));
            this.dtProductosVenta.Columns.Add("Tipo", typeof(string));
            this.dtProductosVenta.Columns.Add("Material", typeof(string));
            this.dtProductosVenta.Columns.Add("FechaVencimiento", typeof(DateTime));
            dgvProductos.DataSource = this.dtProductosVenta;
        }

        /// <summary>
        /// Agrega el producto seleccionado a la grilla y actualiza el total de la factura.
        /// </summary>
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)cmbProductos.SelectedItem).Row;
            dtProductosVenta.ImportRow(fila);
            ActualizarTotalFactura();
        }

        /// <summary>
        /// Recorre el data table de los productos vendidos y calcula el total de la factura.
        /// </summary>
        private void ActualizarTotalFactura()
        {
            double total = 0;
            foreach (DataRow item in dtProductosVenta.Rows)
            {
                total += double.Parse(item["PrecioUnitario"].ToString());
            }

            lblTotal.Text = total.ToString("$ 0.00");    
        }

        /// <summary>
        /// Chequea datos del formulario
        /// Genera el atributo venta con todos los datos y la lista de productos a partir de la grilla
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFactura.Text) ||
                string.IsNullOrWhiteSpace(txtCliente.Text) ||
                cmbCajas.SelectedIndex == -1 ||
                dtProductosVenta.Rows.Count == 0)
            {
                MessageBox.Show("Por favor complete todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                this.venta = new Venta<Producto>();
                venta.factura = int.Parse(txtFactura.Text);
                venta.cliente = txtCliente.Text;
                venta.caja = (ECaja)Enum.Parse(typeof(ECaja), cmbCajas.SelectedIndex.ToString());

                foreach (DataRow item in dtProductosVenta.Rows)
                {
                    int id = int.Parse(item["Id"].ToString());
                    string nombre = item["Nombre"].ToString();
                    string marca = item["Marca"].ToString();
                    double precio = double.Parse(item["PrecioUnitario"].ToString());
                    string tipo = item["Tipo"].ToString();
                    EMaterial material;
                    DateTime vencimiento;
                    if(tipo == "Congelado")
                    {
                        vencimiento = DateTime.Parse(item["FechaVencimiento"].ToString());
                        Congelado c = new Congelado(id, nombre, marca, precio, vencimiento);
                        venta += c;
                    }
                    else
                    {
                        material = (EMaterial)Enum.Parse(typeof(EMaterial), item["Material"].ToString());
                        Bazar b = new Bazar(id, nombre, marca, precio, material);
                        venta += b;
                    }
                }

                this.Close();
            }
        }
        #endregion
    }
}
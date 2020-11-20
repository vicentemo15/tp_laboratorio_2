using Entidades.Clases;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        //CONSTRUCTOR DE FORMULARIO
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        //EVENTO CLICK CLOSE CERRAR CALCULADORA.
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        //EVENTO CLICK BOTON OPERAR, realiza operacion entre los operandos
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumero1.Text) &&
               !string.IsNullOrEmpty(txtNumero1.Text) &&
               !string.IsNullOrEmpty(cmbOperador.Text))
            {
                double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
                lblResultado.Text = resultado.ToString();
            }
        }

        //EVENTO CLICK BOTON LIMPIAR, limpia Formulario
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        //EVENTO CLICK BOTON CERRAR, cierra formulario.
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //EVENTO CLICK BOTON CONVERTIR A BINARIO.
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            lblResultado.Text = numero1.DecimalBinario(lblResultado.Text);
        }

        //EVENTO CLICK BOTON CONVERTIR A DECIMAL.
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            lblResultado.Text = numero1.BinarioDecimal(lblResultado.Text);
        }

        /// <summary>
        /// El metodo recibira los dos números y el operador para luego llamar al método Operar de Calculadora y retornar el resultado
        /// </summary>
        /// <param name="numero1">Tomado del TextBox1</param>
        /// <param name="numero2">Tomado del TextBox2</param>
        /// <param name="operador">Tomado del ComboBox, operador de calculo</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero operando1 = new Numero(numero1);
            Numero operando2 = new Numero(numero2);
            return Calculadora.Operar(operando1, operando2, operador);
        }

        /// <summary>
        /// borra los datos de los TextBox, ComboBox y Label del formulario
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = string.Empty;
        }
    }
}

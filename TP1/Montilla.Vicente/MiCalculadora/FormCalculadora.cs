using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNumero1.Text) && 
               !string.IsNullOrEmpty(txtNumero1.Text) &&
               !string.IsNullOrEmpty(cmbOperador.Text))
            {
                double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
                lblResultado.Text = resultado.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = string.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            lblResultado.Text = numero1.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            lblResultado.Text = numero1.BinarioDecimal(lblResultado.Text);
        }

        private static double Operar(string numero1, string numero2, string operador) 
        {
            Numero operando1 = new Numero(numero1);
            Numero operando2= new Numero(numero2);
            return Calculadora.Operar(operando1, operando2, operador);
        }


    }

    
}

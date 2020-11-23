
namespace WindowsFormsApp
{
    partial class FrmNuevaVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFactura = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cmbCajas = new System.Windows.Forms.ComboBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.MaskedTextBox();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.lblProductos = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.lblTotalFactura = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Location = new System.Drawing.Point(11, 9);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(46, 13);
            this.lblFactura.TabIndex = 0;
            this.lblFactura.Text = "Factura:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(11, 45);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(83, 42);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(238, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // cmbCajas
            // 
            this.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCajas.FormattingEnabled = true;
            this.cmbCajas.Items.AddRange(new object[] {
            "Caja1",
            "Caja2",
            "Caja3"});
            this.cmbCajas.Location = new System.Drawing.Point(83, 79);
            this.cmbCajas.Name = "cmbCajas";
            this.cmbCajas.Size = new System.Drawing.Size(90, 21);
            this.cmbCajas.TabIndex = 3;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(11, 82);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(34, 13);
            this.lblCaja.TabIndex = 5;
            this.lblCaja.Text = "Caja: ";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(83, 6);
            this.txtFactura.Mask = "00000000";
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFactura.Size = new System.Drawing.Size(56, 20);
            this.txtFactura.TabIndex = 1;
            // 
            // cmbProductos
            // 
            this.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(83, 123);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(238, 21);
            this.cmbProductos.TabIndex = 6;
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Location = new System.Drawing.Point(11, 126);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(55, 13);
            this.lblProductos.TabIndex = 7;
            this.lblProductos.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(14, 166);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(749, 244);
            this.dgvProductos.TabIndex = 8;
            this.dgvProductos.TabStop = false;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(337, 121);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(110, 23);
            this.btnAgregarProducto.TabIndex = 9;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // lblTotalFactura
            // 
            this.lblTotalFactura.AutoSize = true;
            this.lblTotalFactura.Location = new System.Drawing.Point(476, 126);
            this.lblTotalFactura.Name = "lblTotalFactura";
            this.lblTotalFactura.Size = new System.Drawing.Size(73, 13);
            this.lblTotalFactura.TabIndex = 10;
            this.lblTotalFactura.Text = "Total Factura:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(555, 126);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(43, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "$ 0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(638, 428);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FrmNuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 463);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalFactura);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.lblCaja);
            this.Controls.Add(this.cmbCajas);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Venta";
            this.Load += new System.EventHandler(this.FrmNuevaVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cmbCajas;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.MaskedTextBox txtFactura;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Label lblTotalFactura;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAceptar;
    }
}

namespace WindowsFormsApp
{
    partial class FrmVentas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbVentas = new System.Windows.Forms.GroupBox();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.rtbVenta = new System.Windows.Forms.RichTextBox();
            this.btnAgregarVenta = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.gbVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVentas
            // 
            this.gbVentas.Controls.Add(this.dgvVentas);
            this.gbVentas.Location = new System.Drawing.Point(8, 9);
            this.gbVentas.Name = "gbVentas";
            this.gbVentas.Size = new System.Drawing.Size(589, 294);
            this.gbVentas.TabIndex = 0;
            this.gbVentas.TabStop = false;
            this.gbVentas.Text = "Ventas";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AllowUserToResizeRows = false;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(6, 19);
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.ShowEditingIcon = false;
            this.dgvVentas.Size = new System.Drawing.Size(551, 265);
            this.dgvVentas.TabIndex = 0;
            this.dgvVentas.TabStop = false;
            // 
            // rtbVenta
            // 
            this.rtbVenta.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbVenta.Location = new System.Drawing.Point(616, 12);
            this.rtbVenta.Name = "rtbVenta";
            this.rtbVenta.ReadOnly = true;
            this.rtbVenta.Size = new System.Drawing.Size(351, 291);
            this.rtbVenta.TabIndex = 1;
            this.rtbVenta.TabStop = false;
            this.rtbVenta.Text = "";
            // 
            // btnAgregarVenta
            // 
            this.btnAgregarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarVenta.Location = new System.Drawing.Point(8, 309);
            this.btnAgregarVenta.Name = "btnAgregarVenta";
            this.btnAgregarVenta.Size = new System.Drawing.Size(102, 40);
            this.btnAgregarVenta.TabIndex = 2;
            this.btnAgregarVenta.Text = "Generar Venta";
            this.btnAgregarVenta.UseVisualStyleBackColor = true;
            this.btnAgregarVenta.Click += new System.EventHandler(this.btnAgregarVenta_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.Location = new System.Drawing.Point(616, 309);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(102, 40);
            this.btnLogs.TabIndex = 3;
            this.btnLogs.Text = "Ver Logs";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(862, 309);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(105, 40);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "Exportar Ventas";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Location = new System.Drawing.Point(137, 309);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(104, 40);
            this.btnDetalle.TabIndex = 5;
            this.btnDetalle.Text = "Detalle Venta";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 361);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.btnAgregarVenta);
            this.Controls.Add(this.rtbVenta);
            this.Controls.Add(this.gbVentas);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vicente Montilla 2A";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVentas_FormClosing);
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.gbVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVentas;
        private System.Windows.Forms.RichTextBox rtbVenta;
        private System.Windows.Forms.Button btnAgregarVenta;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Button btnDetalle;
    }
}


namespace Presentacion_IU
{
    partial class frmProductosVentas
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
            this.gbProductosVendedores = new System.Windows.Forms.GroupBox();
            this.dgvGananciasVendedor = new System.Windows.Forms.DataGridView();
            this.btnMostrarGananciasVendedor = new System.Windows.Forms.Button();
            this.btnVenderProducto = new System.Windows.Forms.Button();
            this.dgvProductosxVendedor = new System.Windows.Forms.DataGridView();
            this.btnCancelarProducto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxVendedor = new System.Windows.Forms.ComboBox();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.gbProductosVendedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGananciasVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosxVendedor)).BeginInit();
            this.gbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbProductosVendedores
            // 
            this.gbProductosVendedores.Controls.Add(this.dgvGananciasVendedor);
            this.gbProductosVendedores.Controls.Add(this.btnMostrarGananciasVendedor);
            this.gbProductosVendedores.Controls.Add(this.btnVenderProducto);
            this.gbProductosVendedores.Controls.Add(this.dgvProductosxVendedor);
            this.gbProductosVendedores.Controls.Add(this.btnCancelarProducto);
            this.gbProductosVendedores.Controls.Add(this.label1);
            this.gbProductosVendedores.Controls.Add(this.cbxVendedor);
            this.gbProductosVendedores.Location = new System.Drawing.Point(12, 366);
            this.gbProductosVendedores.Name = "gbProductosVendedores";
            this.gbProductosVendedores.Size = new System.Drawing.Size(1124, 228);
            this.gbProductosVendedores.TabIndex = 13;
            this.gbProductosVendedores.TabStop = false;
            this.gbProductosVendedores.Text = "Productos vendidos por vendedor";
            // 
            // dgvGananciasVendedor
            // 
            this.dgvGananciasVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGananciasVendedor.Location = new System.Drawing.Point(852, 40);
            this.dgvGananciasVendedor.Name = "dgvGananciasVendedor";
            this.dgvGananciasVendedor.Size = new System.Drawing.Size(241, 153);
            this.dgvGananciasVendedor.TabIndex = 15;
            // 
            // btnMostrarGananciasVendedor
            // 
            this.btnMostrarGananciasVendedor.Location = new System.Drawing.Point(651, 143);
            this.btnMostrarGananciasVendedor.Name = "btnMostrarGananciasVendedor";
            this.btnMostrarGananciasVendedor.Size = new System.Drawing.Size(182, 50);
            this.btnMostrarGananciasVendedor.TabIndex = 15;
            this.btnMostrarGananciasVendedor.Text = "Mostrar las Ganancias por Vendedor";
            this.btnMostrarGananciasVendedor.UseVisualStyleBackColor = true;
            this.btnMostrarGananciasVendedor.Click += new System.EventHandler(this.btnMostrarGananciasVendedor_Click);
            // 
            // btnVenderProducto
            // 
            this.btnVenderProducto.Location = new System.Drawing.Point(649, 76);
            this.btnVenderProducto.Name = "btnVenderProducto";
            this.btnVenderProducto.Size = new System.Drawing.Size(89, 50);
            this.btnVenderProducto.TabIndex = 6;
            this.btnVenderProducto.Text = "Vender Producto";
            this.btnVenderProducto.UseVisualStyleBackColor = true;
            this.btnVenderProducto.Click += new System.EventHandler(this.btnVenderProducto_Click);
            // 
            // dgvProductosxVendedor
            // 
            this.dgvProductosxVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosxVendedor.Location = new System.Drawing.Point(18, 29);
            this.dgvProductosxVendedor.Name = "dgvProductosxVendedor";
            this.dgvProductosxVendedor.Size = new System.Drawing.Size(601, 175);
            this.dgvProductosxVendedor.TabIndex = 2;
            // 
            // btnCancelarProducto
            // 
            this.btnCancelarProducto.Location = new System.Drawing.Point(744, 76);
            this.btnCancelarProducto.Name = "btnCancelarProducto";
            this.btnCancelarProducto.Size = new System.Drawing.Size(85, 50);
            this.btnCancelarProducto.TabIndex = 7;
            this.btnCancelarProducto.Text = "Cancelar Compra";
            this.btnCancelarProducto.UseVisualStyleBackColor = true;
            this.btnCancelarProducto.Click += new System.EventHandler(this.btnCancelarProducto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(648, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Vendedor";
            // 
            // cbxVendedor
            // 
            this.cbxVendedor.FormattingEnabled = true;
            this.cbxVendedor.Location = new System.Drawing.Point(713, 40);
            this.cbxVendedor.Name = "cbxVendedor";
            this.cbxVendedor.Size = new System.Drawing.Size(106, 21);
            this.cbxVendedor.TabIndex = 8;
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.dgvProductos);
            this.gbProductos.Location = new System.Drawing.Point(184, 22);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(773, 326);
            this.gbProductos.TabIndex = 12;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(27, 29);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(693, 265);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            // 
            // frmProductosVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 612);
            this.Controls.Add(this.gbProductosVendedores);
            this.Controls.Add(this.gbProductos);
            this.Name = "frmProductosVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductosVentas";
            this.Load += new System.EventHandler(this.frmProductosVentas_Load);
            this.gbProductosVendedores.ResumeLayout(false);
            this.gbProductosVendedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGananciasVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosxVendedor)).EndInit();
            this.gbProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProductosVendedores;
        private System.Windows.Forms.DataGridView dgvGananciasVendedor;
        private System.Windows.Forms.Button btnMostrarGananciasVendedor;
        private System.Windows.Forms.Button btnVenderProducto;
        private System.Windows.Forms.DataGridView dgvProductosxVendedor;
        private System.Windows.Forms.Button btnCancelarProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxVendedor;
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
    }
}
namespace Presentacion_IU
{
    partial class InformesChart
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductosVendidos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGananciasVendedores;

        /// <summary>
        /// Limpiar los recursos que se están usando.
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

        /// <summary>
        /// Método requerido para admitir el Diseñador.
        /// No se puede modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.chartProductosVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGananciasVendedores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGananciasVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // chartProductosVendidos
            // 
            this.chartProductosVendidos.Location = new System.Drawing.Point(24, 58);
            this.chartProductosVendidos.Name = "chartProductosVendidos";
            this.chartProductosVendidos.Size = new System.Drawing.Size(600, 300);
            this.chartProductosVendidos.TabIndex = 0;
            this.chartProductosVendidos.Text = "chartProductosVendidos";
            // 
            // chartGananciasVendedores
            // 
            this.chartGananciasVendedores.Location = new System.Drawing.Point(661, 58);
            this.chartGananciasVendedores.Name = "chartGananciasVendedores";
            this.chartGananciasVendedores.Size = new System.Drawing.Size(600, 300);
            this.chartGananciasVendedores.TabIndex = 1;
            this.chartGananciasVendedores.Text = "chartGananciasVendedores";
            // 
            // InformesChart
            // 
            this.ClientSize = new System.Drawing.Size(1297, 425);
            this.Controls.Add(this.chartGananciasVendedores);
            this.Controls.Add(this.chartProductosVendidos);
            this.Name = "InformesChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes con Gráficos";
            this.Load += new System.EventHandler(this.InformesChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGananciasVendedores)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
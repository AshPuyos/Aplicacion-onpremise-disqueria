using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace Presentacion_IU
{
    public partial class frmVendedores : Form
    {
        private BEClsVendedor oBEVen;
        private BLLClsVendedor oBLLVen;

        public frmVendedores()
        {
            InitializeComponent();
            oBLLVen = new BLLClsVendedor();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvVentas.DataSource = oBLLVen.ListarTodo();
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Mostrar solo las columnas Codigo y Nombre
            dgvVentas.Columns["Codigo"].Visible = true;
            dgvVentas.Columns["Nombre"].Visible = true;
            //dgvVentas.Columns["TotalGanancias"].Visible = false;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            oBEVen = new BEClsVendedor
            {
                Nombre = txtVendedor.Text
            };

            oBLLVen.Guardar(oBEVen);
            CargarGrilla();
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oBEVen.Nombre = txtVendedor.Text;
            oBEVen.Codigo = Convert.ToInt32(txtCodigo.Text);

            oBLLVen.Guardar(oBEVen);
            CargarGrilla();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBEVen.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBLLVen.Baja(oBEVen);
            CargarGrilla();
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtVendedor.Clear();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEVen = (BEClsVendedor)dgvVentas.CurrentRow.DataBoundItem;
            txtCodigo.Text = oBEVen.Codigo.ToString();
            txtVendedor.Text = oBEVen.Nombre;
        }
    }
}

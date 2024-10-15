using System;
using System.Windows.Forms;
using BE;
using BLL;

namespace Presentacion_IU
{
    public partial class frmGeneros : Form
    {
        public frmGeneros()
        {
            InitializeComponent();
            oBLLGen = new BLLClsGenero();
            oBEGen = new BEClsGenero();
        }

        private void frmGeneros_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        BLLClsGenero oBLLGen;
        BEClsGenero oBEGen;

        private void CargarGrilla()
        {
            dgvGeneros.DataSource = oBLLGen.ListarTodo();
            dgvGeneros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            oBEGen = new BEClsGenero
            {
                Nombre = txtNombre.Text
            };

            oBLLGen.Guardar(oBEGen);
            CargarGrilla();
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oBEGen.Nombre = txtNombre.Text;

            oBLLGen.Guardar(oBEGen);
            CargarGrilla();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLLGen.Baja(oBEGen);
            CargarGrilla();
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
        }

        private void dgvGeneros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEGen = (BEClsGenero)dgvGeneros.CurrentRow.DataBoundItem;
            txtNombre.Text = oBEGen.Nombre;
        }
    }
}

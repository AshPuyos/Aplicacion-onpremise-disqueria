using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace Presentacion_IU
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void generosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeneros ofg = new frmGeneros();
            ofg.MdiParent = this;
            ofg.Show();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVendedores ofv = new frmVendedores();
            ofv.MdiParent = this;
            ofv.Show();
        }

        private void registrarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos ofp = new frmProductos();
            ofp.MdiParent = this;
            ofp.Show();
        }

        private void registrarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductosVentas ofpv = new frmProductosVentas();
            ofpv.MdiParent = this;
            ofpv.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario ofu = new frmUsuario();
            ofu.MdiParent = this;
            ofu.Show();
        }

        private void informesConChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformesChart ofc = new InformesChart();
            ofc.MdiParent = this;
            ofc.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace Presentacion_IU
{
    public partial class frmProductos : Form
    {
        BEClsProducto oBEProd;
        BEClsGenero oBEGen;
        BLLClsCd oBLLCd;
        BLLClsVinilo oBLLVin;
        BLLClsGenero oBLLGen;

        public frmProductos()
        {
            InitializeComponent();
            oBLLCd = new BLLClsCd();
            oBLLVin = new BLLClsVinilo();
            oBLLGen = new BLLClsGenero();
            cbxProducto.SelectedIndexChanged += new System.EventHandler(this.cbxProducto_SelectedIndexChanged);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarComboGenero();
            CargarComboTipoProducto();
            CargarGrilla();
        }

        private void CargarComboGenero()
        {
            cmbGenero.DataSource = oBLLGen.ListarTodo();
            cmbGenero.ValueMember = "Codigo";
            cmbGenero.DisplayMember = "Nombre";
        }

        void CargarComboTipoProducto()
        {
            cbxProducto.Items.Clear();
            cbxProducto.Items.Add("CD");
            cbxProducto.Items.Add("Vinilo");
            cbxProducto.SelectedIndex = 0;
        }

        private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isVinilo = cbxProducto.SelectedItem.ToString() == "Vinilo";
            chckUsado.Visible = true; // Siempre visible
            chckUsado.Checked = isVinilo;
            chckUsado.Enabled = false; // Siempre deshabilitado
        }

        void CargarGrilla()
        {
            List<BEClsProducto> productos = new List<BEClsProducto>();
            productos.AddRange(oBLLCd.ListarTodo());
            productos.AddRange(oBLLVin.ListarTodo());

            dgvProductos.DataSource = productos;
            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            if (dgvProductos.Columns["Descuento"] == null)
            {
                DataGridViewTextBoxColumn descuentoColumna = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Precio con Descuento",
                    Name = "Descuento",
                    DataPropertyName = "Descuento"
                };
                dgvProductos.Columns.Add(descuentoColumna);
            }

            if (dgvProductos.Columns["TipoProducto"] == null)
            {
                DataGridViewTextBoxColumn tipoProductoColumna = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tipo Producto",
                    Name = "TipoProducto",
                    DataPropertyName = "TipoProducto"
                };
                dgvProductos.Columns.Add(tipoProductoColumna);
            }

            if (dgvProductos.Columns["Estado"] != null)
            {
                dgvProductos.Columns["Estado"].ReadOnly = true;
            }

            this.dgvProductos.Columns["oGenero"].HeaderText = "Genero";
            dgvProductos.CellFormatting += dgvProductos_CellFormatting;
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "TipoProducto")
            {
                var producto = dgvProductos.Rows[e.RowIndex].DataBoundItem as BEClsProducto;
                if (producto != null)
                {
                    if (producto is BEClsVinilo)
                    {
                        e.Value = "Vinilo";
                    }
                    else if (producto is BEClsCd)
                    {
                        e.Value = "CD";
                    }
                }
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow.DataBoundItem is BEClsCd)
            {
                CargarDatosProducto(dgvProductos.CurrentRow.DataBoundItem as BEClsCd);
            }
            else if (dgvProductos.CurrentRow.DataBoundItem is BEClsVinilo)
            {
                CargarDatosProducto(dgvProductos.CurrentRow.DataBoundItem as BEClsVinilo);
            }
        }

        private void CargarDatosProducto(BEClsCd Cd)
        {
            txtCodigo.Text = Cd.Codigo.ToString();
            txtArtista.Text = Cd.Artista;
            txtAlbum.Text = Cd.Album;
            txtPrecio.Text = Cd.Precio.ToString();
            txtLanzamiento.Text = Cd.Lanzamiento.ToString();
            chckUsado.Visible = true;
            chckUsado.Checked = false;
            chckUsado.Enabled = false; // Deshabilitar cuando es CD
            chckEstado.Checked = Cd.Estado;
            cbxProducto.SelectedItem = "CD";
            cmbGenero.SelectedValue = Cd.oGenero.Codigo;
        }

        private void CargarDatosProducto(BEClsVinilo vinilo)
        {
            txtCodigo.Text = vinilo.Codigo.ToString();
            txtArtista.Text = vinilo.Artista;
            txtAlbum.Text = vinilo.Album;
            txtPrecio.Text = vinilo.Precio.ToString();
            txtLanzamiento.Text = vinilo.Lanzamiento.ToString();
            chckUsado.Visible = true;
            chckUsado.Checked = true;
            chckUsado.Enabled = false; // Deshabilitar cuando es Vinilo
            chckEstado.Checked = vinilo.Estado;
            cbxProducto.SelectedItem = "Vinilo";
            cmbGenero.SelectedValue = vinilo.oGenero.Codigo;
        }

        void Limpiar()
        {
            txtCodigo.Text = "";
            txtArtista.Text = "";
            txtAlbum.Text = "";
            txtPrecio.Text = "";
            txtLanzamiento.Text = "";
            chckEstado.Checked = false;
            chckUsado.Visible = true;
            chckUsado.Checked = false;
            chckUsado.Enabled = false; // Asegurar que está deshabilitado por defecto
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxProducto.SelectedItem.ToString() == "Vinilo")
                {
                    oBEProd = new BEClsVinilo
                    {
                        Usado = true, // Siempre true para vinilos
                        Estado = chckEstado.Checked
                    };
                }
                else if (cbxProducto.SelectedItem.ToString() == "CD")
                {
                    oBEProd = new BEClsCd
                    {
                        Estado = chckEstado.Checked
                    };
                }
                else
                {
                    MessageBox.Show("Seleccione un tipo válido de producto.");
                    return;
                }

                SetProductoCommonFields(oBEProd);

                if (oBEProd is BEClsVinilo vinilo)
                {
                    oBLLVin.Guardar(vinilo);
                }
                else if (oBEProd is BEClsCd cd)
                {
                    oBLLCd.Guardar(cd);
                }

                CargarGrilla();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                BEClsProducto ProductoOriginal = (BEClsProducto)dgvProductos.CurrentRow.DataBoundItem;
                BEClsProducto ProductoModificado;

                if (cbxProducto.SelectedItem.ToString() == "CD")
                {
                    ProductoModificado = new BEClsCd
                    {
                        Codigo = ProductoOriginal.Codigo,
                        Estado = chckEstado.Checked
                    };
                }
                else if (cbxProducto.SelectedItem.ToString() == "Vinilo")
                {
                    ProductoModificado = new BEClsVinilo
                    {
                        Codigo = ProductoOriginal.Codigo,
                        Usado = true, // Siempre true para vinilos
                        Estado = chckEstado.Checked
                    };
                }
                else
                {
                    MessageBox.Show("Seleccione un tipo válido de producto.");
                    return;
                }

                SetProductoCommonFields(ProductoModificado);

                if (ProductoModificado is BEClsCd cd)
                {
                    oBLLCd.Guardar(cd);
                }
                else if (ProductoModificado is BEClsVinilo vinilo)
                {
                    oBLLVin.Guardar(vinilo);
                }

                CargarGrilla();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow.DataBoundItem is BEClsCd cd)
                {
                    oBLLCd.Baja(cd);
                }
                else if (dgvProductos.CurrentRow.DataBoundItem is BEClsVinilo vinilo)
                {
                    oBLLVin.Baja(vinilo);
                }

                CargarGrilla();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void SetProductoCommonFields(BEClsProducto producto)
        {
            producto.Artista = txtArtista.Text;
            producto.Album = txtAlbum.Text;
            producto.Precio = Convert.ToSingle(txtPrecio.Text);
            producto.Lanzamiento = Convert.ToInt32(txtLanzamiento.Text);
            producto.oGenero = (BEClsGenero)cmbGenero.SelectedItem;
        }
    }
}

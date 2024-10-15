using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;

namespace Presentacion_IU
{
    public partial class frmProductosVentas : Form
    {
        BLLClsVendedor oBLLVendedor;
        BLLClsCd oBLLCd;
        BLLClsVinilo oBLLVinilo;

        public frmProductosVentas()
        {
            InitializeComponent();
            oBLLVendedor = new BLLClsVendedor();
            oBLLCd = new BLLClsCd();
            oBLLVinilo = new BLLClsVinilo();
        }

        private void frmProductosVentas_Load(object sender, EventArgs e)
        {
            CargarComboVendedores();
            CargarGrillaProductos();
            if (cbxVendedor.SelectedItem != null)
            {
                var vendedorSeleccionado = (BEClsVendedor)cbxVendedor.SelectedItem;
                CargarGrillaProductosVendidosPorVendedor(vendedorSeleccionado.Codigo);
            }
        }

        private void CargarComboVendedores()
        {
            cbxVendedor.DataSource = oBLLVendedor.ListarTodo();
            cbxVendedor.ValueMember = "Codigo";
            cbxVendedor.DisplayMember = "Nombre";
            cbxVendedor.SelectedIndexChanged += new EventHandler(cbxVendedor_SelectedIndexChanged);
        }

        private void CargarGrillaProductos()
        {
            List<BEClsProducto> productos = new List<BEClsProducto>();
            productos.AddRange(oBLLCd.ListarTodo());
            productos.AddRange(oBLLVinilo.ListarTodo());

            dgvProductos.DataSource = productos;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            if (!dgvProductos.Columns.Contains("TipoProducto"))
            {
                DataGridViewTextBoxColumn tipoProductoColumna = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tipo Producto",
                    Name = "TipoProducto",
                    DataPropertyName = "TipoProducto"
                };
                dgvProductos.Columns.Add(tipoProductoColumna);
            }

            // Establecer la columna de estado como de solo lectura
            if (dgvProductos.Columns["Estado"] != null)
            {
                dgvProductos.Columns["Estado"].ReadOnly = true;
            }

            this.dgvProductos.Columns["oGenero"].HeaderText = "Genero";
            this.dgvProductos.Columns["Descuento"].HeaderText = "Precio con Descuento";

            dgvProductos.CellFormatting += dgvProductos_CellFormatting;
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "TipoProducto")
            {
                var producto = dgvProductos.Rows[e.RowIndex].DataBoundItem as BEClsProducto;
                if (producto != null)
                {
                    e.Value = producto is BEClsVinilo ? "Vinilo" : "CD";
                }
            }
        }

        private void cbxVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxVendedor.SelectedItem != null)
            {
                var vendedorSeleccionado = (BEClsVendedor)cbxVendedor.SelectedItem;
                CargarGrillaProductosVendidosPorVendedor(vendedorSeleccionado.Codigo);
            }
        }

        private void CargarGrillaProductosVendidosPorVendedor(int vendedorCodigo)
        {
            var productosVendidos = oBLLVendedor.ListarProductosVendidosPorVendedor(vendedorCodigo);

            // Eliminar la columna "Precio con Descuento"
            if (dgvProductosxVendedor.Columns["PrecioConDescuento"] != null)
            {
                dgvProductosxVendedor.Columns.Remove("PrecioConDescuento");
            }

            // Calcular y asignar el descuento a cada producto vendido
            foreach (var producto in productosVendidos)
            {
                if (producto is BEClsCd cd)
                {
                    cd.Descuento = oBLLCd.RealizarDescuento(cd);
                }
                else if (producto is BEClsVinilo vinilo)
                {
                    vinilo.Descuento = oBLLVinilo.RealizarDescuento(vinilo);
                }
            }

            dgvProductosxVendedor.DataSource = productosVendidos;
            dgvProductosxVendedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Establecer la columna de estado como de solo lectura
            if (dgvProductosxVendedor.Columns["Estado"] != null)
            {
                dgvProductosxVendedor.Columns["Estado"].ReadOnly = true;
            }
        }

        private void btnVenderProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxVendedor.SelectedItem != null && dgvProductos.CurrentRow != null)
                {
                    var vendedor = (BEClsVendedor)cbxVendedor.SelectedItem;
                    var producto = (BEClsProducto)dgvProductos.CurrentRow.DataBoundItem;

                    if (producto.Estado)
                    {
                        bool resultado = oBLLVendedor.VenderProducto(vendedor, producto);
                        if (resultado)
                        {
                            MessageBox.Show("Producto vendido correctamente.");
                            CargarGrillaProductosVendidosPorVendedor(vendedor.Codigo);
                            CargarGrillaProductos();
                        }
                        else
                        {
                            MessageBox.Show("Error al vender el producto.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto no está disponible para la venta.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un vendedor y un producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductosxVendedor.CurrentRow != null)
                {
                    var producto = (BEClsProducto)dgvProductosxVendedor.CurrentRow.DataBoundItem;
                    var vendedor = (BEClsVendedor)cbxVendedor.SelectedItem;

                    bool resultado = oBLLVendedor.CancelarVentaProducto(vendedor, producto);
                    if (resultado)
                    {
                        MessageBox.Show("Venta de producto cancelada correctamente.");
                        CargarGrillaProductosVendidosPorVendedor(vendedor.Codigo);
                        CargarGrillaProductos();
                    }
                    else
                    {
                        MessageBox.Show("Error al cancelar la venta del producto.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un producto vendido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarGananciasVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                var gananciasTodosVendedores = oBLLVendedor.CalcularGananciasTodosVendedores();
                var dataSource = gananciasTodosVendedores.Select(g => new { Vendedor = g.Key, Ganancias = g.Value }).ToList();

                dgvGananciasVendedor.DataSource = dataSource;
                dgvGananciasVendedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
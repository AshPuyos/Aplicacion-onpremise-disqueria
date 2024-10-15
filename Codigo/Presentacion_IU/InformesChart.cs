using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace Presentacion_IU
{
    public partial class InformesChart : Form
    {
        private BLLClsVendedor bllVendedor;

        public InformesChart()
        {
            InitializeComponent();
            bllVendedor = new BLLClsVendedor();
        }

        private void InformesChart_Load(object sender, EventArgs e)
        {
            CargarGraficoProductosVendidos();
            CargarGraficoGananciasVendedores();
        }

        private void CargarGraficoProductosVendidos()
        {
            var productosVendidos = bllVendedor.ListarProductosVendidos();
            var productosPorArtista = new Dictionary<string, int>();

            foreach (var producto in productosVendidos)
            {
                if (productosPorArtista.ContainsKey(producto.Artista))
                {
                    productosPorArtista[producto.Artista]++;
                }
                else
                {
                    productosPorArtista[producto.Artista] = 1;
                }
            }

            chartProductosVendidos.Titles.Clear();
            chartProductosVendidos.ChartAreas.Clear();
            chartProductosVendidos.Series.Clear();

            // Título del gráfico
            Title titulo = new Title("Productos Vendidos por Artista");
            titulo.Font = new System.Drawing.Font("Tahoma", 20, System.Drawing.FontStyle.Bold);
            chartProductosVendidos.Titles.Add(titulo);

            // Área del gráfico
            ChartArea area = new ChartArea();
            area.Area3DStyle.Enable3D = true;
            area.AxisX.Title = "Artista";
            area.AxisY.Title = "Cantidad Vendida";
            area.AxisX.TitleFont = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Bold);
            area.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Bold);
            chartProductosVendidos.ChartAreas.Add(area);

            // Serie del gráfico
            Series serie = new Series("Productos Vendidos");
            serie.ChartType = SeriesChartType.Bar;
            serie.Color = System.Drawing.Color.Blue;
            serie.Points.DataBindXY(productosPorArtista.Keys, productosPorArtista.Values);
            serie.IsValueShownAsLabel = true; // Mostrar valores sobre las barras
            chartProductosVendidos.Series.Add(serie);

            // Leyenda
            Legend leyenda = new Legend();
            leyenda.Title = "Leyenda";
            chartProductosVendidos.Legends.Add(leyenda);
        }

        private void CargarGraficoGananciasVendedores()
        {
            var gananciasVendedores = bllVendedor.CalcularGananciasPorVendedor();
            var gananciasFiltradas = gananciasVendedores.Where(g => g.Value > 0).ToDictionary(g => g.Key, g => g.Value);

            chartGananciasVendedores.Titles.Clear();
            chartGananciasVendedores.ChartAreas.Clear();
            chartGananciasVendedores.Series.Clear();

            // Título del gráfico
            Title titulo = new Title("Ganancias por Vendedor");
            titulo.Font = new System.Drawing.Font("Tahoma", 20, System.Drawing.FontStyle.Bold);
            chartGananciasVendedores.Titles.Add(titulo);

            // Área del gráfico
            ChartArea area = new ChartArea();
            area.Area3DStyle.Enable3D = true;
            chartGananciasVendedores.ChartAreas.Add(area);

            // Serie del gráfico
            Series serie = new Series("Ganancias");
            serie.ChartType = SeriesChartType.Pie;
            serie.Points.DataBindXY(gananciasFiltradas.Keys, gananciasFiltradas.Values);
            serie.IsValueShownAsLabel = true; // Mostrar valores en el gráfico
            chartGananciasVendedores.Series.Add(serie);

            // Leyenda
            Legend leyenda = new Legend();
            leyenda.Title = "Vendedores";
            chartGananciasVendedores.Legends.Add(leyenda);
        }
    }
}
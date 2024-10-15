using System.Collections.Generic;
using System.Linq;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLClsVendedor : IGestor<BEClsVendedor>
    {
        MPPClsVendedor oMPPVendedor = new MPPClsVendedor();
        MPPProducto oMPPProducto = new MPPProducto();

        public List<BEClsVendedor> ListarTodo()
        {
            return oMPPVendedor.ListarTodo();
        }

        public bool Guardar(BEClsVendedor oBEVendedor)
        {
            return oMPPVendedor.Guardar(oBEVendedor);
        }

        public bool Baja(BEClsVendedor oBEVendedor)
        {
            return oMPPVendedor.Baja(oBEVendedor);
        }

        public BEClsVendedor ListarObjeto(BEClsVendedor oBEVendedor)
        {
            return oMPPVendedor.ListarObjeto(oBEVendedor);
        }

        public List<BEClsProducto> ListarProductosVendidos()
        {
            return oMPPProducto.ListarTodo().Where(p => !p.Estado).ToList();
        }

        public List<BEClsProducto> ListarProductosVendidosPorVendedor(int vendedorCodigo)
        {
            return oMPPProducto.ListarProductosPorVendedor(vendedorCodigo).Where(p => !p.Estado).ToList();
        }

        public Dictionary<string, float> CalcularGananciasPorVendedor()
        {
            var vendedores = ListarTodo();
            var ganancias = new Dictionary<string, float>();

            foreach (var vendedor in vendedores)
            {
                var productosVendidos = ListarProductosVendidosPorVendedor(vendedor.Codigo);
                float totalGanancias = productosVendidos.Sum(p => p.Precio - p.Descuento);
                ganancias[vendedor.Nombre] = totalGanancias;
            }

            return ganancias;
        }

        public Dictionary<int, float> CalcularGananciasTodosVendedores()
        {
            var vendedores = ListarTodo();
            var ganancias = new Dictionary<int, float>();

            foreach (var vendedor in vendedores)
            {
                float totalGanancias = CalcularGananciasPorVendedor(vendedor.Codigo);
                ganancias[vendedor.Codigo] = totalGanancias;
            }

            return ganancias;
        }

        private float CalcularGananciasPorVendedor(int vendedorCodigo)
        {
            var productosVendidos = ListarProductosVendidosPorVendedor(vendedorCodigo);
            float totalGanancias = productosVendidos.Sum(p => p.Precio - p.Descuento);
            return totalGanancias;
        }

        public bool VenderProducto(BEClsVendedor oBEVendedor, BEClsProducto oBEProducto)
        {
            oBEProducto.Estado = false; // Asumimos que Estado = false significa vendido
            return oMPPVendedor.VenderProducto(oBEVendedor, oBEProducto);
        }

        public bool CancelarVentaProducto(BEClsVendedor oBEVendedor, BEClsProducto oBEProducto)
        {
            oBEProducto.Estado = true; // Asumimos que Estado = true significa disponible
            return oMPPVendedor.CancelarVentaProducto(oBEVendedor, oBEProducto);
        }
    }
}
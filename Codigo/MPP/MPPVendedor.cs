using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BE;
using DAL;
using Abstraccion;

namespace MPP
{
    public class MPPClsVendedor : IGestor<BEClsVendedor>
    {
        Acceso oDatos = new Acceso();

        public List<BEClsVendedor> ListarTodo()
        {
            List<BEClsVendedor> ListaVendedor = new List<BEClsVendedor>();
            string Consulta_SQL = "ListarVendedores";
            DataTable Tabla = oDatos.Leer(Consulta_SQL, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEClsVendedor oBEVendedor = new BEClsVendedor
                    {
                        Codigo = Convert.ToInt32(fila["Codigo"]),
                        Nombre = fila["Nombre"].ToString()
                    };
                    ListaVendedor.Add(oBEVendedor);
                }
            }

            return ListaVendedor;
        }

        public bool Guardar(BEClsVendedor oBEVendedor)
        {
            string Consulta_SQL = oBEVendedor.Codigo != 0 ? "ActualizarVendedor" : "InsertarVendedor";
            Hashtable Hdatos = new Hashtable
            {
                { "@Nombre", oBEVendedor.Nombre }
            };
            if (oBEVendedor.Codigo != 0)
            {
                Hdatos.Add("@Codigo", oBEVendedor.Codigo);
            }

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public bool Baja(BEClsVendedor oBEVendedor)
        {
            string Consulta_SQL = "EliminarVendedor";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEVendedor.Codigo }
            };

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public BEClsVendedor ListarObjeto(BEClsVendedor oBEVendedor)
        {
            string Consulta_SQL = "ObtenerVendedor";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEVendedor.Codigo }
            };
            DataTable Tabla = oDatos.Leer(Consulta_SQL, Hdatos);

            if (Tabla.Rows.Count > 0)
            {
                DataRow fila = Tabla.Rows[0];
                oBEVendedor.Nombre = fila["Nombre"].ToString();
                oBEVendedor.ListaProductos = ListarProductosPorVendedor(oBEVendedor.Codigo);
            }

            return oBEVendedor;
        }

        public List<BEClsProducto> ListarProductosPorVendedor(int vendedorCodigo)
        {
            string Consulta_SQL = "ListarProductosPorVendedor";
            Hashtable Hdatos = new Hashtable
            {
                { "@CodVendedor", vendedorCodigo }
            };
            DataTable Tabla = oDatos.Leer(Consulta_SQL, Hdatos);

            List<BEClsProducto> ListaProductos = new List<BEClsProducto>();

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEClsProducto oBEProducto;
                    if (fila["Usado"] != DBNull.Value && Convert.ToBoolean(fila["Usado"]))
                    {
                        oBEProducto = new BEClsVinilo();
                    }
                    else
                    {
                        oBEProducto = new BEClsCd();
                    }

                    oBEProducto.Codigo = Convert.ToInt32(fila["Codigo"]);
                    oBEProducto.Artista = fila["Artista"].ToString();
                    oBEProducto.Album = fila["Album"].ToString();
                    oBEProducto.Precio = Convert.ToSingle(fila["Precio"]);
                    oBEProducto.Lanzamiento = Convert.ToInt32(fila["Lanzamiento"]);
                    oBEProducto.Estado = Convert.ToBoolean(fila["Estado"]);
                    oBEProducto.oGenero = new BEClsGenero
                    {
                        Codigo = Convert.ToInt32(fila["CodGenero"]),
                        Nombre = fila["Genero"].ToString()
                    };

                    ListaProductos.Add(oBEProducto);
                }
            }

            return ListaProductos;
        }

        public bool VenderProducto(BEClsVendedor oBEVendedor, BEClsProducto oBEProducto)
        {
            string Consulta_SQL = "VenderProducto";
            Hashtable Hdatos = new Hashtable
            {
                { "@CodProducto", oBEProducto.Codigo },
                { "@CodVendedor", oBEVendedor.Codigo }
            };

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public bool CancelarVentaProducto(BEClsVendedor oBEVendedor, BEClsProducto oBEProducto)
        {
            string Consulta_SQL = "CancelarVentaProducto";
            Hashtable Hdatos = new Hashtable
            {
                { "@CodProducto", oBEProducto.Codigo },
                { "@CodVendedor", oBEVendedor.Codigo }
            };

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }
    }
}

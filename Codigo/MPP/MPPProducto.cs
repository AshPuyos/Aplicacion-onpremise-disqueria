using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BE;
using DAL;
using Abstraccion;

namespace MPP
{
    public class MPPProducto : IGestor<BEClsProducto>
    {
        Acceso oDatos = new Acceso();

        public List<BEClsProducto> ListarTodo()
        {
            List<BEClsProducto> ListaProductos = new List<BEClsProducto>();
            string Consulta_SQL = "ListarProductos";
            DataTable Tabla = oDatos.Leer(Consulta_SQL, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEClsProducto oBEClsProducto;
                    if (fila["Usado"] != DBNull.Value && Convert.ToBoolean(fila["Usado"]))
                    {
                        oBEClsProducto = new BEClsVinilo(); // Instancia de vinilo
                    }
                    else
                    {
                        oBEClsProducto = new BEClsCd(); // Instancia de CD
                    }

                    oBEClsProducto.Codigo = Convert.ToInt32(fila["Codigo"]);
                    oBEClsProducto.Artista = fila["Artista"].ToString();
                    oBEClsProducto.Album = fila["Album"].ToString();
                    oBEClsProducto.Precio = Convert.ToSingle(fila["Precio"]);
                    oBEClsProducto.Lanzamiento = Convert.ToInt32(fila["Lanzamiento"]);
                    oBEClsProducto.Estado = Convert.ToBoolean(fila["Estado"]);
                    oBEClsProducto.oGenero = new BEClsGenero
                    {
                        Codigo = Convert.ToInt32(fila["CodGenero"]),
                        //Nombre = fila["Nombre"].ToString()
                    };

                    ListaProductos.Add(oBEClsProducto);
                }
            }

            return ListaProductos;
        }

        public List<BEClsProducto> ListarProductosPorVendedor(int vendedorCodigo)
        {
            List<BEClsProducto> ListaProductos = new List<BEClsProducto>();
            string Consulta_SQL = "ListarProductosPorVendedor";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@VendedorCodigo", vendedorCodigo);

            DataTable Tabla = oDatos.Leer(Consulta_SQL, Hdatos);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEClsProducto oBEClsProducto;
                    if (fila["Usado"] != DBNull.Value && Convert.ToBoolean(fila["Usado"]))
                    {
                        oBEClsProducto = new BEClsVinilo(); // Instancia de vinilo
                    }
                    else
                    {
                        oBEClsProducto = new BEClsCd(); // Instancia de CD
                    }

                    oBEClsProducto.Codigo = Convert.ToInt32(fila["Codigo"]);
                    oBEClsProducto.Artista = fila["Artista"].ToString();
                    oBEClsProducto.Album = fila["Album"].ToString();
                    oBEClsProducto.Precio = Convert.ToSingle(fila["Precio"]);
                    oBEClsProducto.Lanzamiento = Convert.ToInt32(fila["Lanzamiento"]);
                    oBEClsProducto.Estado = Convert.ToBoolean(fila["Estado"]);
                    oBEClsProducto.oGenero = new BEClsGenero
                    {
                        Codigo = Convert.ToInt32(fila["CodGenero"]),
                        Nombre = fila["Nombre"].ToString()
                    };

                    ListaProductos.Add(oBEClsProducto);
                }
            }

            return ListaProductos;
        }

        public bool Guardar(BEClsProducto oBEClsProducto)
        {
            string Consulta_SQL = oBEClsProducto.Codigo != 0 ? "ActualizarProducto" : "InsertarProducto";
            Hashtable Hdatos = new Hashtable
            {
                { "@Artista", oBEClsProducto.Artista },
                { "@Album", oBEClsProducto.Album },
                { "@Precio", oBEClsProducto.Precio },
                { "@Lanzamiento", oBEClsProducto.Lanzamiento },
                { "@Estado", oBEClsProducto.Estado },
                { "@Usado", oBEClsProducto is BEClsVinilo },
                { "@CodGenero", oBEClsProducto.oGenero.Codigo }
            };
            if (oBEClsProducto.Codigo != 0)
            {
                Hdatos.Add("@Codigo", oBEClsProducto.Codigo);
            }

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public bool Baja(BEClsProducto oBEClsProducto)
        {
            string Consulta_SQL = "EliminarProducto";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEClsProducto.Codigo }
            };

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public BEClsProducto ListarObjeto(BEClsProducto oBEClsProducto)
        {
            string Consulta_SQL = "ObtenerProducto";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEClsProducto.Codigo }
            };
            DataTable Tabla = oDatos.Leer(Consulta_SQL, Hdatos);

            if (Tabla.Rows.Count > 0)
            {
                DataRow fila = Tabla.Rows[0];
                if (fila["Usado"] != DBNull.Value && Convert.ToBoolean(fila["Usado"]))
                {
                    oBEClsProducto = new BEClsVinilo(); // Instancia de vinilo
                }
                else
                {
                    oBEClsProducto = new BEClsCd(); // Instancia de CD
                }

                oBEClsProducto.Codigo = Convert.ToInt32(fila["Codigo"]);
                oBEClsProducto.Artista = fila["Artista"].ToString();
                oBEClsProducto.Album = fila["Album"].ToString();
                oBEClsProducto.Precio = Convert.ToSingle(fila["Precio"]);
                oBEClsProducto.Lanzamiento = Convert.ToInt32(fila["Lanzamiento"]);
                oBEClsProducto.Estado = Convert.ToBoolean(fila["Estado"]);
                oBEClsProducto.oGenero = new BEClsGenero
                {
                    Codigo = Convert.ToInt32(fila["CodGenero"]),
                    Nombre = fila["Nombre"].ToString()
                };
            }

            return oBEClsProducto;
        }
    }
}

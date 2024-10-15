using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BE;
using DAL;
using Abstraccion;

namespace MPP
{
    public class MPPVinilo : IGestor<BEClsVinilo>
    {
        private Acceso oDatos = new Acceso();

        public List<BEClsVinilo> ListarTodo()
        {
            List<BEClsVinilo> ListaVinilos = new List<BEClsVinilo>();
            string Consulta_SQL = "ListarVinilos";
            DataTable Tabla = oDatos.Leer(Consulta_SQL, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEClsVinilo oBEVinilo = new BEClsVinilo
                    {
                        Codigo = Convert.ToInt32(fila["Codigo"]),
                        Artista = fila["Artista"].ToString(),
                        Album = fila["Album"].ToString(),
                        Precio = Convert.ToSingle(fila["Precio"]),
                        Lanzamiento = Convert.ToInt32(fila["Lanzamiento"]),
                        Estado = Convert.ToBoolean(fila["Estado"]),
                        oGenero = new BEClsGenero
                        {
                            Codigo = Convert.ToInt32(fila["CodGenero"]),
                            Nombre = fila["Genero"].ToString()
                        }
                    };
                    ListaVinilos.Add(oBEVinilo);
                }
            }

            return ListaVinilos;
        }

        public bool Guardar(BEClsVinilo oBEVinilo)
        {
            string Consulta_SQL = oBEVinilo.Codigo != 0 ? "ActualizarVinilo" : "InsertarVinilo";
            Hashtable Hdatos = new Hashtable
            {
                { "@Artista", oBEVinilo.Artista },
                { "@Album", oBEVinilo.Album },
                { "@Precio", oBEVinilo.Precio },
                { "@Lanzamiento", oBEVinilo.Lanzamiento },
                { "@Estado", oBEVinilo.Estado },
                { "@CodGenero", oBEVinilo.oGenero.Codigo }
            };
            if (oBEVinilo.Codigo != 0)
            {
                Hdatos.Add("@Codigo", oBEVinilo.Codigo);
            }

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public bool Baja(BEClsVinilo oBEVinilo)
        {
            string Consulta_SQL = "EliminarVinilo";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEVinilo.Codigo }
            };

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public BEClsVinilo ListarObjeto(BEClsVinilo oBEVinilo)
        {
            string Consulta_SQL = "ObtenerVinilo";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEVinilo.Codigo }
            };
            DataTable Tabla = oDatos.Leer(Consulta_SQL, Hdatos);

            if (Tabla.Rows.Count > 0)
            {
                DataRow fila = Tabla.Rows[0];
                oBEVinilo.Codigo = Convert.ToInt32(fila["Codigo"]);
                oBEVinilo.Artista = fila["Artista"].ToString();
                oBEVinilo.Album = fila["Album"].ToString();
                oBEVinilo.Precio = Convert.ToSingle(fila["Precio"]);
                oBEVinilo.Lanzamiento = Convert.ToInt32(fila["Lanzamiento"]);
                oBEVinilo.Estado = Convert.ToBoolean(fila["Estado"]);
                oBEVinilo.oGenero = new BEClsGenero
                {
                    Codigo = Convert.ToInt32(fila["CodGenero"]),
                    Nombre = fila["Nombre"].ToString()
                };
            }

            return oBEVinilo;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BE;
using DAL;
using Abstraccion;

namespace MPP
{
    public class MPPCd : IGestor<BEClsCd>
    {
        Acceso oDatos = new Acceso();

        public List<BEClsCd> ListarTodo()
        {
            List<BEClsCd> ListaCds = new List<BEClsCd>();
            string Consulta_SQL = "ListarCds";
            DataTable Tabla = oDatos.Leer(Consulta_SQL, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEClsCd oBEClsCd = new BEClsCd
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
                            Nombre = fila["Nombre"].ToString()
                        }
                    };
                    ListaCds.Add(oBEClsCd);
                }
            }

            return ListaCds;
        }

        public bool Guardar(BEClsCd oBEClsCd)
        {
            string Consulta_SQL = oBEClsCd.Codigo != 0 ? "ActualizarCd" : "InsertarCd";
            Hashtable Hdatos = new Hashtable
            {
                { "@Artista", oBEClsCd.Artista },
                { "@Album", oBEClsCd.Album },
                { "@Precio", oBEClsCd.Precio },
                { "@Lanzamiento", oBEClsCd.Lanzamiento },
                { "@Estado", oBEClsCd.Estado },
                { "@CodGenero", oBEClsCd.oGenero.Codigo }
            };
            if (oBEClsCd.Codigo != 0)
            {
                Hdatos.Add("@Codigo", oBEClsCd.Codigo);
            }

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public bool Baja(BEClsCd oBEClsCd)
        {
            string Consulta_SQL = "EliminarCd";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEClsCd.Codigo }
            };

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public BEClsCd ListarObjeto(BEClsCd oBEClsCd)
        {
            string Consulta_SQL = "ObtenerCd";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEClsCd.Codigo }
            };
            DataTable Tabla = oDatos.Leer(Consulta_SQL, Hdatos);

            if (Tabla.Rows.Count > 0)
            {
                DataRow fila = Tabla.Rows[0];
                oBEClsCd.Codigo = Convert.ToInt32(fila["Codigo"]);
                oBEClsCd.Artista = fila["Artista"].ToString();
                oBEClsCd.Album = fila["Album"].ToString();
                oBEClsCd.Precio = Convert.ToSingle(fila["Precio"]);
                oBEClsCd.Lanzamiento = Convert.ToInt32(fila["Lanzamiento"]);
                oBEClsCd.Estado = Convert.ToBoolean(fila["Estado"]);
                oBEClsCd.oGenero = new BEClsGenero
                {
                    Codigo = Convert.ToInt32(fila["CodGenero"]),
                    Nombre = fila["Nombre"].ToString()
                };
            }

            return oBEClsCd;
        }
    }
}

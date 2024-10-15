using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BE;
using DAL;
using Abstraccion;

namespace MPP
{
    public class MPPGenero : IGestor<BEClsGenero>
    {
        Acceso oDatos = new Acceso();

        public List<BEClsGenero> ListarTodo()
        {
            List<BEClsGenero> ListaGeneros = new List<BEClsGenero>();
            string Consulta_SQL = "ListarGeneros";
            DataTable Tabla = oDatos.Leer(Consulta_SQL, null);

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEClsGenero oBEGenero = new BEClsGenero
                    {
                        Codigo = Convert.ToInt32(fila["Codigo"]),
                        Nombre = fila["Nombre"].ToString()
                    };
                    ListaGeneros.Add(oBEGenero);
                }
            }

            return ListaGeneros;
        }

        public bool Guardar(BEClsGenero oBEGenero)
        {
            string Consulta_SQL = oBEGenero.Codigo != 0 ? "ActualizarGenero" : "InsertarGenero";
            Hashtable Hdatos = new Hashtable
            {
                { "@Nombre", oBEGenero.Nombre }
            };
            if (oBEGenero.Codigo != 0)
            {
                Hdatos.Add("@Codigo", oBEGenero.Codigo);
            }

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public bool Baja(BEClsGenero oBEGenero)
        {
            string Consulta_SQL = "EliminarGenero";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEGenero.Codigo }
            };

            return oDatos.Escribir(Consulta_SQL, Hdatos);
        }

        public BEClsGenero ListarObjeto(BEClsGenero oBEGenero)
        {
            string Consulta_SQL = "ObtenerGenero";
            Hashtable Hdatos = new Hashtable
            {
                { "@Codigo", oBEGenero.Codigo }
            };
            DataTable Tabla = oDatos.Leer(Consulta_SQL, Hdatos);

            if (Tabla.Rows.Count > 0)
            {
                DataRow fila = Tabla.Rows[0];
                oBEGenero.Codigo = Convert.ToInt32(fila["Codigo"]);
                oBEGenero.Nombre = fila["Nombre"].ToString();
            }

            return oBEGenero;
        }
    }
}

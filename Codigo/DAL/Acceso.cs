using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        string CadenaC = @"Data Source=.\SQLEXPRESS;Initial Catalog=LUG_TP2_ Puyos_Ayelen;Integrated Security=True";

        SqlConnection oCnn;
        SqlTransaction Tranx;
        SqlCommand Cmd;

        public Acceso()
        {
            oCnn = new SqlConnection(CadenaC);
        }

        public DataTable Leer(string Consulta, Hashtable Hdatos)
        {
            DataTable Dt = new DataTable();
            SqlDataAdapter Da;

            Cmd = new SqlCommand(Consulta, oCnn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                Da = new SqlDataAdapter(Cmd);

                if (Hdatos != null)
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                Da.Fill(Dt);
                return Dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool LeerScalar(string Consulta, Hashtable Hdatos)
        {
            oCnn.Open();

            Cmd = new SqlCommand(Consulta, oCnn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                if (Hdatos != null)
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int Respuesta = Convert.ToInt32(Cmd.ExecuteScalar());
                oCnn.Close();
                return Respuesta > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Escribir(string consulta, Hashtable Hdatos)
        {
            if (oCnn.State == ConnectionState.Closed)
            {
                oCnn.Open();
            }

            try
            {
                Tranx = oCnn.BeginTransaction();
                Cmd = new SqlCommand(consulta, oCnn, Tranx)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (Hdatos != null)
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int respuesta = Cmd.ExecuteNonQuery();
                Tranx.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                Tranx.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                Tranx.Rollback();
                throw ex;
            }
            finally
            {
                oCnn.Close();
            }
        }
    }
}

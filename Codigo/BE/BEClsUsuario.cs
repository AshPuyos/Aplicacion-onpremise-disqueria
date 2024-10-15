using System;

namespace BE
{
    public class BEClsUsuario : Entidad
    {
        #region Propiedades
        public string Usuario { get; set; }
        public string Psw { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        #endregion

        #region Constructores
        // Constructor por defecto
        public BEClsUsuario()
        {
        }

        // Constructor sobrecargado
        public BEClsUsuario(int codigo, string usuario, string psw, string nombre, string apellido)
        {
            this.Codigo = codigo;
            this.Usuario = usuario;
            this.Psw = psw;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }
        #endregion
    }
}

using System.Collections.Generic;
using BE;
using MPP;

namespace BLL
{
    public class BLLClsUsuario
    {
        MPPUsuario mppUsuario = new MPPUsuario();

        public List<BEClsUsuario> ListarTodo()
        {
            return mppUsuario.ListarTodo();
        }

        public bool Guardar(BEClsUsuario usuario)
        {
            // Encriptar la contraseña antes de guardar el usuario
            usuario.Psw = BLLClsSeguridad.GenerarSHA(usuario.Psw);
            return mppUsuario.Guardar(usuario);
        }

        public bool Baja(BEClsUsuario usuario)
        {
            return mppUsuario.Baja(usuario);
        }

        public BEClsUsuario ValidarUsuario(string nombreUsuario, string passwordEncriptada)
        {
            return mppUsuario.ValidarUsuario(nombreUsuario, passwordEncriptada);
        }

        public List<BEClsUsuario> Buscar(string criterio)
        {
            return mppUsuario.Buscar(criterio);
        }
    }
}

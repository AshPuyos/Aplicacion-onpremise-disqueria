using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BE;

namespace MPP
{
    public class MPPUsuario
    {
        private string filePath = "Usuarios.xml";

        public List<BEClsUsuario> ListarTodo()
        {
            var consulta = from usuario in XElement.Load(filePath).Elements("usuario")
                           select new BEClsUsuario(
                               Convert.ToInt32(usuario.Attribute("codigo").Value),
                               usuario.Element("nombreUsuario").Value,
                               usuario.Element("password").Value,
                               usuario.Element("nombre").Value,
                               usuario.Element("apellido").Value
                           );

            return consulta.ToList();
        }

        public BEClsUsuario ValidarUsuario(string nombreUsuario, string passwordEncriptada)
        {
            var consulta = from usuario in XElement.Load(filePath).Elements("usuario")
                           where usuario.Element("nombreUsuario").Value == nombreUsuario &&
                                 usuario.Element("password").Value == passwordEncriptada
                           select new BEClsUsuario(
                               Convert.ToInt32(usuario.Attribute("codigo").Value),
                               usuario.Element("nombreUsuario").Value,
                               usuario.Element("password").Value,
                               usuario.Element("nombre").Value,
                               usuario.Element("apellido").Value
                           );

            return consulta.FirstOrDefault();
        }

        public bool Guardar(BEClsUsuario usuario)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(filePath);
                XElement root = xmlDoc.Element("usuarios");

                XElement usuarioExistente = root.Elements("usuario")
                    .FirstOrDefault(x => (int)x.Attribute("codigo") == usuario.Codigo);

                if (usuarioExistente != null)
                {
                    usuarioExistente.SetElementValue("nombreUsuario", usuario.Usuario);
                    usuarioExistente.SetElementValue("password", usuario.Psw); // Contraseña ya encriptada
                    usuarioExistente.SetElementValue("nombre", usuario.Nombre);
                    usuarioExistente.SetElementValue("apellido", usuario.Apellido);
                }
                else
                {
                    XElement nuevoUsuario = new XElement("usuario",
                        new XAttribute("codigo", usuario.Codigo),
                        new XElement("nombreUsuario", usuario.Usuario),
                        new XElement("password", usuario.Psw), // Contraseña ya encriptada
                        new XElement("nombre", usuario.Nombre),
                        new XElement("apellido", usuario.Apellido)
                    );

                    root.Add(nuevoUsuario);
                }

                xmlDoc.Save(filePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar usuario: " + ex.Message);
                return false;
            }
        }


        public bool Baja(BEClsUsuario usuario)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(filePath);
                XElement root = xmlDoc.Element("usuarios");

                XElement usuarioEliminar = root.Elements("usuario")
                    .FirstOrDefault(x => (int)x.Attribute("codigo") == usuario.Codigo);

                if (usuarioEliminar != null)
                {
                    usuarioEliminar.Remove();
                    xmlDoc.Save(filePath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
                return false;
            }
        }

        public List<BEClsUsuario> Buscar(string criterio)
        {
            var consulta = from usuario in XElement.Load(filePath).Elements("usuario")
                           where usuario.Element("nombre").Value.Contains(criterio) ||
                                 usuario.Element("apellido").Value.Contains(criterio) ||
                                 usuario.Element("nombreUsuario").Value.Contains(criterio)
                           select new BEClsUsuario(
                               Convert.ToInt32(usuario.Attribute("codigo").Value),
                               usuario.Element("nombreUsuario").Value,
                               usuario.Element("password").Value,
                               usuario.Element("nombre").Value,
                               usuario.Element("apellido").Value
                           );

            return consulta.ToList();
        }
    }
}

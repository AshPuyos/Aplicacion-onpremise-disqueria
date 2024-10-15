using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BE;
using BLL;

namespace Presentacion_IU
{
    public partial class frmUsuario : Form
    {
        private BLLClsUsuario bllUsuario;

        public frmUsuario()
        {
            InitializeComponent();
            bllUsuario = new BLLClsUsuario();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            List<BEClsUsuario> listaUsuarios = bllUsuario.ListarTodo();
            dataGridView1.DataSource = listaUsuarios;
            cmbUsuarioBuscar.DataSource = listaUsuarios.Select(u => u.Nombre).ToList();
            cmbUsuarioBuscar.SelectedIndex = -1;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (ValidarEntrada(txtUsuario.Text, txtPassword.Text, txtNombre.Text, txtApellido.Text))
            {
                int nuevoCodigo = GenerarNuevoCodigo();

                BEClsUsuario nuevoUsuario = new BEClsUsuario
                {
                    Codigo = nuevoCodigo,
                    Usuario = txtUsuario.Text,
                    Psw = txtPassword.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text
                };

                if (bllUsuario.Guardar(nuevoUsuario))
                {
                    MessageBox.Show("Usuario guardado con éxito.");
                    CargarUsuarios();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al guardar el usuario.");
                }
            }
        }

        private int GenerarNuevoCodigo()
        {
            List<BEClsUsuario> listaUsuarios = bllUsuario.ListarTodo();
            if (listaUsuarios.Count == 0)
            {
                return 1;
            }
            else
            {
                return listaUsuarios.Max(u => u.Codigo) + 1;
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigo.Text, out int codigo) &&
                ValidarEntrada(txtUsuario.Text, txtPassword.Text, txtNombre.Text, txtApellido.Text))
            {
                // Obtener el usuario actual de la base de datos para comparar la contraseña
                BEClsUsuario usuarioActual = bllUsuario.ListarTodo().FirstOrDefault(u => u.Codigo == codigo);
                if (usuarioActual == null)
                {
                    MessageBox.Show("Usuario no encontrado.");
                    return;
                }

                // Si la contraseña ha sido cambiada, encriptarla, de lo contrario usar la vieja contraseña
                string nuevaPassword = txtPassword.Text;
                if (string.IsNullOrWhiteSpace(nuevaPassword))
                {
                    nuevaPassword = usuarioActual.Psw; 
                }
                else
                {
                    nuevaPassword = BLLClsSeguridad.GenerarSHA(nuevaPassword); // Encriptar nueva contraseña
                }

                BEClsUsuario usuarioModificado = new BEClsUsuario(codigo, txtUsuario.Text, nuevaPassword, txtNombre.Text, txtApellido.Text);

                if (bllUsuario.Guardar(usuarioModificado))
                {
                    MessageBox.Show("Usuario modificado con éxito.");
                    CargarUsuarios();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al modificar el usuario.");
                }
            }
            else
            {
                MessageBox.Show("Código de usuario inválido.");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigo.Text, out int codigo))
            {
                BEClsUsuario usuarioEliminar = new BEClsUsuario { Codigo = codigo };

                if (bllUsuario.Baja(usuarioEliminar))
                {
                    MessageBox.Show("Usuario eliminado con éxito.");
                    CargarUsuarios();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.");
                }
            }
            else
            {
                MessageBox.Show("Código de usuario inválido.");
            }
        }

        private void btnBuscarXml_Click(object sender, EventArgs e)
        {
            string nombreBuscado = cmbUsuarioBuscar.Text;

            if (!string.IsNullOrEmpty(nombreBuscado))
            {
                List<BEClsUsuario> usuariosEncontrados = bllUsuario.Buscar(nombreBuscado);

                if (usuariosEncontrados.Any())
                {
                    dataGridView1.DataSource = usuariosEncontrados;
                }
                else
                {
                    MessageBox.Show("No se encontraron usuarios con ese nombre.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione o ingrese un nombre.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtCodigo.Text = row.Cells["Codigo"].Value.ToString();
                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtPassword.Clear(); // Limpiar el campo de contraseña
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }

        private bool ValidarEntrada(string usuario, string password, string nombre, string apellido)
        {
            string usuarioPattern = @"^[a-zA-Z0-9]{4,}$";
            string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$";
            string nombreApellidoPattern = @"^[a-zA-Z\s]{2,}$";

            if (!Regex.IsMatch(usuario, usuarioPattern))
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 4 caracteres alfanuméricos.");
                return false;
            }

            if (!Regex.IsMatch(password, passwordPattern))
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres, con letras y números.");
                return false;
            }

            if (!Regex.IsMatch(nombre, nombreApellidoPattern))
            {
                MessageBox.Show("El nombre debe tener al menos 2 caracteres y solo contener letras.");
                return false;
            }

            if (!Regex.IsMatch(apellido, nombreApellidoPattern))
            {
                MessageBox.Show("El apellido debe tener al menos 2 caracteres y solo contener letras.");
                return false;
            }

            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }

}
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;
using BE;

namespace Presentacion_IU
{
    public partial class UC_Login : UserControl
    {
        BLLClsUsuario bllUsuario;

        public UC_Login()
        {
            InitializeComponent();
            bllUsuario = new BLLClsUsuario();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPsw.Text;

            if (ValidarEntrada(usuario, password))
            {
                // Encriptar la contraseña antes de validarla
                string passwordEncriptada = BLLClsSeguridad.GenerarSHA(password);
                MessageBox.Show($"Contraseña encriptada: {passwordEncriptada}");

                // Pasar la contraseña encriptada al método ValidarUsuario
                BEClsUsuario user = bllUsuario.ValidarUsuario(usuario, passwordEncriptada);
                if (user != null)
                {
                    MessageBox.Show("Ingreso al sistema");
                    Menu ofm = new Menu();
                    ofm.Show();
                    ((Form)this.TopLevelControl).Hide(); // Ocultar el formulario padre
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
        }

        private bool ValidarEntrada(string usuario, string password)
        {
            string usuarioPattern = @"^[a-zA-Z0-9]{4,}$"; // Al menos 4 caracteres alfanuméricos
            string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$"; // Al menos 6 caracteres, con letras y números

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

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtUsuario.Text = string.Empty;
            this.txtPsw.Text = string.Empty;
        }
    }
}
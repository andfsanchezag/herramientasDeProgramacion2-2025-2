using ClubSocialExample.application.adapters.input;
using System;
using System.Windows.Forms;

namespace ClubSocialExample.infraestructure.GUI
{
    public partial class CreatePartnerForm : Form
    {
        private readonly AdminInputs adminInputs;

        public CreatePartnerForm(AdminInputs adminInputs)
        {
            this.adminInputs = adminInputs;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                adminInputs.CreatePartner(
                    txtNombre.Text,
                    txtDocumento.Text,
                    txtCelular.Text,
                    txtUsuario.Text,
                    txtContrasena.Text
                );
                MessageBox.Show("Socio creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
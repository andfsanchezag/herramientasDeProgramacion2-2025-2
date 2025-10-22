using ClubSocialExample.application.adapters.input;
using System;
using System.Windows.Forms;

namespace ClubSocialExample.infraestructure.GUI
{
    public partial class CreateGuestForm : Form
    {
        private readonly PartnerInputs partnerInputs;

        public CreateGuestForm(PartnerInputs partnerInputs)
        {
            InitializeComponent();
            this.partnerInputs = partnerInputs;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                partnerInputs.CreateGuest(
                    txtNombre.Text,
                    txtDocumento.Text,
                    txtCelular.Text,
                    txtUsuario.Text,
                    txtContrasena.Text
                );
                MessageBox.Show("Invitado creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
using ClubSocialExample.application.adapters.input;
using System;
using System.Windows.Forms;

namespace ClubSocialExample.infraestructure.GUI
{
    public partial class ActivateGuestForm : Form
    {
        private readonly PartnerInputs partnerInputs;

        public ActivateGuestForm(PartnerInputs partnerInputs)
        {
            InitializeComponent();
            this.partnerInputs = partnerInputs;
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                partnerInputs.ActivateGuest(txtDocumento.Text);
                MessageBox.Show("Invitado activado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
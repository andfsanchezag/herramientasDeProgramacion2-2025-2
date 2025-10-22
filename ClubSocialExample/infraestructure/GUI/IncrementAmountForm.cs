using ClubSocialExample.application.adapters.input;
using System;
using System.Windows.Forms;

namespace ClubSocialExample.infraestructure.GUI
{
    public partial class IncrementAmountForm : Form
    {
        private readonly PartnerInputs partnerInputs;

        public IncrementAmountForm(PartnerInputs partnerInputs)
        {
            InitializeComponent();
            this.partnerInputs = partnerInputs;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                partnerInputs.IncrementAmount(txtMonto.Text);
                MessageBox.Show("Monto incrementado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
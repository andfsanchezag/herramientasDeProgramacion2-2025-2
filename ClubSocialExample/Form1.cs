using ClubSocialExample.domain.model;
using ClubSocialExample.infraestructure.GUI;
using ClubSocialExample.infraestructure.config;
using System;
using System.Windows.Forms;

namespace ClubSocialExample
{
    public partial class Form1 : Form
    {
        private readonly Config config;

        public Form1(Config config)
        {
            InitializeComponent();
            this.config = config;
        }

        private void btnIniciarAdmin_Click(object sender, EventArgs e)
        {
            using var adminForm = new AdminForm(config.AdminInputs);
            adminForm.ShowDialog();
        }

        private void btnIniciarSocio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDocumento.Text))
            {
                MessageBox.Show("Por favor ingrese el documento del socio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var partner = config.PartnerPort.FindByDocument(new Partner { Document = long.Parse(txtDocumento.Text) });
                if (partner == null)
                {
                    MessageBox.Show("Socio no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using var partnerForm = new PartnerForm(config.PartnerInputs, partner, config.GuestPort);
                partnerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

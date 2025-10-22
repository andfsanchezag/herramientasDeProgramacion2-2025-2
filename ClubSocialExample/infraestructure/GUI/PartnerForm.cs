using ClubSocialExample.application.adapters.input;
using ClubSocialExample.domain.model;
using ClubSocialExample.domain.ports;
using System;
using System.Windows.Forms;

namespace ClubSocialExample.infraestructure.GUI
{
    public partial class PartnerForm : Form
    {
        private readonly PartnerInputs partnerInputs;
        private readonly GuestPort guestPort;
        private readonly Partner currentPartner;

        public PartnerForm(PartnerInputs partnerInputs, Partner partner, GuestPort guestPort)
        {
            InitializeComponent();
            this.partnerInputs = partnerInputs;
            this.currentPartner = partner;
            this.guestPort = guestPort;
            this.partnerInputs.SetPartner(partner);

            lblBienvenida.Text = $"Bienvenido, {partner.Name}";
            lblTipo.Text = $"Tipo de socio: {partner.Type}";
            lblMonto.Text = $"Monto actual: ${partner.Amount:N2}";
            UpdateGuestCount();
        }

        private void UpdateGuestCount()
        {
            int activeGuests = guestPort.CountActiveGuestsByPartner(currentPartner);
            lblInvitadosActivos.Text = $"Invitados activos: {activeGuests}";
        }

        private void btnIncrementarMonto_Click(object sender, EventArgs e)
        {
            using var form = new IncrementAmountForm(partnerInputs);
            form.ShowDialog();
            // Actualizar el monto mostrado después de incrementar
            lblMonto.Text = $"Monto actual: ${currentPartner.Amount:N2}";
        }

        private void btnCrearInvitado_Click(object sender, EventArgs e)
        {
            using var form = new CreateGuestForm(partnerInputs);
            form.ShowDialog();
            UpdateGuestCount();
        }

        private void btnActivarInvitado_Click(object sender, EventArgs e)
        {
            using var form = new ActivateGuestForm(partnerInputs);
            form.ShowDialog();
            UpdateGuestCount();
        }

        private void btnListaInvitados_Click(object sender, EventArgs e)
        {
            using var form = new GuestListForm(guestPort, currentPartner);
            form.ShowDialog();
            UpdateGuestCount();
        }
    }
}
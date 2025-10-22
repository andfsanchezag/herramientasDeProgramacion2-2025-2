using ClubSocialExample.domain.model;
using ClubSocialExample.domain.ports;
using System;
using System.Windows.Forms;

namespace ClubSocialExample.infraestructure.GUI
{
    public partial class GuestListForm : Form
    {
        private readonly GuestPort guestPort;
        private readonly Partner currentPartner;

        public GuestListForm(GuestPort guestPort, Partner partner = null)
        {
            InitializeComponent();
            this.guestPort = guestPort;
            this.currentPartner = partner;
            LoadGuests();
        }

        private void LoadGuests()
        {
            try
            {
                var guests = currentPartner != null ? 
                    guestPort.FindGuestsByPartner(currentPartner) : 
                    guestPort.FindActiveGuests();

                dgvGuests.DataSource = guests;
                lblTotalGuests.Text = $"Total de invitados: {guests.Count}";

                if (currentPartner != null)
                {
                    int activeGuests = guestPort.CountActiveGuestsByPartner(currentPartner);
                    lblActiveGuests.Text = $"Invitados activos: {activeGuests}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGuests();
        }
    }
}
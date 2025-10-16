using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubSocialExample.application.adapters.input;

namespace ClubSocialExample.infraestructure.GUI
{
    public partial class AdminForm : Form
    {
        private readonly AdminInputs adminInputs;

        public AdminForm(AdminInputs adminInputs)
        {
            this.adminInputs = adminInputs;
            InitializeComponent();
        }

        private void btnCrearSocio_Click(object sender, EventArgs e)
        {
            using (var form = new CreatePartnerForm(adminInputs))
            {
                form.ShowDialog();
            }
        }
    }
}

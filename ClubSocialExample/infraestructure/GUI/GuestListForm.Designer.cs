namespace ClubSocialExample.infraestructure.GUI
{
    partial class GuestListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvGuests = new DataGridView();
            lblTotalGuests = new Label();
            lblActiveGuests = new Label();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGuests).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(186, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Lista de Invitados";
            // 
            // dgvGuests
            // 
            dgvGuests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGuests.Location = new Point(12, 81);
            dgvGuests.Name = "dgvGuests";
            dgvGuests.ReadOnly = true;
            dgvGuests.RowTemplate.Height = 25;
            dgvGuests.Size = new Size(760, 368);
            dgvGuests.TabIndex = 1;
            // 
            // lblTotalGuests
            // 
            lblTotalGuests.AutoSize = true;
            lblTotalGuests.Location = new Point(12, 45);
            lblTotalGuests.Name = "lblTotalGuests";
            lblTotalGuests.Size = new Size(108, 15);
            lblTotalGuests.TabIndex = 2;
            lblTotalGuests.Text = "Total de invitados: 0";
            // 
            // lblActiveGuests
            // 
            lblActiveGuests.AutoSize = true;
            lblActiveGuests.Location = new Point(176, 45);
            lblActiveGuests.Name = "lblActiveGuests";
            lblActiveGuests.Size = new Size(112, 15);
            lblActiveGuests.TabIndex = 3;
            lblActiveGuests.Text = "Invitados activos: 0";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(672, 41);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 23);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Actualizar";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // GuestListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(btnRefresh);
            Controls.Add(lblActiveGuests);
            Controls.Add(lblTotalGuests);
            Controls.Add(dgvGuests);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(800, 500);
            Name = "GuestListForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lista de Invitados";
            ((System.ComponentModel.ISupportInitialize)dgvGuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvGuests;
        private Label lblTotalGuests;
        private Label lblActiveGuests;
        private Button btnRefresh;
    }
}
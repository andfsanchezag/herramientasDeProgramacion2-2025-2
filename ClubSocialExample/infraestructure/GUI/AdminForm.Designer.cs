namespace ClubSocialExample.infraestructure.GUI
{
    partial class AdminForm
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
            btnCrearSocio = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(241, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Panel de Administración";
            // 
            // btnCrearSocio
            // 
            btnCrearSocio.Location = new Point(12, 47);
            btnCrearSocio.Name = "btnCrearSocio";
            btnCrearSocio.Size = new Size(200, 30);
            btnCrearSocio.TabIndex = 1;
            btnCrearSocio.Text = "Registrar Nuevo Socio";
            btnCrearSocio.UseVisualStyleBackColor = true;
            btnCrearSocio.Click += btnCrearSocio_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(btnCrearSocio);
            Controls.Add(lblTitulo);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Administración";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnCrearSocio;
    }
}
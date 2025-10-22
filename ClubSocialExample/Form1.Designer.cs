namespace ClubSocialExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnIniciarAdmin = new Button();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            btnIniciarSocio = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(201, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Club Social - Bienvenido";
            // 
            // btnIniciarAdmin
            // 
            btnIniciarAdmin.Location = new Point(12, 47);
            btnIniciarAdmin.Name = "btnIniciarAdmin";
            btnIniciarAdmin.Size = new Size(200, 30);
            btnIniciarAdmin.TabIndex = 1;
            btnIniciarAdmin.Text = "Iniciar como Administrador";
            btnIniciarAdmin.UseVisualStyleBackColor = true;
            btnIniciarAdmin.Click += btnIniciarAdmin_Click;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(12, 100);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(121, 15);
            lblDocumento.TabIndex = 2;
            lblDocumento.Text = "Documento del Socio:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(12, 118);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(200, 23);
            txtDocumento.TabIndex = 3;
            // 
            // btnIniciarSocio
            // 
            btnIniciarSocio.Location = new Point(12, 147);
            btnIniciarSocio.Name = "btnIniciarSocio";
            btnIniciarSocio.Size = new Size(200, 30);
            btnIniciarSocio.TabIndex = 4;
            btnIniciarSocio.Text = "Iniciar como Socio";
            btnIniciarSocio.UseVisualStyleBackColor = true;
            btnIniciarSocio.Click += btnIniciarSocio_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(btnIniciarSocio);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Controls.Add(btnIniciarAdmin);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club Social";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnIniciarAdmin;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Button btnIniciarSocio;
    }
}

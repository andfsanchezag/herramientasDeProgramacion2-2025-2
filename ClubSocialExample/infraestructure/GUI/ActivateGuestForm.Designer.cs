namespace ClubSocialExample.infraestructure.GUI
{
    partial class ActivateGuestForm
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
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            btnActivar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(155, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Activar Invitado";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(12, 50);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(133, 15);
            lblDocumento.TabIndex = 1;
            lblDocumento.Text = "Documento del invitado:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(12, 68);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(260, 23);
            txtDocumento.TabIndex = 2;
            // 
            // btnActivar
            // 
            btnActivar.Location = new Point(116, 107);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(75, 23);
            btnActivar.TabIndex = 3;
            btnActivar.Text = "Activar";
            btnActivar.UseVisualStyleBackColor = true;
            btnActivar.Click += btnActivar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(197, 107);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ActivateGuestForm
            // 
            AcceptButton = btnActivar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(284, 142);
            Controls.Add(btnCancelar);
            Controls.Add(btnActivar);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ActivateGuestForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Activar Invitado";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Button btnActivar;
        private Button btnCancelar;
    }
}
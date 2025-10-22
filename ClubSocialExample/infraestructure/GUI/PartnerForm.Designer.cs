namespace ClubSocialExample.infraestructure.GUI
{
    partial class PartnerForm
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
            lblBienvenida = new Label();
            lblTipo = new Label();
            lblMonto = new Label();
            lblInvitadosActivos = new Label();
            btnIncrementarMonto = new Button();
            btnCrearInvitado = new Button();
            btnActivarInvitado = new Button();
            btnListaInvitados = new Button();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBienvenida.Location = new Point(12, 9);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(109, 25);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(14, 45);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(82, 15);
            lblTipo.TabIndex = 1;
            lblTipo.Text = "Tipo de socio: ";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(14, 69);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(84, 15);
            lblMonto.TabIndex = 2;
            lblMonto.Text = "Monto actual: ";
            // 
            // lblInvitadosActivos
            // 
            lblInvitadosActivos.AutoSize = true;
            lblInvitadosActivos.Location = new Point(14, 93);
            lblInvitadosActivos.Name = "lblInvitadosActivos";
            lblInvitadosActivos.Size = new Size(98, 15);
            lblInvitadosActivos.TabIndex = 3;
            lblInvitadosActivos.Text = "Invitados activos: ";
            // 
            // btnIncrementarMonto
            // 
            btnIncrementarMonto.Location = new Point(12, 125);
            btnIncrementarMonto.Name = "btnIncrementarMonto";
            btnIncrementarMonto.Size = new Size(200, 30);
            btnIncrementarMonto.TabIndex = 4;
            btnIncrementarMonto.Text = "Incrementar Monto";
            btnIncrementarMonto.UseVisualStyleBackColor = true;
            btnIncrementarMonto.Click += btnIncrementarMonto_Click;
            // 
            // btnCrearInvitado
            // 
            btnCrearInvitado.Location = new Point(12, 170);
            btnCrearInvitado.Name = "btnCrearInvitado";
            btnCrearInvitado.Size = new Size(200, 30);
            btnCrearInvitado.TabIndex = 5;
            btnCrearInvitado.Text = "Crear Invitado";
            btnCrearInvitado.UseVisualStyleBackColor = true;
            btnCrearInvitado.Click += btnCrearInvitado_Click;
            // 
            // btnActivarInvitado
            // 
            btnActivarInvitado.Location = new Point(12, 215);
            btnActivarInvitado.Name = "btnActivarInvitado";
            btnActivarInvitado.Size = new Size(200, 30);
            btnActivarInvitado.TabIndex = 6;
            btnActivarInvitado.Text = "Activar Invitado";
            btnActivarInvitado.UseVisualStyleBackColor = true;
            btnActivarInvitado.Click += btnActivarInvitado_Click;
            // 
            // btnListaInvitados
            // 
            btnListaInvitados.Location = new Point(12, 260);
            btnListaInvitados.Name = "btnListaInvitados";
            btnListaInvitados.Size = new Size(200, 30);
            btnListaInvitados.TabIndex = 7;
            btnListaInvitados.Text = "Ver Lista de Invitados";
            btnListaInvitados.UseVisualStyleBackColor = true;
            btnListaInvitados.Click += btnListaInvitados_Click;
            // 
            // PartnerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(btnListaInvitados);
            Controls.Add(btnActivarInvitado);
            Controls.Add(btnCrearInvitado);
            Controls.Add(btnIncrementarMonto);
            Controls.Add(lblInvitadosActivos);
            Controls.Add(lblMonto);
            Controls.Add(lblTipo);
            Controls.Add(lblBienvenida);
            Name = "PartnerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Socio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Label lblTipo;
        private Label lblMonto;
        private Label lblInvitadosActivos;
        private Button btnIncrementarMonto;
        private Button btnCrearInvitado;
        private Button btnActivarInvitado;
        private Button btnListaInvitados;
    }
}
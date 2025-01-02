namespace CapaPresentacion
{
    partial class FormConfirmacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMensaje;
        private WsControls.WsButton btnCerrarSesion;
        private WsControls.WsButton btnSalir;
        private WsControls.WsButton btnCancelar;

        private Panel panelBorde;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfirmacion));
            panelBorde = new Panel();
            panelInterno = new Panel();
            lblMensaje = new Label();
            btnCerrarSesion = new WsControls.WsButton();
            btnSalir = new WsControls.WsButton();
            btnCancelar = new WsControls.WsButton();
            panelBorde.SuspendLayout();
            panelInterno.SuspendLayout();
            SuspendLayout();
            // 
            // panelBorde
            // 
            panelBorde.BackColor = Color.FromArgb(255, 20, 87);
            panelBorde.Controls.Add(panelInterno);
            panelBorde.Dock = DockStyle.Fill;
            panelBorde.Location = new Point(0, 0);
            panelBorde.Name = "panelBorde";
            panelBorde.Padding = new Padding(5);
            panelBorde.Size = new Size(350, 150);
            panelBorde.TabIndex = 0;
            // 
            // panelInterno
            // 
            panelInterno.BackColor = Color.FromArgb(69, 55, 69);
            panelInterno.Controls.Add(lblMensaje);
            panelInterno.Controls.Add(btnCerrarSesion);
            panelInterno.Controls.Add(btnSalir);
            panelInterno.Controls.Add(btnCancelar);
            panelInterno.Dock = DockStyle.Fill;
            panelInterno.Location = new Point(5, 5);
            panelInterno.Name = "panelInterno";
            panelInterno.Size = new Size(340, 140);
            panelInterno.TabIndex = 0;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensaje.ForeColor = Color.FromArgb(255, 20, 87);
            lblMensaje.Location = new Point(72, 33);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(199, 18);
            lblMensaje.TabIndex = 0;
            lblMensaje.Text = "¿Qué deseas hacer ahora?";
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(53, 49, 59);
            btnCerrarSesion.BackgroundColor = Color.FromArgb(53, 49, 59);
            btnCerrarSesion.BorderColor = Color.FromArgb(255, 20, 87);
            btnCerrarSesion.BorderSize = 1;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrarSesion.ForeColor = Color.FromArgb(255, 20, 87);
            btnCerrarSesion.Location = new Point(18, 73);
            btnCerrarSesion.Margin = new Padding(3, 2, 3, 2);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(97, 30);
            btnCerrarSesion.TabIndex = 33;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.TextColor = Color.FromArgb(255, 20, 87);
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(53, 49, 59);
            btnSalir.BackgroundColor = Color.FromArgb(53, 49, 59);
            btnSalir.BorderColor = Color.FromArgb(255, 20, 87);
            btnSalir.BorderSize = 1;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.FromArgb(255, 20, 87);
            btnSalir.Location = new Point(121, 73);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(97, 30);
            btnSalir.TabIndex = 34;
            btnSalir.Text = "Salir";
            btnSalir.TextColor = Color.FromArgb(255, 20, 87);
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(53, 49, 59);
            btnCancelar.BackgroundColor = Color.FromArgb(53, 49, 59);
            btnCancelar.BorderColor = Color.FromArgb(255, 20, 87);
            btnCancelar.BorderSize = 1;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(255, 20, 87);
            btnCancelar.Location = new Point(224, 73);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 30);
            btnCancelar.TabIndex = 35;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextColor = Color.FromArgb(255, 20, 87);
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormConfirmacion
            // 
            ClientSize = new Size(350, 150);
            Controls.Add(panelBorde);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormConfirmacion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirmación";
            panelBorde.ResumeLayout(false);
            panelInterno.ResumeLayout(false);
            panelInterno.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelInterno;

        #endregion
    }
}
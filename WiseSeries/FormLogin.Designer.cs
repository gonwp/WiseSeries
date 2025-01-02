namespace CapaPresentacion
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            chkRememberMe = new CheckBox();
            btnLogin = new WsControls.WsButton();
            lblTitulo = new Label();
            btnGoogleLogin = new WsControls.WsButton();
            panel1 = new Panel();
            txtConfirmPasswordRegister = new WsControls.WsTextBox();
            txtNombre = new WsControls.WsTextBox();
            txtPasswordRegister = new WsControls.WsTextBox();
            btnRegister = new WsControls.WsButton();
            txtEmailRegister = new WsControls.WsTextBox();
            lblRegister = new Label();
            txtEmail = new WsControls.WsTextBox();
            txtPassword = new WsControls.WsTextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            lblMinimizar = new Label();
            lblCerrar = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkRememberMe.ForeColor = Color.FromArgb(255, 20, 87);
            chkRememberMe.Location = new Point(56, 185);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(98, 19);
            chkRememberMe.TabIndex = 5;
            chkRememberMe.Text = "Recuerdame";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 20, 87);
            btnLogin.BackgroundColor = Color.FromArgb(255, 20, 87);
            btnLogin.BorderColor = Color.Black;
            btnLogin.BorderRadius = 30;
            btnLogin.BorderSize = 1;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Desktop;
            btnLogin.Location = new Point(74, 214);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(170, 35);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.TextColor = SystemColors.Desktop;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(255, 20, 87);
            lblTitulo.Location = new Point(105, 56);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(103, 36);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "Log In";
            // 
            // btnGoogleLogin
            // 
            btnGoogleLogin.BackColor = Color.White;
            btnGoogleLogin.BackgroundColor = Color.White;
            btnGoogleLogin.BorderColor = Color.Black;
            btnGoogleLogin.BorderRadius = 30;
            btnGoogleLogin.BorderSize = 1;
            btnGoogleLogin.FlatAppearance.BorderSize = 0;
            btnGoogleLogin.FlatStyle = FlatStyle.Flat;
            btnGoogleLogin.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGoogleLogin.ForeColor = Color.Black;
            btnGoogleLogin.Image = (Image)resources.GetObject("btnGoogleLogin.Image");
            btnGoogleLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnGoogleLogin.Location = new Point(74, 253);
            btnGoogleLogin.Margin = new Padding(3, 2, 3, 2);
            btnGoogleLogin.Name = "btnGoogleLogin";
            btnGoogleLogin.Padding = new Padding(7, 0, 0, 0);
            btnGoogleLogin.Size = new Size(170, 35);
            btnGoogleLogin.TabIndex = 9;
            btnGoogleLogin.Text = "         Continuar con Google";
            btnGoogleLogin.TextColor = Color.Black;
            btnGoogleLogin.UseVisualStyleBackColor = false;
            btnGoogleLogin.Click += BtnGoogleRegister_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(69, 55, 69);
            panel1.Controls.Add(txtConfirmPasswordRegister);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(txtPasswordRegister);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(txtEmailRegister);
            panel1.Controls.Add(lblRegister);
            panel1.Location = new Point(322, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 333);
            panel1.TabIndex = 13;
            // 
            // txtConfirmPasswordRegister
            // 
            txtConfirmPasswordRegister.BackColor = Color.MintCream;
            txtConfirmPasswordRegister.BorderColor = Color.FromArgb(255, 20, 87);
            txtConfirmPasswordRegister.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtConfirmPasswordRegister.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPasswordRegister.ForeColor = Color.DimGray;
            txtConfirmPasswordRegister.Location = new Point(34, 221);
            txtConfirmPasswordRegister.Name = "txtConfirmPasswordRegister";
            txtConfirmPasswordRegister.Padding = new Padding(7);
            txtConfirmPasswordRegister.PasswordChar = true;
            txtConfirmPasswordRegister.PlaceholderText = "Confirmar Contraseña";
            txtConfirmPasswordRegister.Size = new Size(194, 30);
            txtConfirmPasswordRegister.TabIndex = 26;
            txtConfirmPasswordRegister.Texts = "";
            txtConfirmPasswordRegister.UnderlinedStyle = true;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.MintCream;
            txtNombre.BorderColor = Color.FromArgb(255, 20, 87);
            txtNombre.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtNombre.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.ForeColor = Color.DimGray;
            txtNombre.Location = new Point(34, 113);
            txtNombre.Name = "txtNombre";
            txtNombre.Padding = new Padding(7);
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(194, 30);
            txtNombre.TabIndex = 23;
            txtNombre.Texts = "";
            txtNombre.UnderlinedStyle = true;
            // 
            // txtPasswordRegister
            // 
            txtPasswordRegister.BackColor = Color.MintCream;
            txtPasswordRegister.BorderColor = Color.FromArgb(255, 20, 87);
            txtPasswordRegister.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtPasswordRegister.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPasswordRegister.ForeColor = Color.DimGray;
            txtPasswordRegister.Location = new Point(34, 185);
            txtPasswordRegister.Name = "txtPasswordRegister";
            txtPasswordRegister.Padding = new Padding(7);
            txtPasswordRegister.PasswordChar = true;
            txtPasswordRegister.PlaceholderText = "Contraseña";
            txtPasswordRegister.Size = new Size(194, 30);
            txtPasswordRegister.TabIndex = 25;
            txtPasswordRegister.Texts = "";
            txtPasswordRegister.UnderlinedStyle = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(255, 20, 87);
            btnRegister.BackgroundColor = Color.FromArgb(255, 20, 87);
            btnRegister.BorderColor = Color.Black;
            btnRegister.BorderRadius = 30;
            btnRegister.BorderSize = 1;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = SystemColors.Desktop;
            btnRegister.Location = new Point(44, 256);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(170, 35);
            btnRegister.TabIndex = 20;
            btnRegister.Text = "Registrarse";
            btnRegister.TextColor = SystemColors.Desktop;
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;
            // 
            // txtEmailRegister
            // 
            txtEmailRegister.BackColor = Color.MintCream;
            txtEmailRegister.BorderColor = Color.FromArgb(255, 20, 87);
            txtEmailRegister.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtEmailRegister.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmailRegister.ForeColor = Color.DimGray;
            txtEmailRegister.Location = new Point(34, 149);
            txtEmailRegister.Name = "txtEmailRegister";
            txtEmailRegister.Padding = new Padding(7);
            txtEmailRegister.PlaceholderText = "Email";
            txtEmailRegister.Size = new Size(194, 30);
            txtEmailRegister.TabIndex = 24;
            txtEmailRegister.Texts = "";
            txtEmailRegister.UnderlinedStyle = true;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegister.ForeColor = Color.FromArgb(255, 20, 87);
            lblRegister.Location = new Point(52, 59);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(154, 32);
            lblRegister.TabIndex = 22;
            lblRegister.Text = "Registrarse";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.MintCream;
            txtEmail.BorderColor = Color.FromArgb(255, 20, 87);
            txtEmail.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtEmail.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.DimGray;
            txtEmail.Location = new Point(56, 113);
            txtEmail.Name = "txtEmail";
            txtEmail.Padding = new Padding(7);
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(204, 30);
            txtEmail.TabIndex = 15;
            txtEmail.Texts = "";
            txtEmail.UnderlinedStyle = true;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.MintCream;
            txtPassword.BorderColor = Color.FromArgb(255, 20, 87);
            txtPassword.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtPassword.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Location = new Point(56, 149);
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(7);
            txtPassword.PasswordChar = true;
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(204, 30);
            txtPassword.TabIndex = 16;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(36, 66, 57);
            pictureBox1.Location = new Point(707, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(12, 12);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(36, 66, 57);
            pictureBox2.Location = new Point(683, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(12, 12);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 30;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(43, 44, 48);
            panel2.Controls.Add(lblMinimizar);
            panel2.Controls.Add(lblCerrar);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(584, 25);
            panel2.TabIndex = 39;
            // 
            // lblMinimizar
            // 
            lblMinimizar.AutoSize = true;
            lblMinimizar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMinimizar.ForeColor = Color.FromArgb(255, 20, 87);
            lblMinimizar.Location = new Point(537, 1);
            lblMinimizar.Name = "lblMinimizar";
            lblMinimizar.Size = new Size(18, 19);
            lblMinimizar.TabIndex = 41;
            lblMinimizar.Text = "_";
            lblMinimizar.Click += pbMinimizar_Click;
            // 
            // lblCerrar
            // 
            lblCerrar.AutoSize = true;
            lblCerrar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCerrar.ForeColor = Color.FromArgb(255, 20, 87);
            lblCerrar.Location = new Point(560, 3);
            lblCerrar.Name = "lblCerrar";
            lblCerrar.Size = new Size(20, 19);
            lblCerrar.TabIndex = 40;
            lblCerrar.Text = "X";
            lblCerrar.Click += pbCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 20, 87);
            label3.Location = new Point(10, 4);
            label3.Name = "label3";
            label3.Size = new Size(74, 16);
            label3.TabIndex = 40;
            label3.Text = "WiseSeries";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 49, 59);
            ClientSize = new Size(584, 331);
            Controls.Add(panel2);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(btnGoogleLogin);
            Controls.Add(panel1);
            Controls.Add(lblTitulo);
            Controls.Add(btnLogin);
            Controls.Add(chkRememberMe);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            TransparencyKey = Color.MediumVioletRed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkRememberMe;
        private WsControls.WsButton btnLogin;
        private Label lblTitulo;
        private WsControls.WsButton btnGoogleLogin;
        private Panel panel1;
        private WsControls.WsTextBox txtEmail;
        private WsControls.WsTextBox txtPassword;
        private WsControls.WsTextBox txtConfirmPasswordRegister;
        private WsControls.WsTextBox txtNombre;
        private WsControls.WsTextBox txtPasswordRegister;
        private WsControls.WsButton btnRegister;
        private WsControls.WsTextBox txtEmailRegister;
        private Label lblRegister;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label label3;
        private Label lblCerrar;
        private Label lblMinimizar;
    }
}
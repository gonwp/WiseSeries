using CapaPresentacion.WsControls;

namespace WiseSeries
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAnimes;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            dgvAnimes = new DataGridView();
            btnEliminar = new WsButton();
            cbGenero = new WsComboBox();
            txtTemporada = new WsTextBox();
            txtEpisodio = new WsTextBox();
            txtTitulo = new WsTextBox();
            btnConfirmar = new WsButton();
            chkCompletado = new CheckBox();
            label2 = new Label();
            panel1 = new Panel();
            lblMinimizar = new Label();
            lblCerrar = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAnimes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAnimes
            // 
            dgvAnimes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAnimes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAnimes.BackgroundColor = Color.FromArgb(43, 44, 48);
            dgvAnimes.BorderStyle = BorderStyle.None;
            dgvAnimes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 20, 87);
            dataGridViewCellStyle1.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(97, 60, 76);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAnimes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAnimes.ColumnHeadersHeight = 30;
            dgvAnimes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAnimes.EnableHeadersVisualStyles = false;
            dgvAnimes.GridColor = Color.FromArgb(255, 20, 87);
            dgvAnimes.Location = new Point(12, 36);
            dgvAnimes.Name = "dgvAnimes";
            dgvAnimes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 20, 87);
            dataGridViewCellStyle2.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(97, 60, 76);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAnimes.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAnimes.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(43, 44, 48);
            dataGridViewCellStyle3.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(97, 60, 76);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgvAnimes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvAnimes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimes.Size = new Size(421, 312);
            dgvAnimes.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 20, 87);
            btnEliminar.BackgroundColor = Color.FromArgb(255, 20, 87);
            btnEliminar.BorderColor = SystemColors.Desktop;
            btnEliminar.BorderRadius = 30;
            btnEliminar.BorderSize = 1;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = SystemColors.Desktop;
            btnEliminar.Location = new Point(579, 257);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 32);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextColor = SystemColors.Desktop;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // cbGenero
            // 
            cbGenero.BackColor = Color.MintCream;
            cbGenero.BorderColor = Color.FromArgb(255, 20, 87);
            cbGenero.BorderSize = 2;
            cbGenero.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbGenero.ForeColor = Color.DimGray;
            cbGenero.IconColor = Color.FromArgb(255, 20, 87);
            cbGenero.ListBackColor = Color.MintCream;
            cbGenero.Location = new Point(476, 125);
            cbGenero.MinimumSize = new Size(200, 30);
            cbGenero.Name = "cbGenero";
            cbGenero.Padding = new Padding(2);
            cbGenero.Size = new Size(204, 30);
            cbGenero.TabIndex = 36;
            // 
            // txtTemporada
            // 
            txtTemporada.BackColor = Color.MintCream;
            txtTemporada.BorderColor = Color.FromArgb(255, 20, 87);
            txtTemporada.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtTemporada.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTemporada.ForeColor = Color.DimGray;
            txtTemporada.Location = new Point(476, 197);
            txtTemporada.Name = "txtTemporada";
            txtTemporada.Padding = new Padding(7);
            txtTemporada.PlaceholderText = "Temporada";
            txtTemporada.Size = new Size(204, 30);
            txtTemporada.TabIndex = 35;
            txtTemporada.UnderlinedStyle = true;
            // 
            // txtEpisodio
            // 
            txtEpisodio.BackColor = Color.MintCream;
            txtEpisodio.BorderColor = Color.FromArgb(255, 20, 87);
            txtEpisodio.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtEpisodio.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEpisodio.ForeColor = Color.DimGray;
            txtEpisodio.Location = new Point(476, 161);
            txtEpisodio.Name = "txtEpisodio";
            txtEpisodio.Padding = new Padding(7);
            txtEpisodio.PlaceholderText = "Episodio";
            txtEpisodio.Size = new Size(204, 30);
            txtEpisodio.TabIndex = 34;
            txtEpisodio.UnderlinedStyle = true;
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = Color.MintCream;
            txtTitulo.BorderColor = Color.FromArgb(255, 20, 87);
            txtTitulo.BorderFocusColor = Color.FromArgb(97, 60, 76);
            txtTitulo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitulo.ForeColor = Color.DimGray;
            txtTitulo.Location = new Point(476, 89);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Padding = new Padding(7);
            txtTitulo.PlaceholderText = "Título";
            txtTitulo.Size = new Size(204, 30);
            txtTitulo.TabIndex = 33;
            txtTitulo.UnderlinedStyle = true;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(255, 20, 87);
            btnConfirmar.BackgroundColor = Color.FromArgb(255, 20, 87);
            btnConfirmar.BorderColor = SystemColors.Desktop;
            btnConfirmar.BorderRadius = 30;
            btnConfirmar.BorderSize = 1;
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirmar.ForeColor = SystemColors.Desktop;
            btnConfirmar.Location = new Point(476, 257);
            btnConfirmar.Margin = new Padding(3, 2, 3, 2);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(100, 32);
            btnConfirmar.TabIndex = 32;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.TextColor = SystemColors.Desktop;
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // chkCompletado
            // 
            chkCompletado.AutoSize = true;
            chkCompletado.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkCompletado.ForeColor = Color.FromArgb(255, 20, 87);
            chkCompletado.Location = new Point(476, 233);
            chkCompletado.Name = "chkCompletado";
            chkCompletado.Size = new Size(94, 19);
            chkCompletado.TabIndex = 31;
            chkCompletado.Text = "Completado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 20, 87);
            label2.Location = new Point(494, 50);
            label2.Name = "label2";
            label2.Size = new Size(169, 24);
            label2.TabIndex = 37;
            label2.Text = "Gestionar Series";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 44, 48);
            panel1.Controls.Add(lblMinimizar);
            panel1.Controls.Add(lblCerrar);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(731, 25);
            panel1.TabIndex = 38;
            // 
            // lblMinimizar
            // 
            lblMinimizar.AutoSize = true;
            lblMinimizar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMinimizar.ForeColor = Color.FromArgb(255, 20, 87);
            lblMinimizar.Location = new Point(683, 2);
            lblMinimizar.Name = "lblMinimizar";
            lblMinimizar.Size = new Size(18, 19);
            lblMinimizar.TabIndex = 43;
            lblMinimizar.Text = "_";
            lblMinimizar.Click += pbMinimizar_Click;
            // 
            // lblCerrar
            // 
            lblCerrar.AutoSize = true;
            lblCerrar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCerrar.ForeColor = Color.FromArgb(255, 20, 87);
            lblCerrar.Location = new Point(706, 4);
            lblCerrar.Name = "lblCerrar";
            lblCerrar.Size = new Size(20, 19);
            lblCerrar.TabIndex = 42;
            lblCerrar.Text = "X";
            lblCerrar.Click += pbCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(43, 44, 48);
            label3.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 20, 87);
            label3.Location = new Point(9, 4);
            label3.Name = "label3";
            label3.Size = new Size(74, 16);
            label3.TabIndex = 39;
            label3.Text = "WiseSeries";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(69, 55, 69);
            ClientSize = new Size(730, 359);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbGenero);
            Controls.Add(txtTemporada);
            Controls.Add(txtEpisodio);
            Controls.Add(txtTitulo);
            Controls.Add(btnConfirmar);
            Controls.Add(chkCompletado);
            Controls.Add(btnEliminar);
            Controls.Add(dgvAnimes);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WiseAnime";
            ((System.ComponentModel.ISupportInitialize)dgvAnimes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private WsButton btnEliminar;
        private WsComboBox cbGenero;
        private WsTextBox txtTemporada;
        private WsTextBox txtEpisodio;
        private WsButton btnConfirmar;
        private CheckBox chkCompletado;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private WsTextBox txtTitulo;
        private Label lblMinimizar;
        private Label lblCerrar;
    }
}

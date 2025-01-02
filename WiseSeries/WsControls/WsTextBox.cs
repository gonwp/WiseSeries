using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion.WsControls
{
    [DefaultEvent("_TextChanged")]
    public partial class WsTextBox : UserControl
    {
        // Fields
        private Color borderColor = Color.MediumSeaGreen;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;
        private string placeholderText = "Placeholder";
        private bool isPlaceholderActive = true;
        private bool isPasswordChar = false;

        // Constructor
        public WsTextBox()
        {
            InitializeComponent();
            textBox1.Text = placeholderText;
            textBox1.ForeColor = Color.Gray;
            textBox1.UseSystemPasswordChar = false;
            isPlaceholderActive = true;
        }

        // Events
        public event EventHandler _TextChanged;

        // Properties
        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        [DefaultValue(typeof(Color), "MediumSeaGreen")] // Valor por defecto para el diseñador
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        [DefaultValue(2)] // Valor por defecto para el diseñador
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        public bool UnderlinedStyle
        {
            get => underlinedStyle;
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        public bool PasswordChar
        {
            get => isPasswordChar;
            set
            {
                isPasswordChar = value;
                if (!isPlaceholderActive)
                {
                    textBox1.UseSystemPasswordChar = isPasswordChar;
                }
            }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        [DefaultValue("Placeholder")] // Valor por defecto para el placeholder
        public string Texts
        {
            get => isPlaceholderActive ? string.Empty : textBox1.Text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    isPlaceholderActive = true;
                    textBox1.Text = placeholderText;
                    textBox1.ForeColor = Color.Gray;
                    textBox1.UseSystemPasswordChar = false;
                }
                else
                {
                    isPlaceholderActive = false;
                    textBox1.Text = value;
                    textBox1.ForeColor = this.ForeColor;
                    textBox1.UseSystemPasswordChar = isPasswordChar;
                }
            }
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        public Color BorderFocusColor
        {
            get => borderFocusColor;
            set => borderFocusColor = value;
        }

        [Category("Wise Code Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Asegura la serialización
        [DefaultValue("Placeholder")] // Valor por defecto para el placeholder
        public string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                if (isPlaceholderActive)
                {
                    textBox1.Text = placeholderText;
                }
                Invalidate();
            }
        }

        // Overridden methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            // Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (!isFocused)
                {
                    if (underlinedStyle)
                    {
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }
                else
                {
                    penBorder.Color = BorderFocusColor;

                    if (underlinedStyle)
                    {
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        // Private methods
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            if (isPlaceholderActive)
            {
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                textBox1.UseSystemPasswordChar = isPasswordChar; // Activate masking if applicable
                isPlaceholderActive = false;
            }
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = placeholderText;
                textBox1.ForeColor = Color.Gray;
                textBox1.UseSystemPasswordChar = false; // Deactivate masking to show placeholder
                isPlaceholderActive = true;
            }
            this.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isPlaceholderActive && _TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        public void Clear()
        {
            // Limpiar el texto y restablecer el placeholder si está activo
            textBox1.Text = string.Empty;
            textBox1.ForeColor = Color.Gray; // Cambiar el color del texto al color del placeholder
            textBox1.UseSystemPasswordChar = false; // Desactivar la máscara de contraseña si estaba activa
            isPlaceholderActive = true;
            textBox1.Text = placeholderText; // Mostrar el texto del placeholder
        }
    }
}

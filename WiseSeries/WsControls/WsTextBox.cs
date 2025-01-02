using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public WsTextBox()
        {
            InitializeComponent();
            textBox1.Text = placeholderText;
            textBox1.ForeColor = Color.Gray;
            isPlaceholderActive = true;
        }

        // Events
        public event EventHandler _TextChanged;

        // Properties
        [Category("Ws Custom Properties"), DefaultValue(typeof(Color), "MediumSeaGreen"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Ws Custom Properties"), DefaultValue(2), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Ws Custom Properties"), DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool UnderlinedStyle
        {
            get => underlinedStyle;
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Ws Custom Properties"), DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        [Category("Ws Custom Properties"), DefaultValue("Placeholder"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        [Category("Ws Custom Properties"), DefaultValue(typeof(Color), "HotPink"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderFocusColor
        {
            get => borderFocusColor;
            set => borderFocusColor = value;
        }

        [Category("Ws Custom Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        private bool ShouldSerializeBackColor() => BackColor != Color.White;
        private void ResetBackColor() => BackColor = Color.White;


        [Category("Ws Custom Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Color), "Black")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        private bool ShouldSerializeForeColor() => ForeColor != Color.Black;
        private void ResetForeColor() => ForeColor = Color.Black;


        [Category("Ws Custom Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
        public override Font Font
        {
            get => base.Font;
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

        private bool ShouldSerializeFont() => Font != new Font("Microsoft Sans Serif", 8.25f);
        private void ResetFont() => Font = new Font("Microsoft Sans Serif", 8.25f);

        [Category("Ws Custom Properties"), DefaultValue("")]
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

        // TextBox event handlers...
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

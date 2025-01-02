using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CapaPresentacion.WsControls
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public partial class WsComboBox : UserControl
    {
        // Fields
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;

        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        // Events
        public event EventHandler OnSelectedIndexChanged;

        // Constructor
        public WsComboBox()
        {
            InitializeControl();
        }

        private void InitializeControl()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();

            this.SuspendLayout();

            // ComboBox
            cmbList.BackColor = listBackColor;
            cmbList.ForeColor = listTextColor;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbList.TextChanged += ComboBox_TextChanged;
            cmbList.DropDownStyle = ComboBoxStyle.DropDownList;

            // Button Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += Icon_Click;
            btnIcon.Paint += Icon_Paint;

            // Label
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 10F);
            lblText.Click += Surface_Click;
            lblText.MouseEnter += Surface_MouseEnter;
            lblText.MouseLeave += Surface_MouseLeave;

            // User Control
            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.Padding = new Padding(borderSize);
            this.ForeColor = Color.DimGray;
            base.BackColor = borderColor;

            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = this.Width - this.Padding.Horizontal - btnIcon.Width;
            cmbList.Location = new Point(this.Padding.Left, lblText.Bottom);
            cmbList.Visible = false;
        }

        // Event Handlers
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;
            OnSelectedIndexChanged?.Invoke(sender, e);
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = !cmbList.DroppedDown;
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
            cmbList.Select();
            if (!cmbList.DroppedDown)
            {
                cmbList.DroppedDown = true;
            }
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 14;
            int iconHeight = 6;
            Rectangle rectIcon = new Rectangle(
                (btnIcon.Width - iconWidth) / 2,
                (btnIcon.Height - iconHeight) / 2,
                iconWidth,
                iconHeight);
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        // Properties
        [Category("WiseSeries Advance"), DefaultValue(typeof(Color), "WhiteSmoke"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color BackColor
        {
            get => backColor;
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }

        [Category("WiseSeries Advance"), DefaultValue(typeof(Color), "MediumSlateBlue"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color IconColor
        {
            get => iconColor;
            set
            {
                iconColor = value;
                btnIcon.Invalidate();
            }
        }

        [Category("WiseSeries Advance"), DefaultValue(typeof(Color), "230, 228, 245"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ListBackColor
        {
            get => listBackColor;
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }

        [Category("WiseSeries Advance"), DefaultValue(typeof(Color), "DimGray"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ListTextColor
        {
            get => listTextColor;
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }

        [Category("WiseSeries Advance"), DefaultValue(typeof(Color), "MediumSlateBlue"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                base.BackColor = borderColor;
            }
        }

        [Category("WiseSeries Advance"), DefaultValue(1), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize);
                AdjustComboBoxDimensions();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}

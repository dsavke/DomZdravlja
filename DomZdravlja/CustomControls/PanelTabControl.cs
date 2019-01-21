using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZdravlja
{
    public partial class PanelTabControl : UserControl
    {

        public event EventHandler ControlClick;

        public bool Selektovan
        {
            get;set;
        }

        public Image SelektovanIkona
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public Image Ikona
        {
            get
            {
                return ikonica.Image;
            }
            set
            {
                ikonica.Image = value;
            }
        }

        public String Naziv
        {
            get
            {
                return lblNaziv.Text;
            }
            set
            {
                lblNaziv.Text = value;
            }
        }

        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public PanelTabControl()
        {
            InitializeComponent();
        }

        public PanelTabControl(Image image, string naziv)
        {
            InitializeComponent();
            Ikona = image;
            Naziv = naziv;
            pictureBox1.Image = null;
        }

        private void PanelTabControl_MouseEnter(object sender, EventArgs e)
        { 
            if(!Selektovan)
                this.BackColor = Color.FromArgb(51, 128, 196);
        }

        private void PanelTabControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 67, 127);
        }

        private void PanelTabControl_Click(object sender, EventArgs e)
        {
            if (ControlClick != null)
                ControlClick(sender, e);
        }
    }
}

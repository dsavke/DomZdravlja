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

        public PanelTabControl()
        {
            InitializeComponent();
        }

        public PanelTabControl(Image image, string naziv)
        {
            InitializeComponent();
            Ikona = image;
            Naziv = naziv;
        }

        private void PanelTabControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(51, 128, 196);    
        }

        private void PanelTabControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 67, 127);
        }
    }
}

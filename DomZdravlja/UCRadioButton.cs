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
    public partial class UCRadioButton : UserControl
    {
        public UCRadioButton()
        {
            InitializeComponent();
        }

        public string Naziv
        {
            get { return lblNaziv.Text; }
            set { lblNaziv.Text = value; }
        }

        public string NazivOpcije1
        {
            get { return rbOpcija1.Text; }
            set { rbOpcija1.Text = value; }
        }

        public string NazivOpcije2
        {
            get { return rbOpcija2.Text; }
            set { rbOpcija2.Text = value; }
        }

        public string Vrijednost
        {
            get; set;
        }

        private void rbOpcija1_CheckedChanged(object sender, EventArgs e)
        {

            Vrijednost = rbOpcija1.Text;
            rbOpcija2.Checked = false;
            
        }

        private void rbOpcija2_CheckedChanged(object sender, EventArgs e)
        {
            Vrijednost = rbOpcija2.Text;
            rbOpcija1.Checked = false;
        }
    }
}

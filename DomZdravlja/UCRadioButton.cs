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
            rbOpcija1.Checked = true;
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

        public bool Vrijednost
        {
            get; private set;
        }

        public void postavi(int i)
        {
            if (i == 1) rbOpcija1.Checked = true;
            else rbOpcija2.Checked = true;
        }

        private void rbOpcija1_CheckedChanged(object sender, EventArgs e)
        {
            Vrijednost = true;
           // rbOpcija2.Checked = false;
        }

        private void rbOpcija2_CheckedChanged(object sender, EventArgs e)
        {
            Vrijednost = false;
            //rbOpcija1.Checked = false;
        }
    }
}

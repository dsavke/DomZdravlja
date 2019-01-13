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
    public partial class UCTekst : UserControl
    {

        public UCTekst()
        {
            InitializeComponent();
            //txtValue.BackColor = Color.White;
            //txtValue.ForeColor = Color.FromArgb(51, 128, 196);
        }

        public string Naziv
        {
            get { return lblNaziv.Text; }
            set { lblNaziv.Text = value; }
        }
        
        public string Value
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value; }
        }

        public bool Greska
        {
            get { return lblGreska.Visible; }
            set { lblGreska.Visible = value; }
        }

        public event EventHandler UCTekstTextChanged;

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (UCTekstTextChanged != null)
                UCTekstTextChanged(sender, e);
        }

        public void setReadOnly()
        {
            txtValue.ReadOnly = true;
            //txtValue.BackColor = Color.FromKnownColor(KnownColor.Control);
           // txtValue.ForeColor = Color.FromArgb(51, 128, 196);
        }
    }
}

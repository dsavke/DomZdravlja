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
    public partial class UCLookup : UserControl
    {
        public UCLookup()
        {
            InitializeComponent();
        }

        public string Naziv
        {
            get { return lblNaziv.Text; }
            set { lblNaziv.Text = value; }
        }

        public string Value
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        public string Info
        {
            get { return txtNaziv.Text; }
            set { txtNaziv.Text = value; }
        }

        public event EventHandler LookupClick;

        private void btnLookUP_Click(object sender, EventArgs e)
        {
            if (LookupClick != null)
                LookupClick(sender, e);
        }
    }
}

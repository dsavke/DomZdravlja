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

        public string ThisTable
        {
            get; set;
        }

        public string ThisColumn
        {
            get; set;
        }

        public event EventHandler LookupClick;
        public event EventHandler LookupTextChanged;

        private void btnLookUP_Click(object sender, EventArgs e)
        {
            if (LookupClick != null)
                LookupClick(sender, e);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (LookupTextChanged != null)
                LookupTextChanged(sender, e);
        }
    }
}

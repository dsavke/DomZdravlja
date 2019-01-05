using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZdravlja.CustomControls
{
    public partial class PocetnaStrana : UserControl
    {
        PropertyInterface myProperty;
        public PocetnaStrana(PropertyInterface myProperty)
        {

            InitializeComponent();
            this.myProperty = myProperty;

        }

        public PocetnaStrana()
        {
            InitializeComponent();
        }
        public string Ime
        {
            get { return lblIme.Text; }
            set { lblIme.Text = value; }
        }
        public string Prezime
        {
            get { return lblPrezime.Text; }
            set { lblPrezime.Text = value; }
        }
        public string TipZaposlenog
        {
            get { return lblTipZaposlenog.Text; }
            set { lblTipZaposlenog.Text = value; }
        }

        private void btnSifra_Click(object sender, EventArgs e)
        {
            panel2.Show();
            btnSifra.Click -= btnSifra_Click;
            btnSifra.Click += BtnSifraSakrij_Click;
            btnSifra.Text = "Sakrij sifru";
        }

        private void BtnSifraSakrij_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            btnSifra.Text = "Promijeni sifru";
            btnSifra.Click -= BtnSifraSakrij_Click;
            btnSifra.Click += btnSifra_Click;
        }
    }
}

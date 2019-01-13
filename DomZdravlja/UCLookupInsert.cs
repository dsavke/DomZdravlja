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
    public partial class UCLookupInsert : UserControl
    {
        public UCLookupInsert()
        {
            InitializeComponent();
            btnLookUP.FlatAppearance.BorderSize = 0;
            btnLookUP.BackColor = Color.White;
            btnLookUP.FlatStyle = FlatStyle.Flat;

            btnDodaj.FlatAppearance.BorderSize = 0;
            btnDodaj.BackColor = Color.White;
            btnDodaj.FlatStyle = FlatStyle.Flat;

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

        public bool Greska
        {
            get { return lblGreska.Visible; }
            set { lblGreska.Visible = value; }
        }

        public Use Use
        {
            get; set;
        }

        public event EventHandler LookupControlClick;

        private void btnLookUP_Click(object sender, EventArgs e)
        {
            if (LookupControlClick != null)
                LookupControlClick(sender, e);
        }

        public event EventHandler DodajControlClick;

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (DodajControlClick != null)
                DodajControlClick(sender, e);
        }

        public void setReadOnly()
        {
            btnLookUP.Enabled = false;
            btnDodaj.Enabled = false;
        }

        public void setEdit()
        {
            btnLookUP.Enabled = false;
            btnDodaj.Text = "";
            btnDodaj.Image = DomZdravlja.Properties.Resources.edit_new;
            btnDodaj.ImageAlign = ContentAlignment.MiddleCenter;

        }

    }
}

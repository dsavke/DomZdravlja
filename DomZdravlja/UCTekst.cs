﻿using System;
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

        public event EventHandler UCTekstTextChanged;

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (UCTekstTextChanged != null)
                UCTekstTextChanged(sender, e);
        }
    }
}

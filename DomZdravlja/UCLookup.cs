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

        

    }
}

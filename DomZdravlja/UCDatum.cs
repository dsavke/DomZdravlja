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
    public partial class UCDatum : UserControl
    {
        public UCDatum()
        {
            InitializeComponent();
        }

        public string Naziv
        {
            get { return lblNaziv.Text;}
            set { lblNaziv.Text = value; }
        }

        public DateTime Value
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
    }
}

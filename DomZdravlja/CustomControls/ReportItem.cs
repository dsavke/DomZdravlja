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
    public partial class ReportItem : UserControl
    {

        public Image SlikaIzvjestaja
        {
            get { return pibSlikaIzvjestaja.Image; }
            set { pibSlikaIzvjestaja.Image = value; }
        }

        public string NazivIzvjestaja
        {
            get { return lblNazivIzvjestaja.Text; }
            set { lblNazivIzvjestaja.Text = value; }
        }

        public int IzvjestajID
        {
            get; set;
        }

        public ReportItem()
        {
            InitializeComponent();
        }

        public ReportItem(Image slikaIzvjestaja, string nazivIzvjestaja)
        {
            InitializeComponent();
            SlikaIzvjestaja = slikaIzvjestaja;
            NazivIzvjestaja = nazivIzvjestaja;
        }

        public event EventHandler ReportItemClick;

        private void ReportItem_Click(object sender, EventArgs e)
        {
            if (ReportItemClick != null)
                ReportItemClick(sender, e);
        }
    }
}

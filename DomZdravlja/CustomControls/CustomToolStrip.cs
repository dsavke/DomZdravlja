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
    public partial class CustomToolStrip : UserControl
    {

        PropertyInterface PropertyInterface;

        public event EventHandler DodajClick;
        public event EventHandler PretragaClick;
        public event EventHandler AzurirajClick;
        public event EventHandler ObrisiClick;

        public event EventHandler PrviClick;
        public event EventHandler DoleClick;
        public event EventHandler GoreClick;
        public event EventHandler ZadnjiClick;

        public bool Gore
        {
            get { return tsbtnGore.Enabled; }
            set { tsbtnGore.Enabled = value; }
        }

        public bool Dole
        {
            get { return tsbtnDOle.Enabled; }
            set { tsbtnDOle.Enabled = value; }
        }

        public bool Prvi
        {
            get { return tsbtnPrvi.Enabled; }
            set { tsbtnPrvi.Enabled = value; }
        }

        public bool Zadnji
        {
            get { return tsbtnZadnji.Enabled; }
            set { tsbtnZadnji.Enabled = value; }
        }

        public bool Dodaj
        {
            get { return tsbtnDodaj.Enabled; }
            set { tsbtnDodaj.Enabled = value; }
        }

        public bool Azuriraj
        {
            get { return tsbtnAzuriraj.Enabled; }
            set { tsbtnAzuriraj.Enabled = value; }
        }

        public bool Pretraga
        {
            get { return tsbtnPretraga.Enabled; }
            set { tsbtnPretraga.Enabled = value; }
        }

        public bool Obrisi
        {
            get { return tsbtnObrisi.Enabled; }
            set { tsbtnObrisi.Enabled = value; }
        }

        public CustomToolStrip()
        {
            InitializeComponent();
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

        }

        public CustomToolStrip(PropertyInterface propertyInterface)
        {
            InitializeComponent();
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            PropertyInterface = propertyInterface;
        }

        private void tsbtnDodaj_Click(object sender, EventArgs e)
        {
            if (DodajClick != null)
                DodajClick(sender, e);
        }

        private void tsbtnPretraga_Click(object sender, EventArgs e)
        {
            if (PretragaClick != null)
                PretragaClick(sender, e);
        }

        private void tsbtnZadnji_Click(object sender, EventArgs e)
        {
            if (ZadnjiClick != null)
                ZadnjiClick(sender, e);
        }

        private void tsbtnDOle_Click(object sender, EventArgs e)
        {
            if (DoleClick != null)
                DoleClick(sender, e);
        }

        private void tsbtnGore_Click(object sender, EventArgs e)
        {
            if (GoreClick != null)
                GoreClick(sender, e);
        }

        private void tsbtnPrvi_Click(object sender, EventArgs e)
        {
            if (PrviClick != null)
                PrviClick(sender, e);
        }

        private void tsbtnAzuriraj_Click(object sender, EventArgs e)
        {
            if (AzurirajClick != null)
                AzurirajClick(sender, e);
        }

        private void tsbtnObrisi_Click(object sender, EventArgs e)
        {
            if (ObrisiClick != null)
                ObrisiClick(sender, e);
        }
    }
}

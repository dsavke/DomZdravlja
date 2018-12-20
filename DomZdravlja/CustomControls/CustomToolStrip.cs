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
            /* tabPage = new CustomTabPage() { State = State.Insert, Naziv = "DODAVANJE"};
            ((this.Parent as CustomTabPage).Parent as CustomTabControl).TabPages.Add(tabPage);*/
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

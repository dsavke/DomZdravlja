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
    }
}

using DomZdravlja.CustomControls;
using DomZdravlja.Properties;
using DomZdravlja.PropertyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZdravlja
{
    public partial class GlavnaForma : Form
    {

        PropertyZaposleni Logovan;

        public GlavnaForma()
        {
            InitializeComponent();
        }

        public GlavnaForma(PropertyZaposleni logovan)
        {
            InitializeComponent();
            Logovan = logovan;
        }


        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            //provjera koje je radno mjesto pa na osnovu radnog mjesta generise tabPanel
            
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));

            PanelTabControl panelTabControl =  new PanelTabControl((Image)resources.GetObject("recepcija"), "POCETNA");
            PanelTabControl panelTabControl1 = new PanelTabControl((Image)resources.GetObject("recepcija"), "RECEPCIJA");
            PanelTabControl panelTabControl2 = new PanelTabControl((Image)resources.GetObject("recepcija"), "ZAPOSLENI");
            PanelTabControl panelTabControl3 = new PanelTabControl((Image)resources.GetObject("recepcija"), "PACIJENTI");
            PanelTabControl panelTabControl4 = new PanelTabControl((Image)resources.GetObject("recepcija"), "KARTOTEKA");

            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl1);
            panelGlavniTab.Controls.Add(panelTabControl2);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl4);

            CustomTabPage tabPage = new CustomTabPage() { Naziv = "RECEPCIJA", State = State.Main };
            CustomTabPage tabPage1 = new CustomTabPage() { Naziv = "PACIJENT", State = State.Insert };
            CustomTabPage tabPage2= new CustomTabPage() { Naziv = "ZAPOSLENI", State = State.Lookup };

            tabControl.TabPages.Add(tabPage);
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);

            tabControl.TabPages[2].Focus();
            tabControl.SelectedIndex = 2;

            //tabControl.Enabled = false;

        }
    }
}

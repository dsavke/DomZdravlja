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

            /*PanelTabControl panelTabControl =  new PanelTabControl((Image)resources.GetObject("recepcija"), "POCETNA");
            PanelTabControl panelTabControl1 = new PanelTabControl((Image)resources.GetObject("recepcija"), "RECEPCIJA");
            PanelTabControl panelTabControl2 = new PanelTabControl((Image)resources.GetObject("recepcija"), "ZAPOSLENI");
            PanelTabControl panelTabControl3 = new PanelTabControl((Image)resources.GetObject("recepcija"), "PACIJENTI");
            PanelTabControl panelTabControl4 = new PanelTabControl((Image)resources.GetObject("recepcija"), "KARTOTEKA");

            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl1);
            panelGlavniTab.Controls.Add(panelTabControl2);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl4);


            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "RECEPCIJA" };
            CustomTabPage tabPage1 = new CustomTabPage() { State = State.Insert, Naziv = "PACIJENT" };
            CustomTabPage tabPage2= new CustomTabPage() { State = State.Lookup, Naziv = "ZAPOSLENI" };

            tabControl.TabPages.Add(tabPage);
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);

            tabControl.TabPages[2].Focus();
            tabControl.SelectedIndex = 2;*/


            if (Logovan.RadnoMjesto == "Recepcija") ucitajRecepciju();
            else if (Logovan.RadnoMjesto == "Ordinacija") ucitajOrdinaciju();
            else if (Logovan.RadnoMjesto == "Kancelarija") ucitajKancelariju();

            //tabControl.Enabled = false;
            
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl.SelectedTab.Controls.Add(new CustomToolStrip());
        }

        private void ucitajOrdinaciju()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));

            PanelTabControl panelTabControl = new PanelTabControl((Image)resources.GetObject("pocetna"), "POCETNA");
            PanelTabControl panelTabControl3 = new PanelTabControl((Image)resources.GetObject("rezervacija"), "REDOSLIJED DOLAZAKA");
            PanelTabControl panelTabControl4 = new PanelTabControl((Image)resources.GetObject("karton"), "KARTOTEKA");
            PanelTabControl panelTabControl5 = new PanelTabControl((Image)resources.GetObject("pregled"), "PREGLED");
            PanelTabControl panelTabControl6 = new PanelTabControl((Image)resources.GetObject("odjava"), "ODJAVA");

            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl4);
            panelGlavniTab.Controls.Add(panelTabControl5);
            panelGlavniTab.Controls.Add(panelTabControl6);


        }

        private void ucitajRecepciju()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));

            PanelTabControl panelTabControl = new PanelTabControl((Image)resources.GetObject("pocetna"), "POCETNA");
            PanelTabControl panelTabControl1 = new PanelTabControl((Image)resources.GetObject("recepcija"), "RECEPCIJA");
            PanelTabControl panelTabControl3 = new PanelTabControl((Image)resources.GetObject("pacijent"), "PACIJENT");
            PanelTabControl panelTabControl2 = new PanelTabControl((Image)resources.GetObject("racun"), "RACUN");
            


            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl1);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl2);
            
        }

        private void ucitajKancelariju()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));

        }

    }
}

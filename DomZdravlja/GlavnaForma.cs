using DomZdravlja.AttributeClass;
using DomZdravlja.CustomControls;
using DomZdravlja.Properties;
using DomZdravlja.PropertyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomZdravlja.AttributeClass;
using System.Reflection;

namespace DomZdravlja
{
    public partial class GlavnaForma : Form
    {

        private PropertyInterface myProperty;
        private CustomToolStrip CustomToolStrip;
        PropertyZaposleni Logovan = new PropertyZaposleni();

        List<PropertyInterface>[] propertyInterfaces = new List<PropertyInterface>[14];
        
        private void dodajList()
        {
            for(int i = 0; i < 14; i++)
            {
                propertyInterfaces[i] = new List<PropertyInterface>();
            }
        }

        #region Ucitavanje
        private void ucitajZaposlene()
        {

            PropertyZaposleni zaposleni = new PropertyZaposleni();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, zaposleni.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyZaposleni pomZaposleni = new PropertyZaposleni();
                pomZaposleni.ZaposleniID = Convert.ToInt32(dataReader["ZaposleniID"]);
                pomZaposleni.Zvanje = dataReader["Zvanje"].ToString();
                pomZaposleni.RadnoMjesto = dataReader["RadnoMjesto"].ToString();
                pomZaposleni.KorisnickoIme =dataReader["KorisnickoIme"].ToString();
                pomZaposleni.Password = dataReader["Password"].ToString();
                pomZaposleni.TipZaposlenog = dataReader["TipZaposlenog"].ToString();
                pomZaposleni.OsobaID =Convert.ToInt32(dataReader["OsobaID"]);
                propertyInterfaces[0].Add(pomZaposleni);
            }
        }

        private void ucitajPacijente()
        {
            PropertyPacijent pacijenti = new PropertyPacijent();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, pacijenti.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyPacijent pomPacijenti = new PropertyPacijent();
                pomPacijenti.PacijentID =Convert.ToInt32(dataReader["PacijentID"]);
                pomPacijenti.DoktorID = Convert.ToInt32(dataReader["DoktorID"]);
                pomPacijenti.OsobaID = Convert.ToInt32(dataReader["OsobaID"]);
                pomPacijenti.BrojKartona = Convert.ToInt32(dataReader["BrojKartona"]);
                pomPacijenti.Osiguran = Convert.ToInt32(dataReader["Osiguran"]);
                propertyInterfaces[1].Add(pomPacijenti);
            }
        }

        private void ucitajCijenu()
        {
            PropertyCjenovnik cijena = new PropertyCjenovnik();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, cijena.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyCjenovnik pomCijena = new PropertyCjenovnik();
                pomCijena.CjenovnikID = Convert.ToInt32(dataReader["CjenovnikID"]);
                pomCijena.NazivUsluge = dataReader["NazivUsluge"].ToString();
                pomCijena.CijenaUsluge = Convert.ToDecimal(dataReader["CijenaUsluge"]);
                pomCijena.DatumUspostavljanjaCijene =Convert.ToDateTime(dataReader["DatumUspostavljanjaCijene"]);
                propertyInterfaces[2].Add(pomCijena);
            }
        }

        private void ucitajDetaljeRacuna()
        {
            PropertyDetaljiRacuna detaljiRacuna = new PropertyDetaljiRacuna();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, detaljiRacuna.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyDetaljiRacuna pomDetaljiRacuna = new PropertyDetaljiRacuna();
                pomDetaljiRacuna.DetaljiRacunaID = Convert.ToInt32(dataReader["DetaljiRacunaID"]);
                pomDetaljiRacuna.RacunID = Convert.ToInt32(dataReader["RacunID"]);
                pomDetaljiRacuna.CijenaID = Convert.ToInt32(dataReader["CijenaID"]);
                pomDetaljiRacuna.Kolicina = Convert.ToInt32(dataReader["Kolicina"]);
                propertyInterfaces[3].Add(pomDetaljiRacuna);
            }
        }

        private void ucitajDijagnozu()
        {
            PropertyDijagnoza dijagnoza = new PropertyDijagnoza();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, dijagnoza.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyDijagnoza pomDijagnoza = new PropertyDijagnoza();
                pomDijagnoza.DijagnozaID = Convert.ToInt32(dataReader["DijagnozaID"]);
                pomDijagnoza.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                pomDijagnoza.DoktorID = Convert.ToInt32(dataReader["DoktorID"]);
                pomDijagnoza.Terapija =dataReader["Terapija"].ToString();
                pomDijagnoza.Opis = dataReader["Opis"].ToString();
                propertyInterfaces[4].Add(pomDijagnoza);
            }
        }

        private void ucitajFaktorRizika()
        {
            PropertyFaktorRizika faktorRizika = new PropertyFaktorRizika();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, faktorRizika.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyFaktorRizika pomFaktorRizika = new PropertyFaktorRizika();
                pomFaktorRizika.FaktorRizikaID = Convert.ToInt32(dataReader["FaktorRizikaID"]);
                pomFaktorRizika.NazivRizika = dataReader["NazivRizika"].ToString();
                pomFaktorRizika.Opis = dataReader["Opis"].ToString();
                propertyInterfaces[5].Add(pomFaktorRizika);
            }
        }

        private void ucitajFaktorRizikaKarton()
        {
            PropertyFaktorRizikaKarton faktorRizikaKarton = new PropertyFaktorRizikaKarton();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, faktorRizikaKarton.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyFaktorRizikaKarton pomFaktorRizikaKarton = new PropertyFaktorRizikaKarton();
                pomFaktorRizikaKarton.FRKID = Convert.ToInt32(dataReader["FRKID"]);
                pomFaktorRizikaKarton.FaktorRizikaID = Convert.ToInt32(dataReader["FaktorRizikaID"]);
                pomFaktorRizikaKarton.KartonID = Convert.ToInt32(dataReader["KartonID"]);
                propertyInterfaces[6].Add(pomFaktorRizikaKarton);
            }
        }

        private void ucitajKarton()
        {
            PropertyKarton karton = new PropertyKarton();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, karton.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyKarton pomKarton = new PropertyKarton();
                pomKarton.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                pomKarton.KartonID = Convert.ToInt32(dataReader["KartonID"]);

                propertyInterfaces[7].Add(pomKarton);
            }
        }

        private void ucitajKartonDijagnoza()
        {
            PropertyKartonDijagnoza kartonDijagnoza = new PropertyKartonDijagnoza();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, kartonDijagnoza.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyKartonDijagnoza pomKartonDijagnoza = new PropertyKartonDijagnoza();
                pomKartonDijagnoza.KartonDijagnozaID = Convert.ToInt32(dataReader["KartonDijagnozaID"]);
                pomKartonDijagnoza.KartonID = Convert.ToInt32(dataReader["KartonID"]);
                pomKartonDijagnoza.DijagnozaID = Convert.ToInt32(dataReader["DijagnozaID"]);
                propertyInterfaces[8].Add(pomKartonDijagnoza);
            }
        }

        private void ucitajOsobu()
        {
            PropertyOsoba osoba = new PropertyOsoba();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, osoba.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyOsoba pomOsoba = new PropertyOsoba();
                pomOsoba.OsobaID = Convert.ToInt32(dataReader["OsobaID"]);
                pomOsoba.Ime = dataReader["Ime"].ToString();
                pomOsoba.Prezime = dataReader["Prezime"].ToString();
                pomOsoba.JMB = dataReader["JMB"].ToString();
                pomOsoba.Adresa = dataReader["Adresa"].ToString();
                pomOsoba.Kontakt = dataReader["Kontakt"].ToString();
                pomOsoba.Pol = dataReader["Pol"].ToString();
                pomOsoba.MjestoRodjenja = dataReader["MjestoRodjenja"].ToString();
                pomOsoba.DatumRodjenja = Convert.ToDateTime(dataReader["DatumRodjenja"]);
                propertyInterfaces[9].Add(pomOsoba);
            }
        }

        private void ucitajPregled()
        {
            PropertyPregled pregled = new PropertyPregled();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, pregled.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyPregled pomPregled = new PropertyPregled();
                pomPregled.PregledID = Convert.ToInt32(dataReader["PregledID"]);
                pomPregled.DoktorID = Convert.ToInt32(dataReader["DoktorID"]);
                pomPregled.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                pomPregled.DijagnozaID = Convert.ToInt32(dataReader["DijagnozaID"]);
                propertyInterfaces[10].Add(pomPregled);
            }
        }

        private void ucitajRacun()
        {
            PropertyRacun racun = new PropertyRacun();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, racun.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyRacun pomRacun = new PropertyRacun();
                pomRacun.RacunID = Convert.ToInt32(dataReader["RacunID"]);
                pomRacun.VrijemeIzdavanja = Convert.ToDateTime(dataReader["VrijemeIzdavanja"]);
                pomRacun.ZaposleniID = Convert.ToInt32(dataReader["ZaposleniID"]);
                pomRacun.Popust = Convert.ToDecimal(dataReader["Popust"]);
                pomRacun.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                propertyInterfaces[11].Add(pomRacun);
            }
        }

        private void ucitajEvidenciju()
        {
            PropertyRecepcija recepcija = new PropertyRecepcija();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, recepcija.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyRecepcija pomRecepcija = new PropertyRecepcija();
                pomRecepcija.PrijemID = Convert.ToInt32(dataReader["PrijemID"]);
                pomRecepcija.PrijemZaposleniID = Convert.ToInt32(dataReader["PrijemZaposlenihID"]);
                pomRecepcija.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                pomRecepcija.DoktorID = Convert.ToInt32(dataReader["DoktorID"]);
                pomRecepcija.Prioritet = Convert.ToInt32(dataReader["Prioritet"]);
                pomRecepcija.VrijemePrijema = Convert.ToDateTime(dataReader["VrijemePrijema"]);
                pomRecepcija.VrijemeOtpusta = Convert.ToDateTime(dataReader["VrijemeOtpusta"]);
                propertyInterfaces[12].Add(pomRecepcija);
            }
        }

        private void ucitajRezervaciju()
        {
            PropertyRezervacije rezervacija = new PropertyRezervacije();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, rezervacija.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyRezervacije pomRezervacija = new PropertyRezervacije();
                pomRezervacija.RezervacijaID = Convert.ToInt32(dataReader["RezervacijaID"]);
                pomRezervacija.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                pomRezervacija.VrijemeRezervacije = Convert.ToDateTime(dataReader["VrijemeRezervacije"]);
                pomRezervacija.Termin = Convert.ToDateTime(dataReader["Termin"]);
                pomRezervacija.DoktorID = Convert.ToInt32(dataReader["DoktorID"]);
                propertyInterfaces[13].Add(pomRezervacija);
            }
        }
        #endregion

        public GlavnaForma()
        {
            InitializeComponent();
        }

        public GlavnaForma(PropertyZaposleni logovan)
        {
            InitializeComponent();
            Logovan = logovan;
            dodajList();
            myProperty = null;
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
            
            //Logovan.RadnoMjesto = "Kancelarija";


            if (Logovan.RadnoMjesto == "Recepcija") ucitajRecepciju();
            else if (Logovan.RadnoMjesto == "Ordinacija") ucitajOrdinaciju();
            else if (Logovan.RadnoMjesto == "Kancelarija") ucitajKancelariju();

            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POCETNA" };
            tabControl.Controls.Add(tabPage);
            tabControl.TabPages[tabControl.TabPages.Count - 1].Focus();

            //tabControl.Enabled = false;

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dodajPoljaZaPretragu()
        {
            if (tabControl.SelectedIndex != -1 && myProperty != null)
            {
                
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Location = new Point(0, 34);
                flowLayoutPanel.Width = 908;
                flowLayoutPanel.Height = 766;
                tabControl.SelectedTab.Controls.Add(flowLayoutPanel);


                kreirajPoljaZaPretragu(myProperty, flowLayoutPanel);

            }
        }

        private void kreirajTabove()
        {
            if (tabControl.SelectedIndex != -1 && myProperty != null)
            {
                TabControl tab = new TabControl();
                tab.Location = new Point(0, 200);
                tab.Width = 908;
                tab.Height = 250;
                tabControl.SelectedTab.Controls.Add(tab);

                CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POCETNA" };
                tabControl.Controls.Add(tabPage);
                tab.Controls.Add(tabPage);

               
            }
        }


        private void kreirajPoljaZaPretragu(PropertyInterface myProperty, FlowLayoutPanel flowLayoutPanel)
        {

            var type = myProperty.GetType();
            var properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
               
                    if (property.IsDefined(typeof(MainSearch)))
                    {

                        ComponentType componentType;
                        componentType = property.GetCustomAttribute<GenerateComponent>().ComponentType;


                        if (componentType == ComponentType.Tekst)
                        {
                            UCTekst uCTekst = new UCTekst();
                            uCTekst.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                            flowLayoutPanel.Controls.Add(uCTekst);
                        }
                        else if (componentType == ComponentType.Datum)
                        {
                            UCDatum uCDatum = new UCDatum();
                            uCDatum.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                            flowLayoutPanel.Controls.Add(uCDatum);
                        }
                        else if (componentType == ComponentType.RadioButton)
                        {
                            UCRadioButton uCRadioButton = new UCRadioButton();
                            uCRadioButton.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                            flowLayoutPanel.Controls.Add(uCRadioButton);
                        }
                        else if (componentType == ComponentType.Lookup)
                        {
                            UCLookup uCLookup = new UCLookup();
                            //uCLookup.Naziv = property.GetCustomAttribute<ForeignKey>().ReferencedTable;
                            //flowLayoutPanel.Controls.Add(uCLookup);

                            var pomProperty = Activator.CreateInstance(Type.GetType(property.GetCustomAttribute<ForeignKey>().ReferencedTable));
                            
                            kreirajPoljaZaPretragu((PropertyInterface)pomProperty, flowLayoutPanel);

                        }
                    }
            }
        }


        private void kreirajToolStrip()
        {
            if (tabControl.SelectedIndex != -1 && myProperty != null)
            {
                CustomToolStrip = new CustomToolStrip(myProperty);
                CustomToolStrip.DodajClick += CustomToolStrip_DodajClick;
                tabControl.SelectedTab.Controls.Add(CustomToolStrip);
            }
        }
       

        private void CustomToolStrip_DodajClick(object sender, EventArgs e)
        {
            CustomTabPage tabPage = new CustomTabPage() { State = State.Insert, Naziv = "DODAVANJE" };
            tabControl.TabPages.Add(tabPage);
            postaviFokus();

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Width = 908;
            flowLayoutPanel.Height = 800;
            tabControl.SelectedTab.Controls.Add(flowLayoutPanel);

            var type = myProperty.GetType();
            var properties = type.GetProperties();

            foreach(PropertyInfo property in properties)
            {

                ComponentType componentType;
                componentType = property.GetCustomAttribute<GenerateComponent>().ComponentType;

 
                    if(componentType == ComponentType.Tekst)
                    {
                        UCTekst uCTekst = new UCTekst();
                        uCTekst.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                        flowLayoutPanel.Controls.Add(uCTekst);
                    }
                    else if (componentType == ComponentType.Datum)
                    {
                        UCDatum uCDatum = new UCDatum();
                        uCDatum.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                        flowLayoutPanel.Controls.Add(uCDatum);
                    }
                    else if (componentType == ComponentType.RadioButton)
                    {
                        UCRadioButton uCRadioButton = new UCRadioButton();
                        uCRadioButton.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                        flowLayoutPanel.Controls.Add(uCRadioButton);
                    }
                    else if(componentType == ComponentType.Lookup)
                    {
                        UCLookup uCLookup = new UCLookup();
                        uCLookup.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                        flowLayoutPanel.Controls.Add(uCLookup);
                    }
               
            }

        }

        private void ucitajOrdinaciju()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));

            PanelTabControl panelTabControl = new PanelTabControl((Image)resources.GetObject("pocetna"), "POCETNA");
            panelTabControl.ControlClick += Pocetna_ControlClick;
            PanelTabControl panelTabControl3 = new PanelTabControl((Image)resources.GetObject("rezervacija"), "REDOSLIJED DOLAZAKA");
            panelTabControl3.ControlClick += RedoslijedDolazaka_ControlClick;
            PanelTabControl panelTabControl4 = new PanelTabControl((Image)resources.GetObject("karton"), "KARTON");
            panelTabControl4.ControlClick += Karton_ControlClick;
            PanelTabControl panelTabControl5 = new PanelTabControl((Image)resources.GetObject("pregled"), "PREGLED");
            panelTabControl5.ControlClick += Pregled_ControlClick;
            PanelTabControl panelTabControl6 = new PanelTabControl((Image)resources.GetObject("odjava"), "ODJAVA");
            panelTabControl6.ControlClick += Odjava_ControlClick;


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
            panelTabControl.ControlClick += Pocetna_ControlClick;
            PanelTabControl panelTabControl1 = new PanelTabControl((Image)resources.GetObject("rezervacija"), "RECEPCIJA");
            panelTabControl1.ControlClick += Recepcija_ControlClick;
            PanelTabControl panelTabControl3 = new PanelTabControl((Image)resources.GetObject("pacijent"), "PACIJENT");
            panelTabControl3.ControlClick += Pacijent_ControlClick;
            PanelTabControl panelTabControl2 = new PanelTabControl((Image)resources.GetObject("racun"), "RACUN");
            panelTabControl2.ControlClick += Racun_ControlClick;
            PanelTabControl panelTabControl6 = new PanelTabControl((Image)resources.GetObject("odjava"), "ODJAVA");
            panelTabControl6.ControlClick += Odjava_ControlClick;

            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl1);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl2);
            panelGlavniTab.Controls.Add(panelTabControl6);

        }

      
        private void ucitajKancelariju()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));

            PanelTabControl panelTabControl = new PanelTabControl((Image)resources.GetObject("pocetna"), "POCETNA");
            panelTabControl.ControlClick += Pocetna_ControlClick; 
            PanelTabControl panelTabControl1 = new PanelTabControl((Image)resources.GetObject("zaposleni"), "ZAPOSLENI");
            panelTabControl1.ControlClick += Zaposleni_ControlClick;
            PanelTabControl panelTabControl3 = new PanelTabControl((Image)resources.GetObject("pacijent"), "PACIJENT");
            panelTabControl3.ControlClick += Pacijent_ControlClick;
            PanelTabControl panelTabControl4 = new PanelTabControl((Image)resources.GetObject("cjenovnik"), "CJENOVNIK");
            panelTabControl4.ControlClick += Cjenovnik_ControlClick;
            PanelTabControl panelTabControl2 = new PanelTabControl((Image)resources.GetObject("racun"), "RACUN");
            panelTabControl2.ControlClick += Racun_ControlClick;
            PanelTabControl panelTabControl6 = new PanelTabControl((Image)resources.GetObject("odjava"), "ODJAVA");
            panelTabControl6.ControlClick += Odjava_ControlClick;

            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl1);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl4);
            panelGlavniTab.Controls.Add(panelTabControl2);
            panelGlavniTab.Controls.Add(panelTabControl6);


        }


        private void Pocetna_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POCETNA" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = null;
            kreirajToolStrip();
        }

        private void postaviFokus()
        {
            tabControl.TabPages[tabControl.TabPages.Count - 1].Focus();
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
        }

        private void Cjenovnik_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "CJENOVNIK" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = new PropertyCjenovnik();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Zaposleni_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "ZAPOSLENI" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = new PropertyZaposleni();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void RedoslijedDolazaka_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "REDOSLIJED DOLAZAKA" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = null;
            kreirajToolStrip();
            dodajPoljaZaPretragu();
        }

        private void Karton_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "KARTON" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = new PropertyKarton();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
        }

        private void Pregled_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "PREGLED" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = new PropertyPregled();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
        }

        private void Odjava_ControlClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li zelite izaci iz programa?", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void Recepcija_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "RECEPCIJA" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = new PropertyRecepcija();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
        }

        private void Pacijent_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "PACIJENT" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = new PropertyPacijent();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
        }

        private void Racun_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "RACUN" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = new PropertyRacun();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
        }

        private void zatvoriSve()
        {
            /*for(int i = 0; i < tabControl.TabPages.Count; i++)
            {
                tabControl.TabPages.RemoveAt(i);
                i--;
            }*/
        }

    }
}

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
        private State trenutnoStanje;

        List<PropertyInterface>[] propertyInterfaces = new List<PropertyInterface>[14];
  
        private void dodajList()
        {
       
            for (int i = 0; i < 14; i++)
            {
                propertyInterfaces[i] = new List<PropertyInterface>();
            }


        }

        #region Ucitavanje
        private void ucitajZaposlene()
        {

            propertyInterfaces[0] = new List<PropertyInterface>();

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
            propertyInterfaces[1] = new List<PropertyInterface>();

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
            propertyInterfaces[2] = new List<PropertyInterface>();
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
            propertyInterfaces[3] = new List<PropertyInterface>();
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
            propertyInterfaces[4] = new List<PropertyInterface>();
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
            propertyInterfaces[5] = new List<PropertyInterface>();
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
            propertyInterfaces[6] = new List<PropertyInterface>();
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
            propertyInterfaces[7] = new List<PropertyInterface>();
            PropertyKarton karton = new PropertyKarton();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, karton.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyKarton pomKarton = new PropertyKarton();
                pomKarton.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                pomKarton.KartonID = Convert.ToInt32(dataReader["BrojKartona"]);

                propertyInterfaces[7].Add(pomKarton);
            }
        }

        private void ucitajKartonDijagnoza()
        {
            propertyInterfaces[8] = new List<PropertyInterface>();
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
            propertyInterfaces[9] = new List<PropertyInterface>();
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
            propertyInterfaces[10] = new List<PropertyInterface>();
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
            propertyInterfaces[11] = new List<PropertyInterface>();
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
                pomRacun.SumaRacuna = Convert.ToInt32(dataReader["SumaRacuna"]);
                propertyInterfaces[11].Add(pomRacun);
            }
        }

        private void ucitajEvidenciju()
        {
            propertyInterfaces[12] = new List<PropertyInterface>();
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
            propertyInterfaces[13] = new List<PropertyInterface>();
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

        private void ucitaj(int index)
        {
            switch (index)
            {
                case 0:
                    ucitajZaposlene();
                    break;
                case 1:
                    ucitajPacijente();
                    break;
                case 2:
                    ucitajCijenu();
                    break;
                case 3:
                    ucitajDetaljeRacuna();
                    break;
                case 4:
                    ucitajDijagnozu();
                    break;
                case 5:
                    ucitajFaktorRizika();
                    break;
                case 6:
                    ucitajFaktorRizikaKarton();
                    break;
                case 7:
                    ucitajKarton();
                    break;
                case 8:
                    ucitajKartonDijagnoza();
                    break;
                case 9:
                    ucitajOsobu();
                    break;
                case 10:
                    ucitajPregled();
                    break;
                case 11:
                    ucitajRacun();
                    break;
                case 12:
                    ucitajEvidenciju();
                    break;
                case 13:
                    ucitajRezervaciju();
                    break;
            }
        }

        private int vratiIndex(object objekat)
        {
            int index = -1;
            if (objekat.GetType() == typeof(PropertyZaposleni)) index = 0;
            else if (objekat.GetType() == typeof(PropertyPacijent)) index = 1;
            else if (objekat.GetType() == typeof(PropertyCjenovnik)) index = 2;
            else if (objekat.GetType() == typeof(PropertyDetaljiRacuna)) index = 3;
            else if (objekat.GetType() == typeof(PropertyDijagnoza)) index = 4;
            else if (objekat.GetType() == typeof(PropertyFaktorRizika)) index = 5;
            else if (objekat.GetType() == typeof(PropertyFaktorRizikaKarton)) index = 6;
            else if (objekat.GetType() == typeof(PropertyKarton)) index = 7;
            else if (objekat.GetType() == typeof(PropertyKartonDijagnoza)) index = 8;
            else if (objekat.GetType() == typeof(PropertyOsoba)) index = 9;
            else if (objekat.GetType() == typeof(PropertyPregled)) index = 10;
            else if (objekat.GetType() == typeof(PropertyRacun)) index = 11;
            else if (objekat.GetType() == typeof(PropertyRecepcija)) index = 12;
            else if (objekat.GetType() == typeof(PropertyRezervacije)) index = 13;
            return index;
        }

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
            ucitajPacijente();
            trenutnoStanje = State.Main;
        }


        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            if (Logovan.RadnoMjesto == "Recepcija") ucitajRecepciju();
            else if (Logovan.RadnoMjesto == "Ordinacija") ucitajOrdinaciju();
            else if (Logovan.RadnoMjesto == "Kancelarija") ucitajKancelariju();

            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POCETNA" };
            tabControl.Controls.Add(tabPage);
            tabControl.TabPages[tabControl.TabPages.Count - 1].Focus();

            postaviPocetnu();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as CustomTabControl).TabPages.Count > 0)
            {
                if ((tabControl.SelectedTab as CustomTabPage).State != State.Lookup)
                {
                    rijesiLookup();
                    if (trenutnoStanje == State.Lookup) postaviFokus(State.Insert);
                }
                trenutnoStanje = (tabControl.SelectedTab as CustomTabPage).State;
            }
        }

        #region PoljaZaPretragu
        private void dodajPoljaZaPretragu()
        {
            if (tabControl.SelectedIndex != -1 && myProperty != null)
            {
                
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Location = new Point(0, 34);
                flowLayoutPanel.Width = 908;
                flowLayoutPanel.Height = 200;
                tabControl.SelectedTab.Controls.Add(flowLayoutPanel);

                kreirajPoljaZaPretragu(myProperty, flowLayoutPanel);
            }
        }

        private void kreirajTabove()
        {
            if (tabControl.SelectedIndex != -1 && myProperty != null)
            {
                CustomTabControl noviTabControl = new CustomTabControl() { HeaderColor = Color.FromArgb(255, 255, 255)};
                noviTabControl.Location = new Point(5, 300);
                noviTabControl.Width = 890;
                noviTabControl.Height = 400;
                CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = tabControl.SelectedTab.Text };

                noviTabControl.TabPages.Add(tabPage);
                tabControl.SelectedTab.Controls.Add(noviTabControl);

                DataGridView data = new DataGridView();
                ucitaj(vratiIndex(myProperty));
                data = vratiTablu(myProperty, propertyInterfaces[vratiIndex(myProperty)]);
                tabPage.Controls.Add(data);
                data.Dock = DockStyle.Fill;
                data.BorderStyle = BorderStyle.None;
                data.BackgroundColor = Color.FromArgb(255, 255, 255);
                data.Focus();

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

        #endregion

        #region CustomToolStrip
        private void kreirajToolStrip()
        {
            if (tabControl.SelectedIndex != -1 && myProperty != null)
            {
                CustomToolStrip = new CustomToolStrip(myProperty);
                CustomToolStrip.DodajClick += CustomToolStrip_DodajClick;
                CustomToolStrip.AzurirajClick += CustomToolStrip_AzurirajClick;
                CustomToolStrip.PretragaClick += CustomToolStrip_PretragaClick;
                CustomToolStrip.ObrisiClick += CustomToolStrip_ObrisiClick;
                CustomToolStrip.GoreClick += CustomToolStrip_GoreClick;
                CustomToolStrip.DoleClick += CustomToolStrip_DoleClick;
                CustomToolStrip.PrviClick += CustomToolStrip_PrviClick;
                CustomToolStrip.ZadnjiClick += CustomToolStrip_ZadnjiClick;
                tabControl.SelectedTab.Controls.Add(CustomToolStrip);
            }
        }

        private void CustomToolStrip_ZadnjiClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CustomToolStrip_PrviClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CustomToolStrip_DoleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CustomToolStrip_GoreClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CustomToolStrip_ObrisiClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CustomToolStrip_PretragaClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CustomToolStrip_AzurirajClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region EventDodaj
        private void CustomToolStrip_DodajClick(object sender, EventArgs e)
        {
            CustomTabPage tabPage = new CustomTabPage() { State = State.Insert, Naziv = "DODAVANJE" };
            trenutnoStanje = State.Insert;
            tabControl.TabPages.Add(tabPage);
            postaviFokus(State.Insert);

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Width = 908;
            flowLayoutPanel.Height = 600;
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
                        uCRadioButton.NazivOpcije1 = property.GetCustomAttribute<OpcijeRadioButton>().Param1;
                        uCRadioButton.NazivOpcije2 = property.GetCustomAttribute<OpcijeRadioButton>().Param2;
                        flowLayoutPanel.Controls.Add(uCRadioButton);
                    }
                    else if(componentType == ComponentType.Lookup)
                    {
                        UCLookup uCLookup = new UCLookup();
                        uCLookup.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                        uCLookup.LookupClick += UCLookup_LookupClick;
                        flowLayoutPanel.Controls.Add(uCLookup);
                    }  
            }

            Panel panel = new Panel();
            panel.Location = new Point(0, 600);
            panel.Width = 908;
            panel.Height = 160;

            Button btnSacuvaj = new Button();
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.Location = new Point(710, 100);
            btnSacuvaj.Click += BtnSacuvaj_Click;

            Button btnOdustani = new Button();
            btnOdustani.Text = "Odustani";
            btnOdustani.Location = new Point(795, 100);
            btnOdustani.Click += BtnOdustani_Click;

            panel.Controls.Add(btnSacuvaj);
            panel.Controls.Add(btnOdustani);

            tabControl.SelectedTab.Controls.Add(panel);

        }

        #endregion

        private void BtnOdustani_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabControl.SelectedTab);
            tabControl.SelectedIndex = 0;
        }

        #region SacuvajDodavanje
        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {

            var type = myProperty.GetType();
            var properties = type.GetProperties();
            bool proslo = true;

            foreach(Control control in tabControl.SelectedTab.Controls[0].Controls)
            {
                try
                {
                    PropertyInfo property = null;

                    if (control.GetType() == typeof(UCTekst))
                    {
                        property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCTekst).Naziv).FirstOrDefault();
                        string rez = (control as UCTekst).Value;

                        if (property.IsDefined(typeof(ValidatePattern)))
                        {
                            if (property.GetCustomAttribute<ValidatePattern>().IsValid(rez))
                            {
                                if (property.PropertyType == typeof(int))
                                {
                                    property.SetValue(myProperty, Convert.ToInt32(rez));
                                    MessageBox.Show("" + property.GetValue(myProperty));
                                }
                                else if (property.PropertyType == typeof(Decimal))
                                {
                                    property.SetValue(myProperty, Convert.ToDecimal(rez));
                                    MessageBox.Show("" + property.GetValue(myProperty));
                                }
                                else if (property.PropertyType == typeof(String))
                                {
                                    property.SetValue(myProperty, rez);
                                    MessageBox.Show("" + property.GetValue(myProperty));
                                }
                            }
                            else
                            {
                                (control as UCTekst).BackColor = Color.DarkGray;
                                proslo = false;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(rez))
                            {
                                property.SetValue(myProperty, null);
                                MessageBox.Show("Vrijednost je null");
                            }
                            else if (property.PropertyType == typeof(int))
                            {
                                property.SetValue(myProperty, Convert.ToInt32(rez));
                                MessageBox.Show("" + property.GetValue(myProperty));
                            }
                            else if (property.PropertyType == typeof(Decimal))
                            {
                                property.SetValue(myProperty, Convert.ToDecimal(rez));
                                MessageBox.Show("" + property.GetValue(myProperty));
                            }
                            else if (property.PropertyType == typeof(String))
                            {
                                property.SetValue(myProperty, rez);
                                MessageBox.Show("" + property.GetValue(myProperty));
                            }
                        }
                    }
                    else if (control.GetType() == typeof(UCDatum))
                    {
                        property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCDatum).Naziv).FirstOrDefault();
                        DateTime rez = (control as UCDatum).Value;
                        property.SetValue(myProperty, rez);
                        MessageBox.Show("" + property.GetValue(myProperty));

                    }
                    else if (control.GetType() == typeof(UCRadioButton))
                    {
                        property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCRadioButton).Naziv).FirstOrDefault();
                    }
                    else if (control.GetType() == typeof(UCLookup))
                    {
                        property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCLookup).Naziv).FirstOrDefault();
                        if (property.IsDefined(typeof(ValidatePattern)))
                        {

                            string rez = (control as UCLookup).Value;
                            if (property.GetCustomAttribute<ValidatePattern>().IsValid(rez))
                            {
                                //(control as UCLookup).BackColor = Color.Blue;
                                property.SetValue(myProperty, Convert.ToInt32(rez));
                                MessageBox.Show("" + property.GetValue(myProperty));
                            }
                            else
                            {
                                (control as UCLookup).BackColor = Color.DarkGray;
                                proslo = false;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Puklo " + ex.ToString());
                }

            }
            if (proslo)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, myProperty.GetInsertQuery(), myProperty.GetInsertParameters().ToArray());
                    MessageBox.Show("Uspjesno ste dodali!");
                    tabControl.TabPages.Remove(tabControl.SelectedTab);
                    postaviFokus(State.Main);
                }catch(Exception ex)
                {
                    MessageBox.Show("" + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Dodavanje nije proslo");
            }
        }
        #endregion

        #region Lookup
        private void UCLookup_LookupClick(object sender, EventArgs e)
        {
            CustomTabPage tabPage = new CustomTabPage() { State = State.Lookup, Naziv = "LOOKUP" };
            trenutnoStanje = State.Lookup;
            tabControl.TabPages.Add(tabPage);
            postaviFokus(State.Lookup);

            var properties = myProperty.GetType().GetProperties();

            PropertyInfo property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == ((sender as Button).Parent as UCLookup).Naziv).FirstOrDefault();

            var objekat = Activator.CreateInstance(Type.GetType(property.GetCustomAttribute<ForeignKey>().ReferencedTable));

            DataGridView data = new DataGridView();
       
            ucitaj(vratiIndex(objekat));

            data = vratiTablu(objekat, propertyInterfaces[vratiIndex(objekat)]);
            data.Location = new Point(20, 20);

            tabControl.SelectedTab.Controls.Add(data);

            Panel panel = new Panel();
            panel.Location = new Point(20, 620);
            panel.Width = 908;
            panel.Height = 160;

            Button btnVrati = new Button();
            btnVrati.Text = "Vrati";
            btnVrati.Location = new Point(710, 100);

            UCLookup uCLookup = (sender as Button).Parent as UCLookup;
         
            btnVrati.Click += (send, EventArgs) => { BtnVrati_Click(send, EventArgs, property, uCLookup, data, objekat, tabPage); };

            Button btnOdustani = new Button();
            btnOdustani.Text = "Odustani";
            btnOdustani.Location = new Point(795, 100);
            btnOdustani.Click += BtnOdustaniLookup_Click; ;

            panel.Controls.Add(btnVrati);
            panel.Controls.Add(btnOdustani);

            tabControl.SelectedTab.Controls.Add(panel);

            lookupTab();

            data.Focus();

        }

        private void BtnOdustaniLookup_Click(object sender, EventArgs e)
        {
            rijesiLookup();
        }

        private void BtnVrati_Click(object sender, EventArgs e, PropertyInfo property, UCLookup uC, DataGridView data, object objekat, CustomTabPage tabPage)
        {
            if (data.SelectedRows.Count > 0)
            {
                rijesiLookup();

                DataGridViewRow row = data.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells[property.GetCustomAttribute<ForeignKey>().ReferencedColumn].Value);

                uC.Value = id.ToString();

                tabControl.TabPages.Remove(tabControl.SelectedTab);

                //uC.Info = objekat.ToString();
            }
            else
            {
                MessageBox.Show("Greska. Niste nista selektovali!");
            }

        }

        public DataGridView vratiTablu(object objekat, List<PropertyInterface> list)
        {
            DataGridView dgv = izgled();
            
            if (objekat.GetType() == typeof(PropertyZaposleni)) dgv.DataSource = list.Cast<PropertyZaposleni>().ToList();
            else if (objekat.GetType() == typeof(PropertyPacijent)) dgv.DataSource = list.Cast<PropertyPacijent>().ToList();
            else if (objekat.GetType() == typeof(PropertyCjenovnik)) dgv.DataSource = list.Cast<PropertyCjenovnik>().ToList();
            else if (objekat.GetType() == typeof(PropertyDetaljiRacuna)) dgv.DataSource = list.Cast<PropertyDetaljiRacuna>().ToList();
            else if (objekat.GetType() == typeof(PropertyDijagnoza)) dgv.DataSource = list.Cast<PropertyDijagnoza>().ToList();
            else if (objekat.GetType() == typeof(PropertyFaktorRizika)) dgv.DataSource = list.Cast<PropertyFaktorRizika>().ToList();
            else if (objekat.GetType() == typeof(PropertyFaktorRizikaKarton)) dgv.DataSource = list.Cast<PropertyFaktorRizikaKarton>().ToList();
            else if (objekat.GetType() == typeof(PropertyKarton)) dgv.DataSource = list.Cast<PropertyKarton>().ToList();
            else if (objekat.GetType() == typeof(PropertyKartonDijagnoza)) dgv.DataSource = list.Cast<PropertyKartonDijagnoza>().ToList();
            else if (objekat.GetType() == typeof(PropertyOsoba)) dgv.DataSource = list.Cast<PropertyOsoba>().ToList();
            else if (objekat.GetType() == typeof(PropertyPregled)) dgv.DataSource = list.Cast<PropertyPregled>().ToList();
            else if (objekat.GetType() == typeof(PropertyRacun)) dgv.DataSource = list.Cast<PropertyRacun>().ToList();
            else if (objekat.GetType() == typeof(PropertyRecepcija)) dgv.DataSource = list.Cast<PropertyRecepcija>().ToList();
            else if (objekat.GetType() == typeof(PropertyRezervacije)) dgv.DataSource = list.Cast<PropertyRezervacije>().ToList();

            return dgv;
        }

        private DataGridView izgled()
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.Width = 880;
            dataGridView.Height = 400;
            dataGridView.Font = new Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(227, 234, 244);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 128, 196);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            return dataGridView;
        }

        #endregion

        #region UcitavanjeTabControl
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

        private void postaviPocetnu()
        {
            ucitajOsobu();
            PocetnaStrana pocetna = new PocetnaStrana();
            tabControl.SelectedTab.Controls.Add(pocetna);
            foreach (PropertyOsoba item in propertyInterfaces[9])
            {
                if (item.OsobaID == Logovan.OsobaID)
                {

                    pocetna.Ime = item.Ime;
                    pocetna.Prezime = item.Prezime;
                }
            }
            pocetna.TipZaposlenog = Logovan.TipZaposlenog;


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
        #endregion

        private void postaviFokus(State stanje)
        {
            /*tabControl.TabPages[tabControl.TabPages.Count - 1].Focus();
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;*/

            for(int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if((tabControl.TabPages[i] as CustomTabPage).State == stanje)
                {
                    tabControl.TabPages[i].Focus();
                    tabControl.SelectedIndex = i;
                }
            }

        }

        #region ControlClickMetode
        private void Pocetna_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POCETNA" };
            tabControl.Controls.Add(tabPage);
            postaviFokus(State.Main);
            myProperty = null;
            postaviPocetnu();
        
        }

        private void Cjenovnik_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "CJENOVNIK" };
            tabControl.Controls.Add(tabPage);
            postaviFokus(State.Main);
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
            postaviFokus(State.Main);
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
            postaviFokus(State.Main);
            myProperty = null;
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Karton_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "KARTON" };
            tabControl.Controls.Add(tabPage);
            postaviFokus(State.Main);
            myProperty = new PropertyKarton();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Pregled_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "PREGLED" };
            tabControl.Controls.Add(tabPage);
            postaviFokus(State.Main);
            myProperty = new PropertyPregled();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
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
            postaviFokus(State.Main);
            myProperty = new PropertyRecepcija();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
        }

        private void Pacijent_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "PACIJENT" };
            tabControl.Controls.Add(tabPage);
            postaviFokus(State.Main);
            myProperty = new PropertyPacijent();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Racun_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "RACUN" };
            tabControl.Controls.Add(tabPage);
            postaviFokus(State.Main);
            myProperty = new PropertyRacun();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }
        #endregion

        private void zatvoriSve()
        {
            
            for(int i = 0; i < tabControl.TabPages.Count; i++)
            {
                tabControl.TabPages.RemoveAt(i);
                i--;
            }
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
           
            if (!provjeriLookup()) rijesiLookup();
            if ((sender as CustomTabControl).TabPages.Count > 0)
            {
                {
                    if (!e.TabPage.Enabled)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void lookupTab()
        {
            foreach (CustomTabPage tabPage in tabControl.TabPages)
            {
                tabPage.Enabled = false;
            }
            tabControl.SelectedTab.Enabled = true;
        }

        private void rijesiLookup()
        {
            foreach (CustomTabPage tabPage in tabControl.TabPages)
            {
                tabPage.Enabled = true;
            }
        }

        private bool provjeriLookup()
        {
            foreach(CustomTabPage tabPage in tabControl.TabPages)
            {
                if (tabPage.State == State.Lookup) return true;
            }
            return false;
        }

    }
}

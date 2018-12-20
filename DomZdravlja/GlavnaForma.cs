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
            
            //propertyInterfacesi.Add(new List<PropertyZaposleni>());
            for (int i = 0; i < 14; i++)
            {
                propertyInterfaces[i] = new List<PropertyInterface>();
            }

            //propertyInterfaces[0] = new List<PropertyZaposleni>();

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
            //ucitaj(1);//for (int i = 0; i < 14; i++) ucitaj(i);
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

            if (Logovan.RadnoMjesto == "Recepcija") ucitajRecepciju();
            else if (Logovan.RadnoMjesto == "Ordinacija") ucitajOrdinaciju();
            else if (Logovan.RadnoMjesto == "Kancelarija") ucitajKancelariju();

            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POCETNA" };
            tabControl.Controls.Add(tabPage);
            tabControl.TabPages[tabControl.TabPages.Count - 1].Focus();

            //tabControl.Enabled = false;
            postaviPocetnu();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        #region PoljaZaPretragu
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


        private void kreirajToolStrip()
        {
            if (tabControl.SelectedIndex != -1 && myProperty != null)
            {
                CustomToolStrip = new CustomToolStrip(myProperty);
                CustomToolStrip.DodajClick += CustomToolStrip_DodajClick;
                tabControl.SelectedTab.Controls.Add(CustomToolStrip);
            }
        }

        #region EventDodaj
        private void CustomToolStrip_DodajClick(object sender, EventArgs e)
        {
            CustomTabPage tabPage = new CustomTabPage() { State = State.Insert, Naziv = "DODAVANJE" };
            tabControl.TabPages.Add(tabPage);
            postaviFokus();

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
            //panel.BackColor = Color.Red;
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

                PropertyInfo property = null;
                ValidatePattern pattern = new ValidatePattern();

                if(control.GetType() == typeof(UCTekst))
                {
                    property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCTekst).Naziv).FirstOrDefault();
                    if (property.IsDefined(typeof(ValidatePattern)))
                    {
                        string rez = (control as UCTekst).Value;
                        if (property.GetCustomAttribute<ValidatePattern>().IsValid(rez))
                        {
                            (control as UCTekst).BackColor = Color.Blue;
                            if (property.PropertyType == typeof(int)) {
                                property.SetValue(myProperty, Convert.ToInt32(rez));
                            }
                            else if(property.PropertyType == typeof(Decimal))
                            {
                                property.SetValue(myProperty, Convert.ToDecimal(rez));
                            }
                            else if(property.PropertyType == typeof(String))
                            {
                                property.SetValue(myProperty, rez);
                            }
                            else
                            {
                                MessageBox.Show("" + property.PropertyType);
                            }
                        }
                        else
                        {
                            (control as UCTekst).BackColor = Color.DarkGray;
                            proslo = false;
                        }
                    }
                }
                else if(control.GetType() == typeof(UCDatum))
                {
                    property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCDatum).Naziv).FirstOrDefault();
                    if (property.IsDefined(typeof(ValidatePattern)))
                    {
                        DateTime rez = (control as UCDatum).Value;
                        if (property.GetCustomAttribute<ValidatePattern>().IsValid(rez))
                        {
                            (control as UCDatum).BackColor = Color.Blue;
                            property.SetValue(myProperty, rez);
                        }
                        else
                        {
                            (control as UCDatum).BackColor = Color.DarkGray;
                            proslo = false;
                        }
                    }
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
                            (control as UCLookup).BackColor = Color.Blue;
                            property.SetValue(myProperty, Convert.ToInt32(rez));
                        }
                        else
                        {
                            (control as UCLookup).BackColor = Color.DarkGray;
                            proslo = false;
                        }
                    }
                }

            }
            if (proslo)
            {
                //ispunjeni svi uslovi moze dodati
                MessageBox.Show("Proslo");
            }
            else
            {
                //nisu ispunjeni uslovi
                MessageBox.Show("Nije proslo");
            }
        }
        #endregion

        #region Lookup
        private void UCLookup_LookupClick(object sender, EventArgs e)
        {
            CustomTabPage tabPage = new CustomTabPage() { State = State.Lookup, Naziv = "LOOKUP" };
            tabControl.TabPages.Add(tabPage);
            postaviFokus();

            var properties = myProperty.GetType().GetProperties();

            PropertyInfo property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == ((sender as Button).Parent as UCLookup).Naziv).FirstOrDefault();

            var objekat = Activator.CreateInstance(Type.GetType(property.GetCustomAttribute<ForeignKey>().ReferencedTable));

            DataGridView data = new DataGridView();
            data.Width = 908;
            data.Height = 700;
            ucitaj(vratiIndex(objekat));
            
            data = vratiTablu(objekat);
            
            tabControl.SelectedTab.Controls.Add(data);



        }

        public DataGridView vratiTablu(object objekat)
        {
            DataGridView dgv = new DataGridView();
            dgv.Width = 908;
            dgv.Height = 700;
            if (objekat.GetType() == typeof(PropertyZaposleni)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyZaposleni>().ToList();
            else if (objekat.GetType() == typeof(PropertyPacijent)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyPacijent>().ToList();
            else if (objekat.GetType() == typeof(PropertyCjenovnik)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyCjenovnik>().ToList();
            else if (objekat.GetType() == typeof(PropertyDetaljiRacuna)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyDetaljiRacuna>().ToList();
            else if (objekat.GetType() == typeof(PropertyDijagnoza)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyDijagnoza>().ToList();
            else if (objekat.GetType() == typeof(PropertyFaktorRizika)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyFaktorRizika>().ToList();
            else if (objekat.GetType() == typeof(PropertyFaktorRizikaKarton)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyFaktorRizikaKarton>().ToList();
            else if (objekat.GetType() == typeof(PropertyKarton)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyKarton>().ToList();
            else if (objekat.GetType() == typeof(PropertyKartonDijagnoza)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyKartonDijagnoza>().ToList();
            else if (objekat.GetType() == typeof(PropertyOsoba)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyOsoba>().ToList();
            else if (objekat.GetType() == typeof(PropertyPregled)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyPregled>().ToList();
            else if (objekat.GetType() == typeof(PropertyRacun)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyRacun>().ToList();
            else if (objekat.GetType() == typeof(PropertyRecepcija)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyRecepcija>().ToList();
            else if (objekat.GetType() == typeof(PropertyRezervacije)) dgv.DataSource = propertyInterfaces[vratiIndex(objekat)].Cast<PropertyRezervacije>().ToList();
            return dgv;
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

        private void postaviFokus()
        {
            tabControl.TabPages[tabControl.TabPages.Count - 1].Focus();
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
        }

        #region ControlClickMetode
        private void Pocetna_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POCETNA" };
            tabControl.Controls.Add(tabPage);
            postaviFokus();
            myProperty = null;
            postaviPocetnu();
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
        #endregion

        private void zatvoriSve()
        {
            for(int i = 0; i < tabControl.TabPages.Count; i++)
            {
                tabControl.TabPages.RemoveAt(i);
                i--;
            }
        }

    }
}

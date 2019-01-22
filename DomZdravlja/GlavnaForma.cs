using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DomZdravlja.AttributeClass;
using DomZdravlja.CustomControls;
using DomZdravlja.Helpers;
using DomZdravlja.Properties;
using DomZdravlja.PropertyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZdravlja
{
    public partial class GlavnaForma : Form
    {

        private Tip Tip;
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
                pomZaposleni.KorisnickoIme = dataReader["KorisnickoIme"].ToString();
                pomZaposleni.Password = dataReader["Password"].ToString();
                pomZaposleni.TipZaposlenog = dataReader["TipZaposlenog"].ToString();
                pomZaposleni.OsobaID = Convert.ToInt32(dataReader["OsobaID"]);
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
                pomPacijenti.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                pomPacijenti.DoktorID = Convert.ToInt32(dataReader["DoktorID"]);
                pomPacijenti.OsobaID = Convert.ToInt32(dataReader["OsobaID"]);
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
                pomCijena.CijenaUsluge = Math.Round(Convert.ToDecimal(dataReader["CijenaUsluge"]), 2);
                pomCijena.DatumUspostavljanjaCijene = Convert.ToDateTime(dataReader["DatumUspostavljanjaCijene"]);
                pomCijena.Aktivno = Convert.ToInt32(dataReader["Aktivno"]);
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
                pomDetaljiRacuna.SumaLinije = Math.Round(Convert.ToDecimal(dataReader["SumaLinije"]), 2);
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
                pomDijagnoza.Terapija = dataReader["Terapija"].ToString();
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
                pomRacun.Popust = Math.Round(Convert.ToDecimal(dataReader["Popust"]), 2);
                pomRacun.PacijentID = Convert.ToInt32(dataReader["PacijentID"]);
                pomRacun.SumaRacuna = Math.Round(Convert.ToDecimal(dataReader["SumaRacuna"]), 2);
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
                pomRecepcija.PrijemZaposleniID = Convert.ToInt32(dataReader["PrijemZaposleniID"]);
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
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            culture.DateTimeFormat.LongTimePattern = "dd/MM/yyyy HH:mm";
            Thread.CurrentThread.CurrentCulture = culture;
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

            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POČETNA" };
            tabControl.Controls.Add(tabPage);
            tabControl.TabPages[tabControl.TabPages.Count - 1].Focus();

            postaviPocetnu();
            rijesiSelekt("POČETNA");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as CustomTabControl).TabPages.Count > 0)
            {
                if ((tabControl.SelectedTab as CustomTabPage).State != State.Lookup)
                {
                    rijesiLookup();
                    if (trenutnoStanje == State.Lookup)
                    {
                        if (!provjeriKreiraj(State.Insert))
                            provjeriKreiraj(State.Update);
                    }
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
                CustomTabControl noviTabControl = new CustomTabControl() { HeaderColor = Color.FromArgb(255, 255, 255) };
                noviTabControl.ShowClosingButton = true;
                noviTabControl.Location = new Point(5, 300);
                noviTabControl.Width = 890;
                noviTabControl.Height = 400;
                CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = tabControl.SelectedTab.Text };

                noviTabControl.TabPages.Add(tabPage);
                tabControl.SelectedTab.Controls.Add(noviTabControl);

                CustomDataGridView data = izgled();

                
                noviTabControl.SelectedIndexChanged += NoviTabControl_SelectedIndexChanged;

                data.DataSource = vratiPodatke(Tip, null);
                data.Tip = Tip;

                tabPage.Controls.Add(data);

                data = urediGridView(data) as CustomDataGridView;                           

                data.Dock = DockStyle.Fill;
                data.BorderStyle = BorderStyle.None;
                data.BackgroundColor = Color.FromArgb(255, 255, 255);
                data.Focus();

                IskljuciDugmice(data);


            }
        }

        private void kreirajIzvjestaj()
        {
            Panel panelHeader = new Panel() { Width = 890, Height = 40 };
            panelHeader.Location = new Point(5, 5);
            tabControl.SelectedTab.Controls.Add(panelHeader);

            PictureBox pibMenuNavigation = new PictureBox() { Width = 40, Height = 40, Image = Resources.menu, SizeMode = PictureBoxSizeMode.CenterImage };
            pibMenuNavigation.Click += PibMenuNavigation_Click;
            panelHeader.Controls.Add(pibMenuNavigation);

            Panel panelBody = new Panel() { Width = 890, Height = 755 };
            panelBody.Location = new Point(5, 45);
            tabControl.SelectedTab.Controls.Add(panelBody);

            CustomPanel panelReportsList = new CustomPanel() { Width = 300, Height = 710, BorderColor = Color.FromArgb(0, 67, 128) };

            panelBody.Controls.Add(panelReportsList);
            panelReportsList.Margin = new Padding(0);

            Panel panelReport = new Panel() { Width = 590, Height = 710 };//, BackColor = Color.Aqua };
            panelReport.Location = new Point(301, 0);
            panelBody.Controls.Add(panelReport);

            panelReport.Controls.Add(ucitajReport(4));

            /*Panel panelBtnSeeReport = new Panel() { Width = 296, Height = 58 };
            panelBtnSeeReport.Location = new Point(2, 650);
            panelReportsList.Controls.Add(panelBtnSeeReport);

            Button btnSeeReport = new Button();
            urediButton(btnSeeReport, "PRIKAŽI IZVJEŠTAJ", 150, 30, Resources.eye, new Point(2, 25));
            panelBtnSeeReport.Controls.Add(btnSeeReport);*/

            ReportItem riZaposleni = new ReportItem(Resources.zaposleni, "IZVJEŠTAJ ZAPOSLENI") { IzvjestajID = 1 };
            riZaposleni.ReportItemClick += (send, EventArgs) => { ReportItemClick(send, EventArgs, panelReportsList, panelReport); };
            riZaposleni.Location = new Point(2, 2);
            panelReportsList.Controls.Add(riZaposleni);

            ReportItem riPacijenti = new ReportItem(Resources.pacijent, "IZVJEŠTAJ PACIJENTI") { IzvjestajID = 2 };
            riPacijenti.ReportItemClick += (send, EventArgs) => { ReportItemClick(send, EventArgs, panelReportsList, panelReport); };
            riPacijenti.Location = new Point(2, 52);
            panelReportsList.Controls.Add(riPacijenti);

            ReportItem riRacuni = new ReportItem(Resources.racun, "IZVJEŠTAJ RACUNI") { IzvjestajID = 3 };
            riRacuni.ReportItemClick += (send, EventArgs) => { ReportItemClick(send, EventArgs, panelReportsList, panelReport); };
            riRacuni.Location = new Point(2, 102);
            panelReportsList.Controls.Add(riRacuni);

            ReportItem riRezervacija = new ReportItem(Resources.rezervacija, "IZVJEŠTAJ REZERVACIJE") { IzvjestajID = 4 };
            riRezervacija.ReportItemClick += (send, EventArgs) => { ReportItemClick(send, EventArgs, panelReportsList, panelReport); };
            riRezervacija.Location = new Point(2, 152);
            panelReportsList.Controls.Add(riRezervacija);

            ReportItem riPregled = new ReportItem(Resources.pregled, "IZVJEŠTAJ PREGLEDI") { IzvjestajID = 5 };
            riPregled.ReportItemClick += (send, EventArgs) => { ReportItemClick(send, EventArgs, panelReportsList, panelReport); };
            riPregled.Location = new Point(2, 202);
            panelReportsList.Controls.Add(riPregled);

        }

        private void ReportItemClick(object sender, EventArgs e, CustomPanel panelReportsList, Panel panelReport)
        {
            panelReportsList.Width = 0;
            panelReport.Location = new Point(0, 0);
            panelReport.Width = 890;
            panelReport.Height = 710;

            panelReport.Controls.RemoveAt(0);
            if (sender.GetType() == typeof(ReportItem))
            {
                panelReport.Controls.Add(ucitajReport((sender as ReportItem).IzvjestajID));
            }
            else if(sender.GetType() == typeof(PictureBox))
            {
                panelReport.Controls.Add(ucitajReport(((sender as PictureBox).Parent as ReportItem).IzvjestajID));
            }
            else if (sender.GetType() == typeof(Label))
            {
                panelReport.Controls.Add(ucitajReport(((sender as Label).Parent as ReportItem).IzvjestajID));
            }

        }

        private void PibMenuNavigation_Click(object sender, EventArgs e)
        {
            CustomPanel panelReportsList = tabControl.SelectedTab.Controls[1].Controls[0] as CustomPanel;
            Panel panelReport = tabControl.SelectedTab.Controls[1].Controls[1] as Panel;
            if (panelReportsList.Width == 0)
            {
                panelReportsList.Width = 300;
                panelReportsList.Height = 710;

                panelReport.Width = 590;
                panelReport.Height = 710;
                panelReport.Location = new Point(301, 0);
            }
            else
            {
                panelReportsList.Width = 0;
                panelReport.Location = new Point(0, 0);
                panelReport.Width = 890;
                panelReport.Height = 710;
            }
        }

        private CrystalReportViewer ucitajReport(int? reportID)
        {
            CrystalReportViewer reportViewer = new CrystalReportViewer();

            reportViewer.DisplayGroupTree = false;
            reportViewer.ShowGroupTreeButton = false;
            reportViewer.ShowGotoPageButton = false;
            reportViewer.ShowTextSearchButton = false;
            reportViewer.Dock = DockStyle.Fill;

            var pom = new ReportDocument();
            string reportPath = Environment.CurrentDirectory;

            switch (reportID)
            {
                case null:
                    return null;
                case 1:
                    reportPath += @"\Reports\SviZaposleni.rpt";
                    pom.Load(reportPath);
                    pom.Refresh();
                    pom.SetParameterValue("@Tip", null);
                    break;
                case 2:
                    reportPath += @"\Reports\SviZaposleni.rpt";
                    pom.Load(reportPath);
                    pom.Refresh();
                    //pom.SetParameterValue("@DoktorID", null);
                    break;
                case 3:
                    reportPath += @"\Reports\SviRacuni.rpt";
                    pom.Load(reportPath);
                    pom.Refresh();
                    pom.SetParameterValue("@datum", null);
                    break;
                case 4:
                    reportPath += @"\Reports\SveRezervacije.rpt";
                    pom.Load(reportPath);
                    pom.Refresh();
                    pom.SetParameterValue("@DoktorID", null);
                    break;
                case 5:
                    reportPath += @"\Reports\SviPregledi.rpt";
                    pom.Load(reportPath);
                    pom.Refresh();
                    pom.SetParameterValue("@DoktorId", null);
                    break;
            }

            //pom.
            
            pom.SetDatabaseLogon("domZdravlja_admin", "dom.123");
            reportViewer.ReportSource = pom;

            reportViewer.Refresh();

            return reportViewer;
        }

        private void NoviTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomTabControl control = sender as CustomTabControl;
            CustomTabPage page = control.SelectedTab as CustomTabPage;
            try
            {
                CustomDataGridView pom = page.Controls[0] as CustomDataGridView;
                IskljuciDugmice(pom);
            }
            catch (Exception)
            {

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
                    else if (componentType == ComponentType.Lookup || componentType == ComponentType.InsertLookup)
                    {
                        UCLookup uCLookup = new UCLookup();
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
                CustomToolStrip.GoreClick += CustomToolStrip_GoreClick;
                CustomToolStrip.DoleClick += CustomToolStrip_DoleClick;
                CustomToolStrip.PrviClick += CustomToolStrip_PrviClick;
                CustomToolStrip.ZadnjiClick += CustomToolStrip_ZadnjiClick;
                tabControl.SelectedTab.Controls.Add(CustomToolStrip);

            }
        }

        private void CustomToolStrip_ZadnjiClick(object sender, EventArgs e)
        {
            foreach (Control control in tabControl.SelectedTab.Controls)
            {
                if (control.GetType() == typeof(CustomTabControl))
                {
                    CustomTabControl tabDonji = control as CustomTabControl;
                    DataGridView dgv = tabDonji.SelectedTab.Controls[0] as DataGridView;
                    dgv.Rows[dgv.Rows.Count - 1].Selected = true;
                    dgv.CurrentCell = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0];
                }
            }
        }

        private void CustomToolStrip_PrviClick(object sender, EventArgs e)
        {
            foreach (Control control in tabControl.SelectedTab.Controls)
            {
                if (control.GetType() == typeof(CustomTabControl))
                {
                    CustomTabControl tabDonji = control as CustomTabControl;
                    DataGridView dgv = tabDonji.SelectedTab.Controls[0] as DataGridView;
                    dgv.Rows[0].Selected = true;
                    dgv.CurrentCell = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0];
                }
            }
        }

        private void CustomToolStrip_DoleClick(object sender, EventArgs e)
        {
            foreach (Control control in tabControl.SelectedTab.Controls)
            {
                if (control.GetType() == typeof(CustomTabControl))
                {
                    CustomTabControl tabDonji = control as CustomTabControl;
                    DataGridView dgv = tabDonji.SelectedTab.Controls[0] as DataGridView;
                    if (dgv.Rows[0].Index == dgv.Rows.Count - 1)
                    { }
                    dgv.Rows[dgv.SelectedRows[0].Index + 1].Selected = true;
                    dgv.CurrentCell = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0];
                }
            }
        }

        private void CustomToolStrip_GoreClick(object sender, EventArgs e)
        {
            foreach (Control control in tabControl.SelectedTab.Controls)
            {
                if (control.GetType() == typeof(CustomTabControl))
                {
                    CustomTabControl tabDonji = control as CustomTabControl;
                    DataGridView dgv = tabDonji.SelectedTab.Controls[0] as DataGridView;
                    if (dgv.Rows[0].Index == dgv.Rows.Count + 1)
                    { }
                    dgv.Rows[dgv.SelectedRows[0].Index - 1].Selected = true;
                    dgv.CurrentCell = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0];
                }
            }
        }
        

        private void CustomToolStrip_PretragaClick(object sender, EventArgs e)
        {
            var items = tabControl.SelectedTab.Controls;
            FlowLayoutPanel pomPretraga = null;
            CustomTabControl pomTabControl = null;

            foreach (var item in items)
            {

                if (item.GetType().Equals(typeof(FlowLayoutPanel)))
                {
                    pomPretraga = item as FlowLayoutPanel;
                }
                if (item.GetType().Equals(typeof(CustomTabControl)))
                {
                    pomTabControl = item as CustomTabControl;
                }
            }
            UCTekst pom = null;
            bool postoji = false;
            var itemsPretraga = pomPretraga.Controls;
            UCTekst[] listaTxt = { null, null, null };
            pomTabControl.PritisnutX += PomTabControl_PritisnutX;

            foreach (var item in itemsPretraga)
            {
                if (item.GetType() == typeof(UCTekst))
                {
                    pom = item as UCTekst;
                    for (int i = 0; i < 3; i++)
                    {
                        if (listaTxt[i] == null)
                        {
                            listaTxt[i] = pom;
                            break;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(pom.Controls[0].Text))
                    {
                        postoji = true;
                    }
                }
            }
            if (!postoji)
                return;
            if (Tip != Tip.Karton)
            {
                CustomDataGridView data = izgled();
                data.Tip = Tip;
                data.DataSource = vratiPodatke(Tip, null);

                CustomTabPage noviPage1 = new CustomTabPage() { State = State.Search, Naziv = "PRETRAGA" };
                foreach (CustomTabPage p in pomTabControl.TabPages)
                {
                    if (p.State == State.Search)
                    {
                        pomTabControl.TabPages.Remove(p);
                    }
                }
                pomTabControl.TabPages.Add(noviPage1);
                pomTabControl.SelectedTab = noviPage1;
                noviPage1.Controls.Add(data);


                CustomDataGridView dgvNovi = izgled();
                dgvNovi.Tip = Tip;
                dgvNovi.Dock = DockStyle.Fill;
                dgvNovi.BorderStyle = BorderStyle.None;
                dgvNovi.BackgroundColor = Color.FromArgb(255, 255, 255);
                dgvNovi.Focus();

                foreach (DataGridViewColumn item in data.Columns)
                {
                    dgvNovi.Columns.Add((DataGridViewColumn)item.Clone());
                }

                dgvNovi = urediGridView(dgvNovi) as CustomDataGridView;
                data = urediGridView(data) as CustomDataGridView;


                foreach (DataGridViewRow row in data.Rows)
                {

                    if (((listaTxt[0] == null) ? true : (row.Cells[listaTxt[0].Naziv].Value.ToString().ToLower().Contains(listaTxt[0].Value.ToLower()))) &&
                    ((listaTxt[1] == null) ? true : (row.Cells[listaTxt[1].Naziv].Value.ToString().ToLower().Contains(listaTxt[1].Value.ToLower()))) &&
                    ((listaTxt[2] == null) ? true : (row.Cells[listaTxt[2].Naziv].Value.ToString().ToLower().Contains(listaTxt[2].Value.ToLower()))))
                    {
                        int index = dgvNovi.Rows.Add(row.Clone() as DataGridViewRow);
                        foreach (DataGridViewCell o in row.Cells)
                        {
                            dgvNovi.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                        }
                    }
                }

                noviPage1.Controls.Remove(data);
                noviPage1.Controls.Add(dgvNovi);


                IskljuciDugmice(dgvNovi);


                data = urediGridView(data) as CustomDataGridView;
            }
            else
            {
                foreach (CustomTabPage p in pomTabControl.TabPages)
                {
                    if (p.State == State.Search)
                    {
                        pomTabControl.TabPages.Remove(p);
                    }
                }

                int index;
                if (!int.TryParse(listaTxt[0].Value.ToString(), out index)) return;

                int i = 0;

                i = propertyInterfaces[7].Cast<PropertyKarton>().Where(karton => karton.KartonID == index).Select(k => k.KartonID).FirstOrDefault();

                if (i == 0) return;

                CustomTabPage noviPage1 = new CustomTabPage() { State = State.Search, Naziv = "OSNOVNE INFORMACIJE" };
                CustomTabPage noviPage2 = new CustomTabPage() { State = State.Search, Naziv = "FAKTORI RIZIKA" };
                CustomTabPage noviPage3 = new CustomTabPage() { State = State.Search, Naziv = "PREGLEDI" };

                pomTabControl.TabPages.Add(noviPage1);
                pomTabControl.TabPages.Add(noviPage2);
                pomTabControl.TabPages.Add(noviPage3);

                CustomDataGridView data = izgled();
                data.Tip = Tip.Karton;
                data.DataSource = vratiPodatke(Tip.Karton, i);
                data = urediGridView(data) as CustomDataGridView;
                data.Dock = DockStyle.Fill;
                data.BorderStyle = BorderStyle.None;
                data.BackgroundColor = Color.FromArgb(255, 255, 255);
                noviPage1.Controls.Add(data);
                pomTabControl.SelectedTab = noviPage1;
                data = urediGridView(data) as CustomDataGridView;

                CustomDataGridView data1 = izgled();
                data1.Tip = Tip.FaktorRizika;
                data1.DataSource = vratiPodatke(Tip.FaktorRizika, i);
                data1.Dock = DockStyle.Fill;
                data1.BorderStyle = BorderStyle.None;
                data1.BackgroundColor = Color.FromArgb(255, 255, 255);
                data1 = urediGridView(data1) as CustomDataGridView;
                noviPage2.Controls.Add(data1);
                pomTabControl.SelectedTab = noviPage2;
                data1 = urediGridView(data1) as CustomDataGridView;

                CustomDataGridView data2 = izgled();
                data2.Tip = Tip.Pregled;
                data2.DataSource = vratiPodatke(Tip.Pregled, i);
                data2.Dock = DockStyle.Fill;
                data2.BorderStyle = BorderStyle.None;
                data2.BackgroundColor = Color.FromArgb(255, 255, 255);
                data2 = urediGridView(data2) as CustomDataGridView;
                noviPage3.Controls.Add(data2);
                pomTabControl.SelectedTab = noviPage3;
                data2 = urediGridView(data2) as CustomDataGridView;

            }

        }

        private void PomTabControl_PritisnutX(object sender, EventArgs e)
        {
            var items = tabControl.SelectedTab.Controls;
            FlowLayoutPanel pomPretraga = null;

            foreach (var item in items)
            {

                if (item.GetType().Equals(typeof(FlowLayoutPanel)))
                {
                    pomPretraga = item as FlowLayoutPanel;
                }
                
            }
            var itemsPretraga = pomPretraga.Controls;
            foreach (var item in itemsPretraga)
            {
                if (item.GetType() == typeof(UCTekst))
                {
                    UCTekst pom = item as UCTekst;
                    pom.Value = "";
                }
            }
        }

        private void IskljuciDugmice(CustomDataGridView dgvNovi)
        {
            if (dgvNovi.Rows.Count == 0 || dgvNovi.Rows.Count == 1)
            {
                CustomToolStrip.Gore = false;
                CustomToolStrip.Prvi = false;
                CustomToolStrip.Dole = false;
                CustomToolStrip.Zadnji = false;
            }
            else
            {
                dgvNovi.Rows[0].Selected = true;
                CustomToolStrip.Dole = true;
                CustomToolStrip.Zadnji = true;
            }
        }

        private void CustomToolStrip_AzurirajClick(object sender, EventArgs e)
        {
            foreach (CustomTabPage tab in tabControl.TabPages)
            {
                if (tab.State == State.Update)
                {
                    postaviFokus(State.Update);
                    return;
                }
            }

            var items = tabControl.SelectedTab.Controls;
            CustomTabControl pomTabControl = null;

            foreach (var item in items)
            {
                if (item.GetType().Equals(typeof(CustomTabControl)))
                {
                    pomTabControl = item as CustomTabControl;
                }
            }

            DataGridView data = pomTabControl.SelectedTab.Controls[0] as DataGridView;

            if (data.SelectedRows.Count > 0)
            {

                DataGridViewRow dataRow = data.SelectedRows[0];

                CustomTabPage tabPage = new CustomTabPage() { State = State.Update, Naziv = "AŽURIRANJE" };
                trenutnoStanje = State.Update;
                tabControl.TabPages.Add(tabPage);
                postaviFokus(State.Update);

                dodajMetoda(sender, e, myProperty, null, Use.Update);
                populateControls(tabPage, dataRow, data.Columns, myProperty);

            }

        }

        private void populateControls(CustomTabPage tabPage, DataGridViewRow dataRow, DataGridViewColumnCollection columnCollection, PropertyInterface propertyInterface)
        {
            int id;
            var propertie = propertyInterface.GetType().GetProperties();
            PropertyInfo property = null;

            foreach (Control c in tabPage.Controls[0].Controls)
            {
                if (c.GetType() == typeof(UCDatum))
                {
                    id = getCellID((c as UCDatum).Naziv, columnCollection);
                    if (id != -1)
                    {
                        (c as UCDatum).Value = Convert.ToDateTime(dataRow.Cells[id].Value);
                    }
                    else
                    {

                    }
                }
                else if (c.GetType() == typeof(UCTekst))
                {
                    id = getCellID((c as UCTekst).Naziv, columnCollection);
                    if (id != -1)
                    {
                        (c as UCTekst).Value = dataRow.Cells[id].Value.ToString();
                    }
                    else
                    {

                    }
                }
                else if (c.GetType() == typeof(UCRadioButton))
                {
                    id = getCellID((c as UCRadioButton).Naziv, columnCollection);
                    if (id != -1)
                    {
                        property = null;
                        string vrijednost = dataRow.Cells[id].Value.ToString();
                        property = propertie.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (c as UCRadioButton).Naziv).FirstOrDefault();
                        if (property != null)
                        {

                            if (property.IsDefined(typeof(OpcijeRadioButton)))
                            {
                                if (property.GetCustomAttribute<OpcijeRadioButton>().Vrijednost1.ToString() == vrijednost)
                                {
                                    (c as UCRadioButton).postavi(1);
                                }
                                else (c as UCRadioButton).postavi(2);
                            }
                        }

                    }
                    else
                    {

                    }
                }
                else if (c.GetType() == typeof(UCLookup))
                {
                    id = getCellID((c as UCLookup).Naziv, columnCollection);

                    if (id != -1)
                    {
                        property = null;
                        (c as UCLookup).Value = dataRow.Cells[id].Value.ToString();


                        property = propertie.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (c as UCLookup).Naziv).FirstOrDefault();
                        if (property != null)
                        {
                            if (property.IsDefined(typeof(ForeignKey)))
                            {
                                Tip t = property.GetCustomAttribute<ForeignKey>().Tip;
                                if (t == Tip.OsobaBezPosla || t == Tip.Osoba) t = Tip.SveOsobe;
                                if (t == Tip.KartonNema) t = Tip.Karton;
                                if (t == Tip.NoviRacun) t = Tip.Racun;
                                if (t == Tip.Cjenovnik) t = Tip.CjenovnikZaSve;

                                DataTable data = vratiPodatke(t, null);
                                data = urediDataTable(data);

                                var r = from p in data.AsEnumerable()
                                        where p.Field<int>(property.GetCustomAttribute<ForeignKey>().ReferencedColumn) == Convert.ToInt32(dataRow.Cells[id].Value)
                                        select p;

                                DataRow dRow = r.FirstOrDefault();

                                object col1 = property.GetCustomAttribute<ForeignKey>().BackCol1;
                                object col2 = property.GetCustomAttribute<ForeignKey>().BackCol2;


                                (c as UCLookup).Info = dRow.Field<string>(col1.ToString()) + " "
                                             + (col2.ToString() != "" ? dRow.Field<string>(col2.ToString()) : "");

                            }

                        }
                    }
                    else
                    {

                    }
                }
                else if (c.GetType() == typeof(UCLookupInsert))
                {
                    id = getCellID((c as UCLookupInsert).Naziv, columnCollection);
                    if (id != -1)
                    {
                        property = null;
                        (c as UCLookupInsert).Value = dataRow.Cells[id].Value.ToString();
                        property = propertie.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (c as UCLookupInsert).Naziv).FirstOrDefault();
                        if (property != null)
                        {
                            if (property.IsDefined(typeof(ForeignKey)))
                            {
                                Tip t = property.GetCustomAttribute<ForeignKey>().Tip;
                                if (t == Tip.OsobaBezPosla || t == Tip.Osoba) t = Tip.SveOsobe;
                                if (t == Tip.KartonNema) t = Tip.Karton;
                                if (t == Tip.NoviRacun) t = Tip.Racun;
                                if (t == Tip.Cjenovnik) t = Tip.CjenovnikZaSve;

                                DataTable data = vratiPodatke(t, null);
                                data = urediDataTable(data);

                                var r = from p in data.AsEnumerable()
                                        where p.Field<int>(property.GetCustomAttribute<ForeignKey>().ReferencedColumn) == Convert.ToInt32(dataRow.Cells[id].Value)
                                        select p;

                                DataRow dRow = r.FirstOrDefault();

                                object col1 = property.GetCustomAttribute<ForeignKey>().BackCol1;
                                object col2 = property.GetCustomAttribute<ForeignKey>().BackCol2;

                                if (dRow != null)
                                {
                                    (c as UCLookupInsert).Info = dRow.Field<string>(col1.ToString()) + " "
                                                 + (col2.ToString() != "" && !col2.ToString().Contains("Šifra") ? dRow.Field<string>(col2.ToString()) : "");
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private int getCellID(string columnName, DataGridViewColumnCollection columnCollection)
        {
            for (int i = 0; i < columnCollection.Count; i++)
            {
                if (columnCollection[i].HeaderText == columnName)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

        #region EventDodaj
        private void CustomToolStrip_DodajClick(object sender, EventArgs e)
        {

            foreach (CustomTabPage tab in tabControl.TabPages)
            {
                if (tab.State == State.Insert)
                {
                    postaviFokus(State.Insert);
                    return;
                }
            }

            CustomTabPage tabPage = new CustomTabPage() { State = State.Insert, Naziv = "DODAVANJE" };
            trenutnoStanje = State.Insert;
            tabControl.TabPages.Add(tabPage);
            postaviFokus(State.Insert);

            dodajMetoda(sender, e, myProperty, null, Use.Insert);
        }

        private void UCLookupInsert_DodajControlClick(object sender, EventArgs e)
        {
            CustomTabPage tabPage = new CustomTabPage() { State = State.Lookup, Naziv = "KREIRAJ" };
            trenutnoStanje = State.Lookup;
            tabControl.TabPages.Add(tabPage);
            postaviFokus(State.Lookup);

            string name = ((sender as Button).Parent as UCLookupInsert).ThisColumn;
            string thisTable = ((sender as Button).Parent as UCLookupInsert).ThisTable;

            var objekatSearch = Activator.CreateInstance(Type.GetType(thisTable));

            PropertyInfo property = objekatSearch.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == name).FirstOrDefault();

            var objekat = Activator.CreateInstance(Type.GetType(property.GetCustomAttribute<ForeignKey>().ReferencedTable));

            dodajMetoda(sender, e, (objekat as PropertyInterface), (sender as Button).Parent as UCLookupInsert, ((sender as Button).Parent as UCLookupInsert).Use);
            lookupTab();

            if (((sender as Button).Parent as UCLookupInsert).Use == Use.Update)
            {
                int id = Convert.ToInt32(((sender as Button).Parent as UCLookupInsert).Value);

                Tip t = property.GetCustomAttribute<ForeignKey>().Tip;
                if (t == Tip.OsobaBezPosla || t == Tip.Osoba) t = Tip.SveOsobe;
                if (t == Tip.NoviRacun) t = Tip.Racun;
                if (t == Tip.KartonNema) t = Tip.Karton;
                if (t == Tip.Cjenovnik) t = Tip.CjenovnikZaSve;

                DataTable data = vratiPodatke(t, null);
                data = urediDataTable(data);

                var r = from p in data.AsEnumerable()
                        where p.Field<int>(property.GetCustomAttribute<ForeignKey>().ReferencedColumn) == id
                        select p;

                DataRow dRow = r.FirstOrDefault();

                DataGridView dataGird = new DataGridView();


                foreach (DataColumn col in data.Columns)
                {
                    var c = new DataGridViewTextBoxColumn() { HeaderText = col.ColumnName, Name = col.ColumnName };
                    dataGird.Columns.Add(c);
                }
                dataGird.Rows.Add(dRow.ItemArray);
                dataGird.AllowUserToAddRows = false;

                populateControls(tabPage, dataGird.Rows[0], dataGird.Columns, (objekat as PropertyInterface));

            }

        }

        private void UCLookupInsert_LookupControlClick(object sender, EventArgs e)
        {
            string name = ((sender as Button).Parent as UCLookupInsert).ThisColumn;
            string thisTable = ((sender as Button).Parent as UCLookupInsert).ThisTable;

            var objekat = Activator.CreateInstance(Type.GetType(thisTable));

            PropertyInfo property = objekat.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == name).FirstOrDefault();

            lookupMetoda(sender, e, property);
        }

        #endregion

        private void BtnOdustani_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabControl.SelectedTab);
            rijesiLookup();
            if (!provjeriKreiraj(State.Lookup))
            {
                postaviFokus(State.Insert);
            }
            {
                lookupTab();
            }
        }

        #region SacuvajDodavanje
        private void BtnSacuvaj_Click(object sender, EventArgs e, PropertyInterface propertyInterface, UCLookupInsert cLookupInsert, Use use)
        {

            var type = propertyInterface.GetType();
            var properties = type.GetProperties();
            bool proslo = true;

            foreach (Control control in tabControl.SelectedTab.Controls[0].Controls)
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
                                    property.SetValue(propertyInterface, Convert.ToInt32(rez));
                                }
                                else if (property.PropertyType == typeof(Decimal))
                                {
                                    property.SetValue(propertyInterface, Convert.ToDecimal(rez));
                                }
                                else if (property.PropertyType == typeof(String))
                                {
                                    property.SetValue(propertyInterface, rez);
                                }
                                (control as UCTekst).Greska = false;
                            }
                            else
                            {
                                (control as UCTekst).Greska = true;
                                proslo = false;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(rez))
                            {
                            }
                            else if (property.PropertyType == typeof(int))
                            {
                                property.SetValue(propertyInterface, Convert.ToInt32(rez));
                            }
                            else if (property.PropertyType == typeof(Decimal))
                            {
                                property.SetValue(propertyInterface, Convert.ToDecimal(rez));
                            }
                            else if (property.PropertyType == typeof(String))
                            {
                                property.SetValue(propertyInterface, rez);
                            }
                            (control as UCTekst).Greska = false;
                        }
                    }
                    else if (control.GetType() == typeof(UCDatum))
                    {
                        property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCDatum).Naziv).FirstOrDefault();
                        DateTime rez = (control as UCDatum).Value;
                        property.SetValue(propertyInterface, rez);
                    }
                    else if (control.GetType() == typeof(UCRadioButton))
                    {
                        property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCRadioButton).Naziv).FirstOrDefault();
                        if ((control as UCRadioButton).Vrijednost)
                        {
                            property.SetValue(propertyInterface, Convert.ChangeType(property.GetCustomAttribute<OpcijeRadioButton>().Vrijednost1, property.PropertyType));
                        }
                        else
                        {
                            property.SetValue(propertyInterface, Convert.ChangeType(property.GetCustomAttribute<OpcijeRadioButton>().Vrijednost2, property.PropertyType));
                        }
                    }
                    else if (control.GetType() == typeof(UCLookup))
                    {
                        property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCLookup).Naziv).FirstOrDefault();
                        if (property.IsDefined(typeof(ValidatePattern)))
                        {

                            string rez = (control as UCLookup).Value;
                            if (property.GetCustomAttribute<ValidatePattern>().IsValid(rez))
                            {
                                property.SetValue(propertyInterface, Convert.ToInt32(rez));
                                (control as UCLookup).Greska = false;
                            }
                            else
                            {
                                (control as UCLookup).Greska = true;
                                proslo = false;
                            }
                        }
                    }
                    else if (control.GetType() == typeof(UCLookupInsert))
                    {
                        property = properties.Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == (control as UCLookupInsert).Naziv).FirstOrDefault();
                        if (property.IsDefined(typeof(ValidatePattern)))
                        {

                            string rez = (control as UCLookupInsert).Value;
                            if (property.GetCustomAttribute<ValidatePattern>().IsValid(rez))
                            {
                                property.SetValue(propertyInterface, Convert.ToInt32(rez));
                                (control as UCLookupInsert).Greska = false;
                            }
                            else
                            {
                                (control as UCLookupInsert).Greska = true;
                                proslo = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }

            }
            if (proslo)
            {
                try
                {
                    if (use == Use.Insert)
                    {
                        if (cLookupInsert != null)
                        {
                            var id = SqlHelper.ExecuteScalar(SqlHelper.GetConnectionString(), CommandType.Text, propertyInterface.GetInsertQuery() + "SELECT SCOPE_IDENTITY()", propertyInterface.GetInsertParameters().ToArray());
                            MessageBox.Show("Uspješno ste dodali!");

                            PropertyInfo prop = myProperty.GetType().GetProperties().Where(prope => prope.GetCustomAttribute<DisplayNameAttribute>().DisplayName == cLookupInsert.Naziv).FirstOrDefault();

                            string col1 = prop.GetCustomAttribute<ForeignKey>().BackCol1;
                            string col2 = prop.GetCustomAttribute<ForeignKey>().BackCol2;

                            cLookupInsert.Value = id.ToString();

                            if (col2.Contains("Šifra"))
                            {

                                foreach (Control control in (sender as Button).Parent.Parent.Controls[0].Controls)
                                {
                                    if (control.GetType() == typeof(UCLookup))
                                    {
                                        if ((control as UCLookup).Naziv == col2)
                                        {
                                            cLookupInsert.Info = (control as UCLookup).Info;
                                        }
                                    }
                                }

                            }
                            else
                            {

                                PropertyInfo propCol1 = col1 != "" ? propertyInterface.GetType().GetProperties().Where(prope => prope.GetCustomAttribute<DisplayNameAttribute>().DisplayName == col1).FirstOrDefault() : null;
                                PropertyInfo propCol2 = col2 != "" ? propertyInterface.GetType().GetProperties().Where(prope => prope.GetCustomAttribute<DisplayNameAttribute>().DisplayName == col2).FirstOrDefault() : null;

                                cLookupInsert.Info = propCol1.GetValue(propertyInterface) + " "
                                        + (col2 != "" ? propCol2.GetValue(propertyInterface) : "");
                            }

                        }
                        else
                        {
                            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, propertyInterface.GetInsertQuery(), propertyInterface.GetInsertParameters().ToArray());
                            MessageBox.Show("Uspješno ste dodali!");
                        }
                    }
                    else
                    {
                        SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, propertyInterface.GetUpdateQuery(), propertyInterface.GetUpdateParameters().ToArray());
                        MessageBox.Show("Uspješno ste ažurirali!");
                    }

                    CustomTabPage tabPage = tabControl.TabPages[0] as CustomTabPage;

                    CustomDataGridView c = (tabPage.Controls[2] as CustomTabControl).TabPages[0].Controls[0] as CustomDataGridView;

                    

                    c.DataSource = vratiPodatke(c.Tip, null);

                    tabControl.TabPages.Remove(tabControl.SelectedTab);
                    rijesiLookup();
                    if (!provjeriKreiraj(State.Lookup))
                    {
                        if (!provjeriKreiraj(State.Update))
                            if (!provjeriKreiraj(State.Insert))
                                postaviFokus(State.Main);
                    }
                    {
                        lookupTab();
                    }

                    IskljuciDugmice(c);
                }
                catch (Exception ex)
                {
                    
                }
            }
            

        }
        #endregion

        #region MedjusobneMetode

        private void dodajMetoda(object sender, EventArgs e, PropertyInterface propertyInterface, UCLookupInsert uCLookupInsert1, Use use)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Width = 908;
            flowLayoutPanel.Height = 600;
            tabControl.SelectedTab.Controls.Add(flowLayoutPanel);

            var type = propertyInterface.GetType();
            var properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {

                if (property.IsDefined(typeof(Invisible)))
                {
                    if (property.GetCustomAttribute<Invisible>().Use == use || property.GetCustomAttribute<Invisible>().Use == Use.InsertAndUpdate)
                        continue;
                }

                ComponentType componentType;
                componentType = property.GetCustomAttribute<GenerateComponent>().ComponentType;


                if (componentType == ComponentType.Tekst)
                {
                    UCTekst uCTekst = new UCTekst();
                    uCTekst.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    flowLayoutPanel.Controls.Add(uCTekst);
                    if (use == Use.Insert)
                        defaultValue(property, uCTekst);
                    if (property.IsDefined(typeof(Editing)))
                    {
                        if (property.GetCustomAttribute<Editing>().Use != use &&
                            property.GetCustomAttribute<Editing>().Use != Use.InsertAndUpdate)
                        {
                            uCTekst.setReadOnly();
                        }
                    }
                    else uCTekst.setReadOnly();


                    if (propertyInterface.GetType() == typeof(PropertyDetaljiRacuna))
                    {
                        if (uCTekst.Naziv == "Količina")
                        {
                            uCTekst.UCTekstTextChanged += UCTekst_UCTekstTextChanged;
                        }
                    }

                }
                else if (componentType == ComponentType.Datum)
                {
                    UCDatum uCDatum = new UCDatum();
                    uCDatum.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    flowLayoutPanel.Controls.Add(uCDatum);
                    if (uCDatum.Naziv == "Datum rođenja")
                    {
                        DateTimePicker dtp = uCDatum.Controls[1] as DateTimePicker;
                        dtp.CustomFormat = "dd/MM/yyyy";
                    }
                    if (use == Use.Insert)
                        defaultValue(property, uCDatum);
                    if (property.IsDefined(typeof(Editing)))
                    {
                        if (property.GetCustomAttribute<Editing>().Use != use &&
                            property.GetCustomAttribute<Editing>().Use != Use.InsertAndUpdate)
                        {
                            uCDatum.setReadOnly();
                        }
                    }
                    else uCDatum.setReadOnly();
                }
                else if (componentType == ComponentType.RadioButton)
                {
                    UCRadioButton uCRadioButton = new UCRadioButton();
                    uCRadioButton.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    uCRadioButton.NazivOpcije1 = property.GetCustomAttribute<OpcijeRadioButton>().Param1;
                    uCRadioButton.NazivOpcije2 = property.GetCustomAttribute<OpcijeRadioButton>().Param2;
                    flowLayoutPanel.Controls.Add(uCRadioButton);
                    if (use == Use.Insert)
                        defaultValue(property, uCRadioButton);
                    if (property.IsDefined(typeof(Editing)))
                    {
                        if (property.GetCustomAttribute<Editing>().Use != use &&
                            property.GetCustomAttribute<Editing>().Use != Use.InsertAndUpdate)
                        {
                            uCRadioButton.setReadOnly();
                        }
                    }
                    else uCRadioButton.setReadOnly();
                }
                else if (componentType == ComponentType.Lookup)
                {
                    UCLookup uCLookup = new UCLookup();
                    uCLookup.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    uCLookup.ThisTable = propertyInterface.GetType().ToString();
                    uCLookup.ThisColumn = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    uCLookup.LookupClick += UCLookup_LookupClick;
                    flowLayoutPanel.Controls.Add(uCLookup);
                    if (use == Use.Insert)
                        defaultValue(property, uCLookup);
                    if (property.IsDefined(typeof(Editing)))
                    {
                        if (property.GetCustomAttribute<Editing>().Use != use &&
                            property.GetCustomAttribute<Editing>().Use != Use.InsertAndUpdate)
                        {
                            uCLookup.setReadOnly();
                        }
                    }
                    else uCLookup.setReadOnly();

                    if (propertyInterface.GetType() == typeof(PropertyDetaljiRacuna))
                    {
                        if (uCLookup.Naziv == "Šifra cjenovnika")
                        {
                            uCLookup.LookupTextChanged += UCLookup_LookupTextChanged;
                        }
                    }

                    if (propertyInterface.GetType() == typeof(PropertyRacun))
                    {
                        if (uCLookup.Naziv == "Šifra pacijenta")
                        {
                            uCLookup.LookupTextChanged += ProvjerDaLiJePacijentOsiguran_LookupTextChanged1;
                        }
                    }

                }
                else if (componentType == ComponentType.InsertLookup)
                {
                    UCLookupInsert uCLookupInsert = new UCLookupInsert();
                    uCLookupInsert.Naziv = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    uCLookupInsert.ThisTable = propertyInterface.GetType().ToString();
                    uCLookupInsert.ThisColumn = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    uCLookupInsert.LookupControlClick += UCLookupInsert_LookupControlClick;
                    uCLookupInsert.DodajControlClick += UCLookupInsert_DodajControlClick;
                    uCLookupInsert.Use = use;
                    flowLayoutPanel.Controls.Add(uCLookupInsert);
                    if (use == Use.Insert)
                        defaultValue(property, uCLookupInsert);
                    if (property.IsDefined(typeof(Editing)))
                    {
                        if (property.GetCustomAttribute<Editing>().Use != use &&
                            property.GetCustomAttribute<Editing>().Use != Use.InsertAndUpdate)
                        {
                            uCLookupInsert.setReadOnly();
                        }
                        else
                        {
                            if (uCLookupInsert.Use == Use.Update) uCLookupInsert.setEdit();
                        }
                    }
                    else uCLookupInsert.setReadOnly();
                }
            }

            Panel panel = new Panel();
            //panel.Location = new Point(0, 500);//ovo vratiti
            panel.Location = new Point(0, 600);
            panel.Width = 908;
            panel.Height = 160;

            Button btnSacuvaj = new Button();
            urediButton(btnSacuvaj, "SAČUVAJ", 88, 30, Resources.tick, new Point(682, 100));
            btnSacuvaj.Click += (send, EventArgs) => { BtnSacuvaj_Click(send, EventArgs, propertyInterface, uCLookupInsert1, use); };

            Button btnOdustani = new Button();
            urediButton(btnOdustani, "ODUSTANI", 96, 30, Resources.multiply, new Point(767, 100));
            btnOdustani.Click += BtnOdustani_Click;

            panel.Controls.Add(btnSacuvaj);
            panel.Controls.Add(btnOdustani);

            tabControl.SelectedTab.Controls.Add(panel);
        }

        private void ProvjerDaLiJePacijentOsiguran_LookupTextChanged1(object sender, EventArgs e)
        {
            UCLookup lookupPacijent = findControl("Šifra pacijenta") as UCLookup;
            int index = Convert.ToInt32(lookupPacijent.Value);

            var i = propertyInterfaces[1].Cast<PropertyPacijent>().Where(pacijent => pacijent.PacijentID == index).FirstOrDefault();

            if (i == null) return;

            UCTekst pomPopust = findControl("Popust") as UCTekst;
            if (i.Osiguran == 1)
            {
                pomPopust.Value = 90.ToString();
            }
            else
            {
                pomPopust.Value = 0.ToString();
            }
        }

        private void urediButton(Button btn, string tekst, int width, int height, Image image, Point location)
        {
            btn.Text = tekst;
            btn.Width = width;
            btn.Height = height;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.AutoSize = false;
            btn.TextAlign = ContentAlignment.MiddleRight;
            btn.ForeColor = Color.FromArgb(51, 128, 196);
            btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
            btn.Image = image;
            btn.Location = location;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += Btn_MouseEnter;
            btn.MouseLeave += Btn_MouseLeave;
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
        }

        private void UCLookup_LookupTextChanged(object sender, EventArgs e)
        {
            izracunajCijenu();
        }

        private void UCTekst_UCTekstTextChanged(object sender, EventArgs e)
        {
            izracunajCijenu();
        }

        private void izracunajCijenu()
        {
            int cijenaID;
            int kolicina;
            if (int.TryParse((findControl("Šifra cjenovnika") as UCLookup).Value, out cijenaID) &&
                int.TryParse((findControl("Količina") as UCTekst).Value, out kolicina))
            {
                decimal? cijena = propertyInterfaces[2].Cast<PropertyCjenovnik>().Where(cjenovnik => cjenovnik.CjenovnikID
                    == cijenaID).Select(cjenovnik => cjenovnik.CijenaUsluge).FirstOrDefault();
                if (cijena != null)
                {
                    decimal? rez = cijena * kolicina;
                    (findControl("Suma linije") as UCTekst).Value = rez.ToString();
                }
                else (findControl("Suma linije") as UCTekst).Value = 0.ToString();
            }
            else (findControl("Suma linije") as UCTekst).Value = 0.ToString();
        }

        private Control findControl(string tekst)
        {
            foreach (Control c in tabControl.SelectedTab.Controls[0].Controls)
            {
                if (c.GetType() == typeof(UCTekst))
                {
                    if ((c as UCTekst).Naziv == tekst) return c;
                }
                else if (c.GetType() == typeof(UCLookup))
                {
                    if ((c as UCLookup).Naziv == tekst) return c;
                }
            }
            return null;
        }

        private void defaultValue(PropertyInfo property, Control control)
        {
            if (property.IsDefined(typeof(DefaultPropertValue)))
            {
                if (control.GetType() == typeof(UCTekst))
                {
                    if (property.GetCustomAttribute<DefaultPropertValue>().Target == TargetValue.StartPrize)
                        (control as UCTekst).Value = property.GetCustomAttribute<DefaultPropertValue>().Value.ToString();
                    else if (property.GetCustomAttribute<DefaultPropertValue>().Target == TargetValue.ProvjeraDaLiJeOsiguran)
                        (control as UCTekst).Value = property.GetCustomAttribute<DefaultPropertValue>().Value.ToString();
                }
                else if (control.GetType() == typeof(UCDatum))
                {
                    if (property.GetCustomAttribute<DefaultPropertValue>().Target == TargetValue.DefaultDate)
                        (control as UCDatum).Value = Convert.ToDateTime(property.GetCustomAttribute<DefaultPropertValue>().Value);
                    else if (property.GetCustomAttribute<DefaultPropertValue>().Target == TargetValue.Today)
                        (control as UCDatum).Value = DateTime.Now;
                }
                else if (control.GetType() == typeof(UCRadioButton))
                {

                }
                else if (control.GetType() == typeof(UCLookup))
                {
                    if (property.GetCustomAttribute<DefaultPropertValue>().Target == TargetValue.LoginUser)
                    {
                        ucitaj(9);
                        PropertyOsoba osoba = propertyInterfaces[9].Cast<PropertyOsoba>().Where(o => o.OsobaID == Logovan.OsobaID).FirstOrDefault();

                        (control as UCLookup).Value = Logovan.ZaposleniID.ToString();
                        (control as UCLookup).Info = osoba.Ime + " " + osoba.Prezime;
                    }
                }
                else if (control.GetType() == typeof(UCLookupInsert))
                {
                    if (property.GetCustomAttribute<DefaultPropertValue>().Target == TargetValue.LoginUser)
                    {
                        ucitaj(9);
                        PropertyOsoba osoba = propertyInterfaces[9].Cast<PropertyOsoba>().Where(o => o.OsobaID == Logovan.OsobaID).FirstOrDefault();

                        (control as UCLookup).Value = Logovan.ZaposleniID.ToString();
                        (control as UCLookup).Info = osoba.Ime + " " + osoba.Prezime;
                    }
                }
            }
        }

        private void lookupMetoda(object sender, EventArgs e, PropertyInfo propertyForward)
        {
            CustomTabPage tabPage = new CustomTabPage() { State = State.Lookup, Naziv = "LOOKUP" };
            trenutnoStanje = State.Lookup;
            tabControl.TabPages.Add(tabPage);
            postaviFokus(State.Lookup);

            PropertyInfo property = propertyForward;

            var objekat = Activator.CreateInstance(Type.GetType(property.GetCustomAttribute<ForeignKey>().ReferencedTable));

            CustomDataGridView data = izgled();
            data.Tip = property.GetCustomAttribute<ForeignKey>().Tip;

            data.DataSource = vratiPodatke(property.GetCustomAttribute<ForeignKey>().Tip, null);

            data.Location = new Point(20, 20);

            data.BackgroundColor = Color.White;

            tabControl.SelectedTab.Controls.Add(data);

            data = urediGridView(data) as CustomDataGridView;

            Panel panel = new Panel();
            //panel.Location = new Point(20, 500); //ovo vratiti
            panel.Location = new Point(20, 600);
            panel.Width = 908;
            panel.Height = 160;

            Button btnVrati = new Button();
            urediButton(btnVrati, "VRATI", 70, 30, Resources.left_arrow, new Point(678, 100));

            btnVrati.Click += (send, EventArgs) => { BtnVrati_Click(send, EventArgs, property, (sender as Button).Parent, data, objekat, tabPage); };

            Button btnOdustani = new Button();
            urediButton(btnOdustani, "ODUSTANI", 96, 30, Resources.multiply, new Point(750, 100));
            btnOdustani.Click += BtnOdustaniLookup_Click;

            panel.Controls.Add(btnVrati);
            panel.Controls.Add(btnOdustani);

            tabControl.SelectedTab.Controls.Add(panel);

            lookupTab();

            data.Focus();
        }
        #endregion

        #region Lookup
        private void UCLookup_LookupClick(object sender, EventArgs e)
        {
            string name = ((sender as Button).Parent as UCLookup).ThisColumn;
            string thisTable = ((sender as Button).Parent as UCLookup).ThisTable;

            var objekat = Activator.CreateInstance(Type.GetType(thisTable));

            PropertyInfo property = objekat.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName == name).FirstOrDefault();

            lookupMetoda(sender, e, property);

        }

        private void BtnOdustaniLookup_Click(object sender, EventArgs e)
        {
            rijesiLookup();
            tabControl.TabPages.Remove(tabControl.SelectedTab);
            if (!provjeriKreiraj(State.Lookup))
            {
                postaviFokus(State.Insert);
            }
            {
                lookupTab();
            }
        }

        private void BtnVrati_Click(object sender, EventArgs e, PropertyInfo property, Control uC, DataGridView data, object objekat, CustomTabPage tabPage)
        {
            if (data.SelectedRows.Count > 0)
            {

                DataGridViewRow row = data.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells[property.GetCustomAttribute<ForeignKey>().ReferencedColumn].Value);

                object col1 = property.GetCustomAttribute<ForeignKey>().BackCol1;
                object col2 = property.GetCustomAttribute<ForeignKey>().BackCol2;

                string info = "";

                info = row.Cells[col1.ToString()].Value + " "
                            + (col2.ToString() != "" && !col2.ToString().Contains("Šifra") ? row.Cells[col2.ToString()].Value : "");

                tabControl.TabPages.Remove(tabControl.SelectedTab);
                rijesiLookup();
                if (!provjeriKreiraj(State.Lookup))
                {
                    postaviFokus(State.Insert);
                }
                {
                    lookupTab();
                }

                if (uC.GetType() == typeof(UCLookup))
                {
                    (uC as UCLookup).Value = id.ToString();
                    (uC as UCLookup).Info = info;
                }
                else
                {
                    (uC as UCLookupInsert).Value = id.ToString();
                    (uC as UCLookupInsert).Info = info;
                }

            }
            else
            {
                MessageBox.Show("Greška. Ništa niste selektovali!");
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

            foreach (DataGridViewColumn item in dgv.Columns)
            {
                if (item.HeaderText == "Pol")
                {
                    item.Width = 50;
                }
            }

            return dgv;
        }

        private CustomDataGridView izgled()
        {

            CustomDataGridView customDataGridView = new CustomDataGridView(880, 400);
            customDataGridView.SelectionChanged += DataGridView_SelectionChanged;
            customDataGridView.ContextMenuStrip = napraviContextMenyStrip();

            return customDataGridView;

        }

        private ContextMenuStrip napraviContextMenyStrip()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Opened += ContextMenuStrip_Opened;
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = "Osvježi";
            item.Image = Resources.reload__1_;
            item.Click += Osvijezi_Click;

            ToolStripSeparator tool = new ToolStripSeparator();

            ToolStripMenuItem item1 = new ToolStripMenuItem();
            item1.Text = "Ažuriraj";
            item1.Image = Resources.edit;


            ToolStripSeparator tool1 = new ToolStripSeparator();

            ToolStripMenuItem item3 = new ToolStripMenuItem();
            item3.Text = "Gore";
            item3.Image = Resources.up_arrow;
            item3.Click += CustomToolStrip_GoreClick;

            ToolStripMenuItem item4 = new ToolStripMenuItem();
            item4.Text = "Dole";
            item4.Image = Resources.angle_arrow_down;
            item4.Click += CustomToolStrip_DoleClick;

            ToolStripMenuItem item5 = new ToolStripMenuItem();
            item5.Text = "Prvi";
            item5.Image = Resources.chevron_up;
            item5.Click += CustomToolStrip_PrviClick;

            ToolStripMenuItem item6 = new ToolStripMenuItem();
            item6.Text = "Zadnji";
            item6.Image = Resources.thin_arrowheads_pointing_down;
            item6.Click += CustomToolStrip_ZadnjiClick;


            contextMenuStrip.Items.Add(item);
            contextMenuStrip.Items.Add(tool);
            contextMenuStrip.Items.Add(item1);
            contextMenuStrip.Items.Add(tool1);
            contextMenuStrip.Items.Add(item6);
            contextMenuStrip.Items.Add(item4);
            contextMenuStrip.Items.Add(item3);
            contextMenuStrip.Items.Add(item5);

            return contextMenuStrip;
        }

        private void Osvijezi_Click(object sender, EventArgs e)
        {

            CustomDataGridView customDataGridView = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as CustomDataGridView;
            customDataGridView.DataSource = vratiPodatke(customDataGridView.Tip, null);

        }

        private void ContextMenuStrip_Opened(object sender, EventArgs e)
        {
            Control control = (sender as ContextMenuStrip).SourceControl;


            CustomDataGridView dgv = control as CustomDataGridView;
            try
            {
                if (dgv.Rows.Count == 0 || dgv.Rows.Count == 1)
                {
                    (sender as ContextMenuStrip).Items[5].Enabled = false;
                    (sender as ContextMenuStrip).Items[6].Enabled = false;
                    (sender as ContextMenuStrip).Items[7].Enabled = false;
                    (sender as ContextMenuStrip).Items[8].Enabled = false;
                }
                else if (dgv.SelectedRows[0] == dgv.Rows[0])
                {
                    (sender as ContextMenuStrip).Items[5].Enabled = true;
                    (sender as ContextMenuStrip).Items[6].Enabled = true;
                    (sender as ContextMenuStrip).Items[7].Enabled = false;
                    (sender as ContextMenuStrip).Items[8].Enabled = false;

                }
                else if (dgv.SelectedRows[0] == dgv.Rows[dgv.Rows.Count - 1])
                {
                    (sender as ContextMenuStrip).Items[5].Enabled = false;
                    (sender as ContextMenuStrip).Items[6].Enabled = false;
                    (sender as ContextMenuStrip).Items[7].Enabled = true;
                    (sender as ContextMenuStrip).Items[8].Enabled = true;

                }
                else
                {
                    (sender as ContextMenuStrip).Items[5].Enabled = true;
                    (sender as ContextMenuStrip).Items[6].Enabled = true;
                    (sender as ContextMenuStrip).Items[7].Enabled = true;
                    (sender as ContextMenuStrip).Items[8].Enabled = true;

                }
            }
            catch (Exception)
            {

            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            try
            {
                if (dgv.SelectedRows[0] == dgv.Rows[0])
                {
                    CustomToolStrip.Gore = false;
                    CustomToolStrip.Prvi = false;
                    CustomToolStrip.Dole = true;
                    CustomToolStrip.Zadnji = true;

                }
                else if (dgv.SelectedRows[0] == dgv.Rows[dgv.Rows.Count - 1])
                {
                    CustomToolStrip.Gore = true;
                    CustomToolStrip.Prvi = true;
                    CustomToolStrip.Dole = false;
                    CustomToolStrip.Zadnji = false;

                }
                else
                {
                    CustomToolStrip.Gore = true;
                    CustomToolStrip.Prvi = true;
                    CustomToolStrip.Dole = true;
                    CustomToolStrip.Zadnji = true;

                }
            }
            catch (Exception)
            {


            }

        }

        #endregion

        #region UcitavanjeTabControl
        private void ucitajOrdinaciju()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));

            PanelTabControl panelTabControl = new PanelTabControl(Resources.pocetna, "POČETNA");
            panelTabControl.ControlClick += Pocetna_ControlClick;
            PanelTabControl panelTabControl3 = new PanelTabControl(Resources.rezervacija, "R. DOLAZAKA");
            panelTabControl3.ControlClick += RedoslijedDolazaka_ControlClick;
            PanelTabControl panelTabControl4 = new PanelTabControl(Resources.karton, "KARTON");
            panelTabControl4.ControlClick += Karton_ControlClick;
            PanelTabControl panelTabControl9 = new PanelTabControl(Resources.faktor_rizika, "FAKTOR RIZIKA");
            panelTabControl9.ControlClick += FaktorRizika_ControlClick;
            PanelTabControl panelTabControl5 = new PanelTabControl(Resources.pregled, "PREGLED");
            panelTabControl5.ControlClick += Pregled_ControlClick;
            Label label = new Label() { Name = "", Width = 266, Height = 1, BackColor = Color.White };
            PanelTabControl panelTabControl6 = new PanelTabControl(Resources.odjava, "ODJAVA");
            panelTabControl6.ControlClick += Odjava_ControlClick;

            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl5);
            panelGlavniTab.Controls.Add(panelTabControl9);
            panelGlavniTab.Controls.Add(panelTabControl4);
            panelGlavniTab.Controls.Add(label);
            panelGlavniTab.Controls.Add(panelTabControl6);


        }

        private void postaviPocetnu()
        {
            ucitajOsobu();
            PocetnaStrana pocetna = new PocetnaStrana(Logovan);
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

            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));
            if (Logovan.TipZaposlenog.Equals("Medicinska sestra"))
                pocetna.PostaviImage = Resources.nurse; 
            else if (Logovan.TipZaposlenog.Equals("Sistem administrator"))
                pocetna.PostaviImage = Resources.admin;
            else
            {
                foreach (PropertyOsoba item in propertyInterfaces[9])
                {
                    if (item.OsobaID.Equals(Logovan.OsobaID) && item.Pol.Equals("Ž"))
                        pocetna.PostaviImage = Resources.femaleDoctor;
                    else if (item.OsobaID.Equals(Logovan.OsobaID) && item.Pol.Equals("M"))
                        pocetna.PostaviImage = Resources.maleDoctor;
                 }
            }
        }

        private void ucitajRecepciju()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));


            PanelTabControl panelTabControl = new PanelTabControl(Resources.pocetna, "POČETNA");
            panelTabControl.ControlClick += Pocetna_ControlClick;
            PanelTabControl panelTabControl9 = new PanelTabControl(Resources.rezervacija, "REZERVACIJA");
            panelTabControl9.ControlClick += Rezervacija_ControlClick;
            PanelTabControl panelTabControl1 = new PanelTabControl(Resources.recepcija2, "RECEPCIJA");
            panelTabControl1.ControlClick += Recepcija_ControlClick;
            PanelTabControl panelTabControl3 = new PanelTabControl(Resources.pacijent, "PACIJENT");
            panelTabControl3.ControlClick += Pacijent_ControlClick;
            PanelTabControl panelTabControl2 = new PanelTabControl(Resources.racun, "RAČUN");
            panelTabControl2.ControlClick += Racun_ControlClick;
            Label label = new Label() { Name = "", Width = 266, Height = 1, BackColor = Color.White };
            PanelTabControl panelTabControl6 = new PanelTabControl(Resources.odjava, "ODJAVA");
            panelTabControl6.ControlClick += Odjava_ControlClick;

            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl9);
            panelGlavniTab.Controls.Add(panelTabControl1);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl2);
            panelGlavniTab.Controls.Add(label);
            panelGlavniTab.Controls.Add(panelTabControl6);
        }

        private void ucitajKancelariju()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlavnaForma));

            PanelTabControl panelTabControl = new PanelTabControl(Resources.pocetna, "POČETNA");
            panelTabControl.ControlClick += Pocetna_ControlClick;
            PanelTabControl panelTabControl1 = new PanelTabControl(Resources.zaposleni, "ZAPOSLENI");
            panelTabControl1.ControlClick += Zaposleni_ControlClick;
            PanelTabControl panelTabControl3 = new PanelTabControl(Resources.pacijent, "PACIJENT");
            panelTabControl3.ControlClick += Pacijent_ControlClick;
            PanelTabControl panelTabControl4 = new PanelTabControl(Resources.cjenovnik, "CJENOVNIK");
            panelTabControl4.ControlClick += Cjenovnik_ControlClick;
            PanelTabControl panelTabControl2 = new PanelTabControl(Resources.racun, "RAČUN");
            panelTabControl2.ControlClick += Racun_ControlClick;
            PanelTabControl panelTabControl10 = new PanelTabControl(Resources.izvjestaj, "IZVJEŠTAJ");
            panelTabControl10.ControlClick += Izvjestaj_ControlClick;
            Label label = new Label() { Name = "", Width = 266, Height = 1, BackColor = Color.White };
            PanelTabControl panelTabControl6 = new PanelTabControl(Resources.odjava, "ODJAVA");
            panelTabControl6.ControlClick += Odjava_ControlClick;

            panelGlavniTab.Controls.Add(panelTabControl);
            panelGlavniTab.Controls.Add(panelTabControl1);
            panelGlavniTab.Controls.Add(panelTabControl3);
            panelGlavniTab.Controls.Add(panelTabControl4);
            panelGlavniTab.Controls.Add(panelTabControl2);
            panelGlavniTab.Controls.Add(panelTabControl10);
            panelGlavniTab.Controls.Add(label);
            panelGlavniTab.Controls.Add(panelTabControl6);


        }

        #endregion

        private void postaviFokus(State stanje)
        {

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if ((tabControl.TabPages[i] as CustomTabPage).State == stanje)
                {
                    tabControl.TabPages[i].Focus();
                    tabControl.SelectedIndex = i;
                }
            }

        }

        #region ControlClickMetode

        private void Izvjestaj_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("IZVJEŠTAJ");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "IZVJEŠTAJ" };
            tabControl.Controls.Add(tabPage);
            postaviFokus(State.Main);
            myProperty = null;
            kreirajIzvjestaj();
        }

        private void Pocetna_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("POČETNA");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "POČETNA" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Pocetna;
            postaviFokus(State.Main);
            myProperty = null;
            postaviPocetnu();
        }

        private void Cjenovnik_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("CJENOVNIK");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "CJENOVNIK" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Cjenovnik;
            postaviFokus(State.Main);
            myProperty = new PropertyCjenovnik();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Zaposleni_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("ZAPOSLENI");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "ZAPOSLENI" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Zaposleni;
            postaviFokus(State.Main);
            myProperty = new PropertyZaposleni();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void RedoslijedDolazaka_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("R. DOLAZAKA");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "R. DOLAZAKA" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.RedoslijedDolazaka;
            postaviFokus(State.Main);
            myProperty = new PropertyPacijent();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
            CustomToolStrip.Dodaj = false;
            CustomToolStrip.Azuriraj = false;
        }

        private void Rezervacija_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("REZERVACIJA");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "REZERVACIJA" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Rezervacija;
            postaviFokus(State.Main);
            myProperty = new PropertyRezervacije();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Karton_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("KARTON");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "KARTON" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Karton;
            postaviFokus(State.Main);
            myProperty = new PropertyKarton();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void FaktorRizika_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("FAKTOR RIZIKA");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "FAKTOR RIZIKA" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.FaktorRizika;
            postaviFokus(State.Main);
            myProperty = new PropertyFaktorRizikaKarton();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }


        private void Pregled_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("PREGLED");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "PREGLED" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Pregled;
            postaviFokus(State.Main);
            myProperty = new PropertyPregled();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Odjava_ControlClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li želite napustiti program?", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void Recepcija_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("RECEPCIJA");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "RECEPCIJA" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Recepcija;
            postaviFokus(State.Main);
            myProperty = new PropertyRecepcija();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Pacijent_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("PACIJENT");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "PACIJENT" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Pacijent;
            postaviFokus(State.Main);
            myProperty = new PropertyPacijent();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
        }

        private void Racun_ControlClick(object sender, EventArgs e)
        {
            zatvoriSve();
            rijesiSelekt("RAČUN");
            CustomTabPage tabPage = new CustomTabPage() { State = State.Main, Naziv = "RAČUN" };
            tabControl.Controls.Add(tabPage);
            Tip = Tip.Racun;
            postaviFokus(State.Main);
            myProperty = new PropertyDetaljiRacuna();
            kreirajToolStrip();
            dodajPoljaZaPretragu();
            kreirajTabove();
            if (Logovan.RadnoMjesto == "Kancelarija")
            {
                CustomToolStrip.Dodaj = false;
            }
        }
        #endregion

        private void zatvoriSve()
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
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
            foreach (CustomTabPage tabPage in tabControl.TabPages)
            {
                if (tabPage.State == State.Lookup) return true;
            }
            return false;
        }

        private bool provjeriKreiraj(State state)
        {
            for (int i = tabControl.TabPages.Count - 1; i >= 0; i--)
            {
                if ((tabControl.TabPages[i] as CustomTabPage).State == state)
                {
                    tabControl.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void rijesiSelekt(string trazen)
        {
            foreach (var item in panelGlavniTab.Controls)
            {
                if (item.GetType() == typeof(PanelTabControl))
                {
                    if ((item as PanelTabControl).Naziv != trazen)
                    {
                        (item as PanelTabControl).Selektovan = false;
                        (item as PanelTabControl).SelektovanIkona = null;
                    }
                    else
                    {
                        (item as PanelTabControl).Selektovan = true;
                        (item as PanelTabControl).SelektovanIkona = Resources.play_button;
                    }
                }
            }
        }

        private CustomDataGridView urediGridView(CustomDataGridView data)
        {
            foreach (DataGridViewColumn column in data.Columns)
            {
                if (column.Name.EndsWith("_hide"))
                {
                    column.Name = column.Name.Replace("_hide", "");
                    column.HeaderText = column.HeaderText.Replace("_hide", "");
                    column.Visible = false;
                }
                column.Name = column.Name.Replace('_', ' ');
                column.HeaderText = column.HeaderText.Replace('_', ' ');
                if (column.HeaderText == "Pol")
                {
                    column.Width = 35;
                }

                if (column.HeaderText == "Osiguran")
                {
                    column.Width = 40;
                }
            }
            return data;
        }

        private DataTable urediDataTable(DataTable data)
        {
            foreach (DataColumn column in data.Columns)
            {
                if (column.ColumnName.EndsWith("_hide"))
                {
                    column.ColumnName = column.ColumnName.Replace("_hide", "");
                }
                column.ColumnName = column.ColumnName.Replace('_', ' ');
            }
            return data;
        }

        #region Podaci
        private DataTable vratiPodatke(Tip tip, int? id)
        {

            DataTable dataTable = null;
            switch (tip)
            {
                case Tip.Karton:
                    ucitaj(7);
                    ucitaj(1);
                    ucitaj(9);
                    ucitaj(0);

                    var query = (
                                    from p in (propertyInterfaces[7].Cast<PropertyKarton>())
                                    join pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                     on p.PacijentID equals pacijent.PacijentID
                                    join osoba in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                     on pacijent.OsobaID equals osoba.OsobaID
                                    join doktor in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                     on pacijent.DoktorID equals doktor.ZaposleniID
                                    join osoba1 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                     on doktor.OsobaID equals osoba1.OsobaID
                                    where p.KartonID == id || id == null
                                    select new
                                    {
                                        Broj_kartona = p.KartonID,
                                        Ime = osoba.Ime,
                                        Prezime = osoba.Prezime,
                                        JMB = osoba.JMB,
                                        Pol = osoba.Pol,
                                        Datum_rodjenja = osoba.DatumRodjenja,
                                        Ime_i_prezime_doktora = (osoba1.Ime + " " + osoba1.Prezime),
                                        Šifra_pacijenta_hide = p.PacijentID
                                    }
                                );


                    dataTable = ListToDataTable.ToDataTable(query.ToList());

                    break;
                case Tip.Pacijent:
                    ucitaj(1);
                    ucitaj(9);
                    var queryPacijent = (
                                        from p in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                        join osoba in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                        on p.OsobaID equals osoba.OsobaID
                                        select new
                                        {
                                            Ime = osoba.Ime,
                                            Prezime = osoba.Prezime,
                                            JMB = osoba.JMB,
                                            osoba.Pol,
                                            Mjesto_rodjenja = osoba.MjestoRodjenja,
                                            Datum_rodjenja = osoba.DatumRodjenja,
                                            Adresa = osoba.Adresa,
                                            osoba.Kontakt,
                                            Osiguran = p.Osiguran,
                                            Životni_status_hide = osoba.ZivotniStatus,
                                            Šifra_pacijenta_hide = p.PacijentID,
                                            Šifra_doktora_hide = p.DoktorID,
                                            Šifra_osobe_hide = p.OsobaID
                                        }
                                        );

                    dataTable = ListToDataTable.ToDataTable(queryPacijent.ToList());


                    break;
                case Tip.Zaposleni:
                    ucitaj(0);
                    ucitaj(9);
                    var queryZaposleni = (
                                        from p in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                        join osoba in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                        on p.OsobaID equals osoba.OsobaID
                                        select new
                                        {
                                            Ime = osoba.Ime,
                                            Prezime = osoba.Prezime,
                                            JMB = osoba.JMB,
                                            p.Zvanje,
                                            osoba.Pol,
                                            Mjesto_rodjenja = osoba.MjestoRodjenja,
                                            Datum_rodjenja = osoba.DatumRodjenja,
                                            Adresa = osoba.Adresa,
                                            Šifra_zaposlenog_hide = p.ZaposleniID,
                                            Tip_Zaposlenog_hide = p.TipZaposlenog,
                                            Radno_mjesto_hide = p.RadnoMjesto,
                                            Korisničko_ime_hide = p.KorisnickoIme,
                                            Password_hide = p.Password,
                                            Šifra_osobe_hide = p.OsobaID
                                        }
                                        );

                    dataTable = ListToDataTable.ToDataTable(queryZaposleni.ToList());

                    break;
                case Tip.Recepcija:
                    ucitaj(12);
                    ucitaj(0);
                    ucitaj(9);
                    ucitaj(1);
                    var queryRecepcija = (
                                            from recepcija in (propertyInterfaces[12].Cast<PropertyRecepcija>())
                                            join prijem in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                            on recepcija.DoktorID equals prijem.ZaposleniID
                                            join osoba1 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on prijem.OsobaID equals osoba1.OsobaID
                                            join pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                            on recepcija.PacijentID equals pacijent.PacijentID
                                            join osoba2 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on pacijent.OsobaID equals osoba2.OsobaID
                                            select new
                                            {
                                                Ime_i_prezime_pacijenta = (osoba2.Ime + " " + osoba2.Prezime),
                                                Ime_i_prezime_doktora = (osoba1.Ime + " " + osoba1.Prezime),
                                                Vrijeme_prijema = recepcija.VrijemePrijema,
                                                Vrijeme_otpusta = recepcija.VrijemeOtpusta,
                                                Prioritet_hide = recepcija.Prioritet,
                                                Šifra_prijema_hide = recepcija.PrijemID,
                                                Šifra_prijem_zaposlenih_hide = recepcija.PrijemZaposleniID,
                                                Šifra_doktora_hide = recepcija.DoktorID,
                                                Šifra_pacijenta_hide = recepcija.PacijentID
                                            }
                                         );

                    dataTable = ListToDataTable.ToDataTable(queryRecepcija.ToList());

                    break;
                case Tip.Pregled:
                    ucitaj(10);
                    ucitaj(7);
                    ucitaj(1);
                    ucitaj(0);
                    ucitaj(9);
                    ucitaj(4);
                    var queryPregled = (
                                        from pregled in (propertyInterfaces[10].Cast<PropertyPregled>())
                                        join karton in (propertyInterfaces[7].Cast<PropertyKarton>())
                                        on pregled.PacijentID equals karton.PacijentID
                                        join pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                        on karton.PacijentID equals pacijent.PacijentID
                                        join osoba2 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                        on pacijent.OsobaID equals osoba2.OsobaID
                                        join prijem in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                        on pregled.DoktorID equals prijem.ZaposleniID
                                        join osoba1 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                        on prijem.OsobaID equals osoba1.OsobaID
                                        join dijagnoza in (propertyInterfaces[4].Cast<PropertyDijagnoza>())
                                        on pregled.DijagnozaID equals dijagnoza.DijagnozaID
                                        where karton.KartonID == id || id == null
                                        select new
                                        {
                                            Šifra_pregleda = pregled.PregledID,
                                            Ime_i_prezime_pacijenta = (osoba2.Ime + " " + osoba2.Prezime),
                                            Ime_i_prezime_doktora = (osoba1.Ime + " " + osoba1.Prezime),
                                            dijagnoza.Opis,
                                            dijagnoza.Terapija,
                                            Broj_kartona = karton.KartonID,
                                            Šifra_pregleda_hide = pregled.PregledID,
                                            Šifra_doktora_hide = pregled.DoktorID,
                                            Šifra_pacijenta_hide = pregled.PacijentID,
                                            Šifra_dijagnoze_hide = pregled.DijagnozaID,
                                            Ime_hide = osoba2.Ime,
                                            Prezime_hide = osoba2.Prezime
                                        }
                                       );

                    dataTable = ListToDataTable.ToDataTable(queryPregled.ToList());

                    break;
                case Tip.Racun:
                    ucitaj(11);
                    ucitaj(1);
                    ucitaj(0);
                    ucitaj(9);
                    ucitaj(3);
                    ucitaj(2);
                    var queryRacun = (
                                        from detalji in (propertyInterfaces[3].Cast<PropertyDetaljiRacuna>())
                                        join racun in (propertyInterfaces[11].Cast<PropertyRacun>())
                                        on detalji.RacunID equals racun.RacunID
                                        join cjenovnik in (propertyInterfaces[2].Cast<PropertyCjenovnik>())
                                        on detalji.CijenaID equals cjenovnik.CjenovnikID
                                        join pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                       on racun.PacijentID equals pacijent.PacijentID
                                        join osoba2 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on pacijent.OsobaID equals osoba2.OsobaID
                                        join prijem in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                        on racun.ZaposleniID equals prijem.ZaposleniID
                                        join osoba1 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on prijem.OsobaID equals osoba1.OsobaID
                                        select new
                                        {
                                            Broj_računa = racun.RacunID,
                                            Ime_i_prezime_pacijenta = (osoba2.Ime + " " + osoba2.Prezime),
                                            Izdao = (osoba1.Ime + " " + osoba1.Prezime),
                                            Suma_računa = racun.SumaRacuna,
                                            Datum_i_vrijeme_izdavanja = racun.VrijemeIzdavanja,
                                            Šifra_zaposlenog_hide = racun.ZaposleniID,
                                            Šifra_pacijenta_hide = racun.PacijentID,
                                            Popust_hide = racun.Popust,
                                            Šifra_cjenovnika_hide = cjenovnik.CjenovnikID,
                                            Naziv_usluge_hide = cjenovnik.NazivUsluge,
                                            Količina_hide = detalji.Kolicina,
                                            Suma_linije_hide = detalji.SumaLinije,
                                            Šifra_detalji_računa_hide = detalji.DetaljiRacunaID
                                        }
                                     );

                    dataTable = ListToDataTable.ToDataTable(queryRacun.ToList());

                    break;
                case Tip.RedoslijedDolazaka:
                    ucitaj(12);
                    ucitaj(0);
                    ucitaj(9);
                    ucitaj(1);
                    var queryRedoslijedDolazaka = (
                                            from recepcija in (propertyInterfaces[12].Cast<PropertyRecepcija>())
                                            join prijem in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                            on recepcija.DoktorID equals prijem.ZaposleniID
                                            join osoba1 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on prijem.OsobaID equals osoba1.OsobaID
                                            join pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                            on recepcija.PacijentID equals pacijent.PacijentID
                                            join osoba2 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on pacijent.OsobaID equals osoba2.OsobaID
                                            where osoba1.OsobaID == Logovan.OsobaID
                                            select new
                                            {
                                                osoba2.Ime
                                                ,
                                                osoba2.Prezime
                                                ,
                                                osoba2.JMB
                                                ,
                                                Vrijeme_prijema = recepcija.VrijemePrijema
                                                ,
                                                Vrijeme_otpusta = recepcija.VrijemeOtpusta
                                                ,
                                                Šifra_prijem_zaposleni_hide = recepcija.PrijemZaposleniID
                                                ,
                                                Šifra_doktor_hide = recepcija.DoktorID
                                                ,
                                                Šifra_pacijent_hide = recepcija.PacijentID
                                            }
                                         );

                    dataTable = ListToDataTable.ToDataTable(queryRedoslijedDolazaka.ToList());

                    break;
                case Tip.Cjenovnik:
                    ucitaj(2);
                    var queryCjenovnik = (
                                            from cjenovnik in (propertyInterfaces[2].Cast<PropertyCjenovnik>())
                                            where cjenovnik.Aktivno == 1
                                            select new { Naziv_usluge = cjenovnik.NazivUsluge, Cijena_usluge = cjenovnik.CijenaUsluge, Šifra_cjenovnika_hide = cjenovnik.CjenovnikID, Datum_uspostavljanja_cijene_hide = cjenovnik.DatumUspostavljanjaCijene, Aktivno_hide = cjenovnik.Aktivno }
                                         );
                    dataTable = ListToDataTable.ToDataTable(queryCjenovnik.ToList());

                    break;
                case Tip.CjenovnikZaSve:
                    ucitaj(2);
                    var queryCjenovnikZaSve = (
                                            from cjenovnik in (propertyInterfaces[2].Cast<PropertyCjenovnik>())
                                            select new { Naziv_usluge = cjenovnik.NazivUsluge, Cijena_usluge = cjenovnik.CijenaUsluge, Šifra_cjenovnika_hide = cjenovnik.CjenovnikID, Datum_uspostavljanja_cijene_hide = cjenovnik.DatumUspostavljanjaCijene, Aktivno_hide = cjenovnik.Aktivno }
                                         );
                    dataTable = ListToDataTable.ToDataTable(queryCjenovnikZaSve.ToList());

                    break;
                case Tip.MedicinskaSestra:
                    ucitaj(0);
                    ucitaj(9);
                    var queryMedicinskaSestra = (
                                        from p in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                        join osoba in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                        on p.OsobaID equals osoba.OsobaID
                                        where p.RadnoMjesto == "Recepcija"
                                        select new
                                        {
                                            Ime = osoba.Ime,
                                            Prezime = osoba.Prezime,
                                            JMB = osoba.JMB,
                                            p.Zvanje,
                                            osoba.Pol,
                                            Mjesto_rodjenja = osoba.MjestoRodjenja,
                                            Datum_rodjenja = osoba.DatumRodjenja,
                                            Adresa = osoba.Adresa,
                                            Šifra_zaposlenog_hide = p.ZaposleniID,
                                            Šifra_vrste_posla_hide = p.TipZaposlenog,
                                        }
                                        );
                    dataTable = ListToDataTable.ToDataTable(queryMedicinskaSestra.ToList());

                    break;
                case Tip.Doktori:
                    ucitaj(0);
                    ucitaj(9);
                    var queryDoktori = (
                                        from p in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                        join osoba in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                        on p.OsobaID equals osoba.OsobaID
                                        where p.Zvanje == "dr"
                                        select new
                                        {
                                            Ime = osoba.Ime,
                                            Prezime = osoba.Prezime,
                                            JMB = osoba.JMB,
                                            p.Zvanje,
                                            osoba.Pol,
                                            Mjesto_rodjenja = osoba.MjestoRodjenja,
                                            Datum_rodjenja = osoba.DatumRodjenja,
                                            Adresa = osoba.Adresa,
                                            Šifra_doktora_hide = p.ZaposleniID,
                                            Šifra_vrsta_posla_hide = p.TipZaposlenog
                                        }
                                        );

                    dataTable = ListToDataTable.ToDataTable(queryDoktori.ToList());

                    break;
                case Tip.MSD:
                    ucitaj(0);
                    ucitaj(9);
                    var queryMSD = (
                                        from p in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                        join osoba in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                        on p.OsobaID equals osoba.OsobaID
                                        where p.RadnoMjesto == "Recepcija" || p.RadnoMjesto == "Kancelarija"
                                        select new
                                        {
                                            Ime = osoba.Ime,
                                            Prezime = osoba.Prezime,
                                            JMB = osoba.JMB,
                                            p.Zvanje,
                                            osoba.Pol,
                                            Mjesto_rodjenja = osoba.MjestoRodjenja,
                                            Datum_rodjenja = osoba.DatumRodjenja,
                                            Adresa = osoba.Adresa,
                                            Šifra_zaposlenog_hide = p.ZaposleniID,
                                            Šifra_vrsta_posla_hide = p.TipZaposlenog
                                        }
                                        );

                    dataTable = ListToDataTable.ToDataTable(queryMSD.ToList());

                    break;
                case Tip.Osoba:
                    ucitaj(9);
                    ucitaj(1);

                    var queryOsobaNijePacijent = (
                                                        from o in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                                        where !(from pacijent in propertyInterfaces[1].Cast<PropertyPacijent>()
                                                                select pacijent.OsobaID).Contains(o.OsobaID)
                                                        select new
                                                        {
                                                            o.Ime
                                                            ,
                                                            o.Prezime
                                                            ,
                                                            o.JMB
                                                            ,
                                                            o.Pol
                                                            ,
                                                            Mjesto_rodjenja = o.MjestoRodjenja
                                                            ,
                                                            Datum_rodjenja = o.DatumRodjenja
                                                            ,
                                                            o.Adresa
                                                            ,
                                                            o.Kontakt
                                                            ,
                                                            Šifra_osobe_hide = o.OsobaID
                                                        }
                                                 );

                    dataTable = ListToDataTable.ToDataTable(queryOsobaNijePacijent.ToList());

                    break;
                case Tip.Dijagnoze:
                    ucitaj(4);

                    var queryDijagnoza = (
                                                from dijagnoza in (propertyInterfaces[4].Cast<PropertyDijagnoza>())
                                                select new
                                                {
                                                    dijagnoza.Opis
                                                    ,
                                                    dijagnoza.Terapija
                                                    ,
                                                    Šifra_dijagnoze_hide = dijagnoza.DijagnozaID
                                                }
                                         );
                    dataTable = ListToDataTable.ToDataTable(queryDijagnoza.ToList());

                    break;
                case Tip.OsobaBezPosla:
                    ucitaj(9);
                    ucitaj(0);

                    var queryOsobaNijeZaposlena = (
                                                        from o in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                                        where !(from zaposleni in propertyInterfaces[0].Cast<PropertyZaposleni>()
                                                                select zaposleni.OsobaID).Contains(o.OsobaID)
                                                        select new
                                                        {
                                                            o.Ime
                                                            ,
                                                            o.Prezime
                                                            ,
                                                            o.JMB
                                                            ,
                                                            o.Pol
                                                            ,
                                                            Mjesto_rodjenja = o.MjestoRodjenja
                                                            ,
                                                            Datum_rodjenja = o.DatumRodjenja
                                                            ,
                                                            o.Adresa
                                                            ,
                                                            o.Kontakt
                                                            ,
                                                            Šifra_osobe_hide = o.OsobaID
                                                        }
                                                 );

                    dataTable = ListToDataTable.ToDataTable(queryOsobaNijeZaposlena.ToList());

                    break;
                case Tip.SveOsobe:
                    ucitaj(9);

                    var qurySvi = (
                                                        from o in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                                        where o.OsobaID == id || id == null
                                                        select new
                                                        {
                                                            o.Ime
                                                            ,
                                                            o.Prezime
                                                            ,
                                                            o.JMB
                                                            ,
                                                            o.Pol
                                                            ,
                                                            Mjesto_rodjenja = o.MjestoRodjenja
                                                            ,
                                                            Datum_rodjenja = o.DatumRodjenja
                                                            ,
                                                            o.Adresa
                                                            ,
                                                            o.Kontakt
                                                            ,
                                                            Šifra_osobe_hide = o.OsobaID
                                                        }
                                                 );

                    dataTable = ListToDataTable.ToDataTable(qurySvi.ToList());
                    break;
                case Tip.NoviRacun:
                    ucitaj(11);
                    ucitaj(1);
                    ucitaj(0);
                    ucitaj(9);
                    ucitaj(3);
                    var queryNoviRacun = (
                                        from racun in (propertyInterfaces[11].Cast<PropertyRacun>())
                                        join pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                       on racun.PacijentID equals pacijent.PacijentID
                                        join osoba2 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on pacijent.OsobaID equals osoba2.OsobaID
                                        join prijem in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                        on racun.ZaposleniID equals prijem.ZaposleniID
                                        join osoba1 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on prijem.OsobaID equals osoba1.OsobaID
                                        where !(from detalji in propertyInterfaces[3].Cast<PropertyDetaljiRacuna>()
                                                select detalji.RacunID).Contains(racun.RacunID)
                                        select new
                                        {
                                            Broj_računa = racun.RacunID,
                                            Ime_i_prezime_pacijenta = (osoba2.Ime + " " + osoba2.Prezime),
                                            Ime_i_prezime_doktora = (osoba1.Ime + " " + osoba1.Prezime),
                                            Suma_računa = racun.SumaRacuna,
                                            Datum_i_vrijeme_izdavanja = racun.VrijemeIzdavanja,
                                            Šifra_zaposlenog_hide = racun.ZaposleniID,
                                            Šifra_pacijenta_hide = racun.PacijentID,
                                            Popust_hide = racun.Popust,
                                        }
                                     );

                    dataTable = ListToDataTable.ToDataTable(queryNoviRacun.ToList());

                    break;
                case Tip.Rezervacija:
                    ucitaj(0);
                    ucitaj(9);
                    ucitaj(1);
                    ucitaj(13);
                    var queryRezervacija = (
                                            from rezervacija in (propertyInterfaces[13].Cast<PropertyRezervacije>())
                                            join prijem in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                            on rezervacija.DoktorID equals prijem.ZaposleniID
                                            join osoba1 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on prijem.OsobaID equals osoba1.OsobaID
                                            join pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                            on rezervacija.PacijentID equals pacijent.PacijentID
                                            join osoba2 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on pacijent.OsobaID equals osoba2.OsobaID
                                            select new
                                            {
                                                Ime_i_prezime_pacijenta = (osoba2.Ime + " " + osoba2.Prezime),
                                                Ime_i_prezime_doktora = (osoba1.Ime + " " + osoba1.Prezime),
                                                Termin = rezervacija.Termin,
                                                Vrijeme_reervacije = rezervacija.VrijemeRezervacije,
                                                Šifra_doktora_hide = rezervacija.DoktorID,
                                                Šifra_pacijenta_hide = rezervacija.PacijentID,
                                                Šifra_rezervacije_hide = rezervacija.RezervacijaID
                                            }

                                         );

                    dataTable = ListToDataTable.ToDataTable(queryRezervacija.ToList());

                    break;
                case Tip.FaktorRizika:
                    ucitaj(6);
                    ucitaj(7);
                    ucitaj(5);
                    ucitaj(1);
                    ucitaj(9);
                    var queryFaktorRizika = (
                                            from frk in (propertyInterfaces[6].Cast<PropertyFaktorRizikaKarton>())
                                            join karton in (propertyInterfaces[7].Cast<PropertyKarton>())
                                            on frk.KartonID equals karton.PacijentID
                                            join pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                            on karton.PacijentID equals pacijent.PacijentID
                                            join osoba in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                            on pacijent.OsobaID equals osoba.OsobaID
                                            join fr in (propertyInterfaces[5].Cast<PropertyFaktorRizika>())
                                            on frk.FaktorRizikaID equals fr.FaktorRizikaID
                                            where karton.KartonID == id || id == null
                                            select new
                                            {
                                                Broj_kartona = karton.KartonID,
                                                Ime_i_prezime_pacijenta = (osoba.Ime + " " + osoba.Prezime),
                                                Naziv_rizika = fr.NazivRizika,
                                                Opis = fr.Opis,
                                                Šifra_pacijenta_hide = pacijent.PacijentID,
                                                Šifra_doktora_hide = pacijent.DoktorID,
                                                Šifra_osobe_hide = pacijent.OsobaID,
                                                Šifra_faktor_rizika_hide = fr.FaktorRizikaID,
                                                Šifra_faktor_rizika_karton_hide = frk.FRKID
                                            }
                                            );
                    dataTable = ListToDataTable.ToDataTable(queryFaktorRizika.ToList());

                    break;
                case Tip.KartonNema:
                    ucitaj(7);
                    ucitaj(1);
                    ucitaj(9);
                    ucitaj(0);

                    var queryKartonNema = (
                                    from pacijent in (propertyInterfaces[1].Cast<PropertyPacijent>())
                                    join osoba in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                     on pacijent.OsobaID equals osoba.OsobaID
                                    join doktor in (propertyInterfaces[0].Cast<PropertyZaposleni>())
                                     on pacijent.DoktorID equals doktor.ZaposleniID
                                    join osoba1 in (propertyInterfaces[9].Cast<PropertyOsoba>())
                                     on doktor.OsobaID equals osoba1.OsobaID
                                    where !(from karton in propertyInterfaces[7].Cast<PropertyKarton>()
                                            select karton.PacijentID).Contains(pacijent.PacijentID)
                                    select new
                                    {
                                        Ime = osoba.Ime,
                                        Prezime = osoba.Prezime,
                                        JMB = osoba.JMB,
                                        Pol = osoba.Pol,
                                        Datum_rodjenja = osoba.DatumRodjenja,
                                        Ime_i_prezime_doktora = (osoba1.Ime + " " + osoba1.Prezime),
                                        Šifra_pacijenta_hide = pacijent.PacijentID,
                                    }
                                );


                    dataTable = ListToDataTable.ToDataTable(queryKartonNema.ToList());

                    break;
                case Tip.Rizici:
                    ucitaj(5);
                    var queryRizic = (
                                            from fr in (propertyInterfaces[5].Cast<PropertyFaktorRizika>())
                                            select new
                                            {
                                                Naziv_rizika = fr.NazivRizika,
                                                Opis = fr.Opis,
                                                Šifra_faktor_rizika_hide = fr.FaktorRizikaID
                                            }
                                            );
                    dataTable = ListToDataTable.ToDataTable(queryRizic.ToList());

                    break;

            }

            return dataTable;
        }
        #endregion

    }
}

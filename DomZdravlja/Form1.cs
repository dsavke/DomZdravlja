using DomZdravlja.PropertyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomZdravlja.Helpers;

namespace DomZdravlja
{
    public partial class Form1 : Form
    {

        #region Liste

        List<PropertyZaposleni> listaZaposlenih = new List<PropertyZaposleni>();
        List<PropertyPacijent> listaPacijenata = new List<PropertyPacijent>();
        List<PropertyCjenovnik> listaCijena = new List<PropertyCjenovnik>();
        List<PropertyDetaljiRacuna> listaDetaljaRacuna = new List<PropertyDetaljiRacuna>();
        List<PropertyDijagnoza> listaDijagnoza = new List<PropertyDijagnoza>();
        List<PropertyFaktorRizika> listaFaktorRizika = new List<PropertyFaktorRizika>();
        List<PropertyFaktorRizikaKarton> listaFaktorRizikaKarton = new List<PropertyFaktorRizikaKarton>();
        List<PropertyKarton> listaKartona = new List<PropertyKarton>();
        List<PropertyKartonDijagnoza> listaKartonDijagnoza = new List<PropertyKartonDijagnoza>();
        List<PropertyOsoba> listaOsoba = new List<PropertyOsoba>();
        List<PropertyPregled> listaPregleda = new List<PropertyPregled>();
        List<PropertyRacun> listaRacuna = new List<PropertyRacun>();
        List<PropertyRecepcija> listaRecepcija = new List<PropertyRecepcija>();
        List<PropertyRezervacije> listaRezervacija= new List<PropertyRezervacije>();

        #endregion


        public Form1()
        {

            InitializeComponent();
            ucitajZaposlene();

        }

        private void ucitajZaposlene()
        {
            PropertyZaposleni zaposleni = new PropertyZaposleni();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, zaposleni.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyZaposleni pomZaposleni = new PropertyZaposleni();
                pomZaposleni.ZaposleniID = (int)dataReader["ZaposleniID"];
                pomZaposleni.Zvanje = (string)dataReader["Zvanje"];
                pomZaposleni.RadnoMjesto = (string)dataReader["RadnoMjesto"];
                pomZaposleni.KorisnickoIme = (string)dataReader["KorisnickoIme"];
                pomZaposleni.Password = (string)dataReader["Password"];
                pomZaposleni.TipZaposlenog = (string)dataReader["TipZaposlenog"];
                pomZaposleni.OsobaID = (int)dataReader["OsobaID"];
                listaZaposlenih.Add(pomZaposleni);
            }
        }

        private void ucitajPacijente()
        {
            PropertyPacijent pacijenti = new PropertyPacijent();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, pacijenti.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyPacijent pomPacijenti = new PropertyPacijent();
                pomPacijenti.PacijentID = (int)dataReader["PacijentID"];
                pomPacijenti.DoktorID = (int)dataReader["DoktorID"];
                pomPacijenti.OsobaID = (int)dataReader["OsobaID"];
                pomPacijenti.BrojKartona = (int)dataReader["BrojKartona"];
                pomPacijenti.Osiguran = (int)dataReader["Osiguran"];
                listaPacijenata.Add(pomPacijenti);
            }
        }

        private void ucitajCijenu()
        {
            PropertyCjenovnik cijena = new PropertyCjenovnik();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, cijena.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyCjenovnik pomCijena = new PropertyCjenovnik();
                pomCijena.CjenovnikID = (int)dataReader["CjenovnikID"];
                pomCijena.NazivUsluge = (string)dataReader["NazivUsluge"];
                pomCijena.CijenaUsluge = (decimal)dataReader["CijenaUsluge"];
                pomCijena.DatumUspostavljanjaCijene = (DateTime)dataReader["DatumUspostavljanjaCijene"];
                listaCijena.Add(pomCijena);
            }
        }

        private void ucitajDetaljeRacuna()
        {
            PropertyDetaljiRacuna detaljiRacuna = new PropertyDetaljiRacuna();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, detaljiRacuna.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyDetaljiRacuna pomDetaljiRacuna = new PropertyDetaljiRacuna();
                pomDetaljiRacuna.DetaljiRacunaID = (int)dataReader["DetaljiRacunaID"];
                pomDetaljiRacuna.RacunID = (int)dataReader["RacunID"];
                pomDetaljiRacuna.CijenaID = (int)dataReader["CijenaID"];
                pomDetaljiRacuna.Kolicina = (int)dataReader["Kolicina"];
                listaDetaljaRacuna.Add(pomDetaljiRacuna);
            }
        }

        private void ucitajDijagnozu()
        {
            PropertyDijagnoza dijagnoza = new PropertyDijagnoza();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, dijagnoza.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyDijagnoza pomDijagnoza = new PropertyDijagnoza();
                pomDijagnoza.DijagnozaID = (int)dataReader["DijagnozaID"];
                pomDijagnoza.PacijentID = (int)dataReader["PacijentID"];
                pomDijagnoza.DoktorID = (int)dataReader["DoktorID"];
                pomDijagnoza.Terapija = (string)dataReader["Terapija"];
                pomDijagnoza.Opis = (string)dataReader["Opis"];
                listaDijagnoza.Add(pomDijagnoza);
            }
        }

        private void ucitajFaktorRizika()
        {
            PropertyFaktorRizika faktorRizika = new PropertyFaktorRizika();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, faktorRizika.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyFaktorRizika pomFaktorRizika = new PropertyFaktorRizika();
                pomFaktorRizika.FaktorRizikaID = (int)dataReader["FaktorRizikaID"];
                pomFaktorRizika.NazivRizika = (string)dataReader["NazivRizika"];
                pomFaktorRizika.Opis = (string)dataReader["Opis"];
                listaFaktorRizika.Add(pomFaktorRizika);
            }
        }

        private void ucitajFaktorRizikaKarton()
        {
            PropertyFaktorRizikaKarton faktorRizikaKarton = new PropertyFaktorRizikaKarton();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, faktorRizikaKarton.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyFaktorRizikaKarton pomFaktorRizikaKarton = new PropertyFaktorRizikaKarton();
                pomFaktorRizikaKarton.FRKID = (int)dataReader["FRKID"];
                pomFaktorRizikaKarton.FaktorRizikaID = (int)dataReader["FaktorRizikaID"];
                pomFaktorRizikaKarton.KartonID = (int)dataReader["KartonID"];
                listaFaktorRizikaKarton.Add(pomFaktorRizikaKarton);
            }
        }

        private void ucitajKarton()
        {
            PropertyKarton karton = new PropertyKarton();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, karton.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyKarton pomKarton = new PropertyKarton();
                pomKarton.PacijentID = (int)dataReader["PacijentID"];
                pomKarton.KartonID = (int)dataReader["KartonID"];
        
                listaKartona.Add(pomKarton);
            }
        }

        private void ucitajKartonDijagnoza()
        {
            PropertyKartonDijagnoza kartonDijagnoza = new PropertyKartonDijagnoza();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, kartonDijagnoza.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyKartonDijagnoza pomKartonDijagnoza = new PropertyKartonDijagnoza();
                pomKartonDijagnoza.KartonDijagnozaID = (int)dataReader["PacijentID"];
                pomKartonDijagnoza.KartonID = (int)dataReader["KartonID"];
                pomKartonDijagnoza.DijagnozaID = (int)dataReader["DijagnozaID"];
                listaKartonDijagnoza.Add(pomKartonDijagnoza);
            }
        }

        private void ucitajOsobu()
        {
            PropertyOsoba osoba = new PropertyOsoba();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, osoba.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyOsoba pomOsoba = new PropertyOsoba();
                pomOsoba.OsobaID = (int)dataReader["OsobaID"];
                pomOsoba.Ime = (string)dataReader["Ime"];
                pomOsoba.Prezime = (string)dataReader["Prezime"];
                pomOsoba.JMB = (int)dataReader["JMB"];
                pomOsoba.Adresa = (string)dataReader["Adresa"];
                pomOsoba.Kontakt = (string)dataReader["Kontakt"];
                pomOsoba.Pol = (char)dataReader["Pol"];
                pomOsoba.MjestoRodjenja = (string)dataReader["MjestoRodjenja"];
                pomOsoba.DatumRodjenja = (DateTime)dataReader["DatumRodjenja"];
                listaOsoba.Add(pomOsoba);
            }
        }

        private void ucitajPregled()
        {
            PropertyPregled pregled = new PropertyPregled();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, pregled.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyPregled pomPregled = new PropertyPregled();
                pomPregled.PregledID = (int)dataReader["PregledID"];
                pomPregled.DoktorID = (int)dataReader["DoktorID"];
                pomPregled.PacijentID = (int)dataReader["PacijentID"];
                pomPregled.DijagnozaID = (int)dataReader["DijagnozaID"];
                listaPregleda.Add(pomPregled);
            }
        }

        private void ucitajRacun()
        {
            PropertyRacun racun = new PropertyRacun();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, racun.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyRacun pomRacun = new PropertyRacun();
                pomRacun.RacunID = (int)dataReader["RacunID"];
                pomRacun.VrijemeIzdavanja = (DateTime)dataReader["VrijemeIzdavanja"];
                pomRacun.ZaposleniID = (int)dataReader["ZaposleniID"];
                pomRacun.Popust = (decimal)dataReader["Popust"];
                pomRacun.PacijentID = (int)dataReader["PacijentID"];
                listaRacuna.Add(pomRacun);
            }
        }

        private void ucitajRecepciju()
        {
            PropertyRecepcija recepcija = new PropertyRecepcija();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, recepcija.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyRecepcija pomRecepcija = new PropertyRecepcija();
                pomRecepcija.PrijemID = (int)dataReader["PrijemID"];
                pomRecepcija.PrijemZaposleniID = (int)dataReader["PrijemZaposlenihID"];
                pomRecepcija.PacijentID = (int)dataReader["PacijentID"];
                pomRecepcija.DoktorID = (int)dataReader["DoktorID"];
                pomRecepcija.Prioritet = (int)dataReader["Prioritet"];
                pomRecepcija.VrijemePrijema = (DateTime)dataReader["VrijemePrijema"];
                pomRecepcija.VrijemeOtpusta = (DateTime)dataReader["VrijemeOtpusta"];
                listaRecepcija.Add(pomRecepcija);
            }
        }

        private void ucitajRezervaciju()
        {
            PropertyRezervacije rezervacija = new PropertyRezervacije();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, rezervacija.GetSelectQuery());

            while (dataReader.Read())
            {
                PropertyRezervacije pomRezervacija = new PropertyRezervacije();
                pomRezervacija.RezervacijaID = (int)dataReader["RezervacijaID"];
                pomRezervacija.PacijentID = (int)dataReader["PacijentID"];
                pomRezervacija.VrijemeRezervacije = (DateTime)dataReader["VrijemeRezervacije"];
                pomRezervacija.Termin = (DateTime)dataReader["Termin"];
                pomRezervacija.DoktorID = (int)dataReader["DoktorID"];
                listaRezervacija.Add(pomRezervacija);
            }
        }


        private void btnIzlaz_Click(object sender, EventArgs e)
        {

            this.Close();
            Application.Exit();

        }

        private void btnNastavi_Click(object sender, EventArgs e)
        {
            dugme();
        }

        private void dugme()
        {
            bool provjera = false;
            if (txtKorisnickoIme.Text != "")   
            foreach (var item in listaZaposlenih)
            {
                if (item.KorisnickoIme.Equals(txtKorisnickoIme.Text))
                {
                    if (item.Password.Equals(txtLozinka.Text))
                    {
                        GlavnaForma glavnaForma = new GlavnaForma();
                        this.Hide();
                        glavnaForma.Show();                        
                    }
                    else
                        MessageBox.Show("Pogrešna lozinka!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    provjera = true;
                    break;
                }
            }
            if (!provjera)
                MessageBox.Show("Pogrešno korisničko ime!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnIzlaz_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnIzlaz_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txtLozinka_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dugme();
            }
        }
    }
}

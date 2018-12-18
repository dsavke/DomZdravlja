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
    public partial class CustomPretraga : UserControl
    {
        public string tabName;

        public CustomPretraga()
        {
            InitializeComponent();
        }
        public CustomPretraga(string tabName)
        {
            InitializeComponent();
            this.tabName = tabName;
        }

        private void CustomPretraga_Load(object sender, EventArgs e)
        {
            if (tabName == "ZAPOSLENI" || tabName == "PACIJENT")
            {
                UCTekst ucIme = new UCTekst();
                ucIme.Naziv = "Ime";
                flowLayoutPanel.Controls.Add(ucIme);

                UCTekst ucPrezime = new UCTekst();
                ucPrezime.Naziv = "Prezime";
                flowLayoutPanel.Controls.Add(ucPrezime);

                UCDatum ucDatum = new UCDatum();
                ucDatum.Naziv = "Datum rodjenja";
                flowLayoutPanel.Controls.Add(ucDatum);
            }
            else if ( tabName == "RACUN")
            {
                UCDatum ucDatum = new UCDatum();
                ucDatum.Naziv = "Datum";
                flowLayoutPanel.Controls.Add(ucDatum);
            }
            else if (tabName == "CJENOVNIK")
            {
                UCTekst ucNaziv = new UCTekst();
                ucNaziv.Naziv = "Naziv usluge";
                flowLayoutPanel.Controls.Add(ucNaziv);
            }
            else
            {
                lblPretraga.Visible = false;
            }

        }
    }
}

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
using DomZdravlja.CustomControls;

namespace DomZdravlja
{
    public partial class Form1 : Form
    {

        #region Liste

        List<PropertyZaposleni> listaZaposlenih = new List<PropertyZaposleni>();

        #endregion


        public Form1()
        {

            InitializeComponent();
            ucitajZaposlene();

        }

        #region Ucitavanje
        private void ucitajZaposlene()
        {
            listaZaposlenih = new List<PropertyZaposleni>();
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
        #endregion

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
            ucitajZaposlene();
            if (txtKorisnickoIme.Text != "")
            {
                foreach (var item in listaZaposlenih)
                {
                    if (item.KorisnickoIme.Equals(txtKorisnickoIme.Text))
                    {
                        if (item.Password.Equals(txtLozinka.Text))
                        {
                            GlavnaForma glavnaForma = new GlavnaForma(item);
                            this.Hide();
                            glavnaForma.Show();
                        }
                        else
                        {
                            CustomMessageBox messageBox = new CustomMessageBox("Greška", "Pogrešna lozinka!", MessageBoxButtons.OK);
                            DialogResult dr = messageBox.ShowDialog();
                        }
                        provjera = true;
                        break;
                    }
                }
            }
             if (!provjera)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Greška", "Pogrešno korisničko ime!", MessageBoxButtons.OK);
                DialogResult dr = messageBox.ShowDialog();
            }
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

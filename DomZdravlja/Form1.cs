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
using DomZdravlja.PropertyClass;

namespace DomZdravlja
{
    public partial class Form1 : Form
    {
        List<PropertyZaposleni> listaZaposlenih = new List<PropertyZaposleni>();

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

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite napustiti program?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }

        }

        private void btnNastavi_Click(object sender, EventArgs e)
        {
            GlavnaForma glavnaForma = new GlavnaForma();
            this.Hide();
            glavnaForma.Show();
        }

        private void btnIzlaz_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btnIzlaz_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}

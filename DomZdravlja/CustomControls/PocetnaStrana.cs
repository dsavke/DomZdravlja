using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomZdravlja.PropertyClass;
using System.Text.RegularExpressions;

namespace DomZdravlja.CustomControls
{
    public partial class PocetnaStrana : UserControl
    {
        PropertyZaposleni Logovan;
        public PocetnaStrana(PropertyZaposleni logovan)
        {
            InitializeComponent();
            Logovan = logovan;
        }

        public PocetnaStrana()
        {
            InitializeComponent();
        }

        public string Ime
        {
            get { return lblIme.Text; }
            set { lblIme.Text = value; }
        }
        public string Prezime
        {
            get { return lblPrezime.Text; }
            set { lblPrezime.Text = value; }
        }
        public string TipZaposlenog
        {
            get { return lblTipZaposlenog.Text; }
            set { lblTipZaposlenog.Text = value; }
        }

        public Image PostaviImage
        {
            set { pictureBox1.Image = value; }
        }

        private void btnSifra_Click(object sender, EventArgs e)
        {
            panel2.Show();
            btnSifra.Click -= btnSifra_Click;
            btnSifra.Click += BtnSifraSakrij_Click;
            btnSifra.Text = "Sakrij sifru";
        }

        private void BtnSifraSakrij_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            btnSifra.Text = "Promijeni sifru";
            btnSifra.Click -= BtnSifraSakrij_Click;
            btnSifra.Click += btnSifra_Click;
        }

        private void btnSacuvajPromjene_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([a-z0-9]{3,15}(([\._][a-z0-9]{3,16})?))*$");

            if(Logovan.Password == tbStaraSifra.Text && 
               Regex.Match(tbNovaSifra.Text, @"^([a-z0-9]{3,15}(([\._][a-z0-9]{3,16})?))*$").Success &&
               tbNovaSifra.Text == tbPonovljenaSifra.Text &&
               !string.IsNullOrWhiteSpace(tbNovaSifra.Text))
            {
                Logovan.Password = tbNovaSifra.Text;
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, Logovan.GetUpdateQuery(), Logovan.GetUpdateParameters().ToArray());
                CustomMessageBox messageBox = new CustomMessageBox("Obavještenje", "Šifra uspješno promjenjena", MessageBoxButtons.OK);
                messageBox.ShowDialog();
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox("Upozorenje", "Niste promijenili šifru", MessageBoxButtons.OK);
                messageBox.ShowDialog();
                
            }
        }
        
    }
}

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
using DomZdravlja.

namespace DomZdravlja
{
    public partial class Form1 : Form
    {
        List<PropertyZaposleni> listaZaposlenih = new List<PropertyZaposleni>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ucitajZaposlene()
        {
            SqlDataReader dataReader = SqlHelper.
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
    }
}

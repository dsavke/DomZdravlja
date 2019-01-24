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
    public partial class CustomMessageBox : Form
    {

        public string Poruka
        {
            get { return lblNazivPoruke.Text; }
            set { lblNazivPoruke.Text = value; }
        }
        public string NazivBoxa
        {
            get { return lblPoruka.Text; }
            set { lblPoruka.Text = value; }
        }

        public DialogResult DialogResultValue
        {
            get;set;
        }
       

        public CustomMessageBox() {
            InitializeComponent();
            
        }

        public CustomMessageBox(string naziv, string por, MessageBoxButtons btn)
        {
            InitializeComponent();
            lblNazivPoruke.Text = naziv;
            this.Text = naziv;
            lblPoruka.Text = por;

            if (btn == MessageBoxButtons.YesNo)
            {

            }
            else if (btn == MessageBoxButtons.OK)
            {
                btnDa.Location = new Point(181, 175);
                btnDa.Text = "OK";

                btnNe.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDa_Click(object sender, EventArgs e)
        {
            if (btnDa.Text.Equals("OK"))
            {
                DialogResult =  DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Yes;
            }
            
        }

        private void btnNe_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(0, 67, 127)), 2), e.ClipRectangle);
        }

    }
}

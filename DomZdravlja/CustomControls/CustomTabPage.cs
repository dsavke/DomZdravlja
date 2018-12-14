using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZdravlja
{
    public class CustomTabPage : TabPage
    {
        public State State { get; set; }

        public string Naziv
        {
            get { return base.Text; }
            set { base.Text = value + "     "; }
        }

       
        /*public Font Slova
        {
            get { return base.Font; }
            set {
                base.Font =
              new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            }
                //new Font(new FontFamily( "Microsoft Sans Serif", 8.25, FontStyle.Bold); }
            
        }*/

        

    }
}

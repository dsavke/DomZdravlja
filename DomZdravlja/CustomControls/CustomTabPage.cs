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
            set { base.Text = value + (State == State.Main?"":"     "); }
        }
    }
}

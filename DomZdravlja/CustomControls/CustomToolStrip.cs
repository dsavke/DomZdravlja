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
    public partial class CustomToolStrip : UserControl
    {
        public CustomToolStrip()
        {
            InitializeComponent();
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

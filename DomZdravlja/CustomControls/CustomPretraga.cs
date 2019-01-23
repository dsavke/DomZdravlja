using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomZdravlja.AttributeClass;

namespace DomZdravlja.CustomControls
{
    public partial class CustomPretraga : UserControl
    {
        private PropertyInterface myProperty;
        private MainSearch search;

        public CustomPretraga()
        {
            InitializeComponent();
        }
        public CustomPretraga(PropertyInterface property, MainSearch search)
        {
            InitializeComponent();
            this.myProperty = property;
            this.search = search;
        }

        private void CustomPretraga_Load(object sender, EventArgs e)
        {
           
        }
    }
}

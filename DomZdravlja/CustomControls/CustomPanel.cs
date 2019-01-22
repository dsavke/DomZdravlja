using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZdravlja.CustomControls
{
    public class CustomPanel: Panel
    {
        private Color colorBorder = Color.Transparent;

        public Color BorderColor
        {
            get
            {
                return colorBorder;
            }
            set
            {
                colorBorder = value;
            }
        }

        public CustomPanel(): base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(colorBorder), 2),e.ClipRectangle);
        }

    }
}

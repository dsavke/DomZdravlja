using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZdravlja.CustomControls
{
    public class CustomTabControl:TabControl
    {
        private readonly StringFormat CenterSringFormat = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        #region Atributi
        private Color backTabColor = Color.FromArgb(255, 255, 255);
        private Color closingButtonColor = Color.FromArgb(51, 128, 196);
        private TabPage predraggedTab;
        public bool ShowClosingButton { get; set; }
        public Color selectedTextColor = Color.FromArgb(51, 128, 196);
        #endregion

        public CustomTabControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw
                | ControlStyles.OptimizedDoubleBuffer,
                true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(240, 32);
            AllowDrop = true;
        }

        #region Property
        [Category("Colors"), Browsable(true), Description("The color of the closing button")]
        public Color ClosingButtonColor
        {
            get
            {
                return this.closingButtonColor;
            }

            set
            {
                this.closingButtonColor = value;
            }
        }
        [Category("Options"), Browsable(true), Description("Show a Yes/No message before closing?")]
        public bool ShowClosingMessage { get; set; }

        [Category("Colors"), Browsable(true), Description("The color of the title of the page")]
        public Color SelectedTextColor
        {
            get
            {
                return this.selectedTextColor;
            }

            set
            {
                this.selectedTextColor = value;
            }
        }
        #endregion

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }


        #region SelektovaniTab
        protected override void OnMouseDown(MouseEventArgs e)
        {
            predraggedTab = getPointedTab();
            var p = e.Location;
            if (!this.ShowClosingButton)
            {
            }
            else
            {
                for (var i = 0; i < this.TabCount; i++)
                {
                    
                    Rectangle rec = new Rectangle(GetTabRect(i).Location.X + GetTabRect(i).Width - 18, 11, 10, 10);

                    if (!rec.Contains(p))
                    {
                        continue;
                    }
                    else
                    {
                        this.TabPages.RemoveAt(i);
                    }
                
                }
            }

            base.OnMouseDown(e);
        }
        #endregion

        #region OnPaint
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var Drawer = g;

            Drawer.SmoothingMode = SmoothingMode.HighQuality;
            Drawer.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Drawer.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Drawer.Clear(SystemColors.Control);
            try
            {
                SelectedTab.BackColor = this.backTabColor;
            }
            catch
            {
                // ignored
            }

            try//Rijesen po kratkom postupku
            {
                SelectedTab.BorderStyle = BorderStyle.None;
            }
            catch
            {
                // ignored
            }
            int index = -1;
            for (var i = 0; i <= TabCount - 1; i++)
            {
          
                var Header = new Rectangle(
                    new Point(GetTabRect(i).Location.X + 8, GetTabRect(i).Location.Y),
                    new Size(GetTabRect(i).Width, GetTabRect(i).Height));
                var HeaderSize = new Rectangle(Header.Location, new Size(Header.Width, Header.Height));
                Brush ClosingColorBrush = new SolidBrush(this.closingButtonColor);

                if (i == SelectedIndex)
                {
                    index = i;
                    Point[] points1 = new Point[4];
                    points1[1] = new Point(GetTabRect(index).Location.X - 1, GetTabRect(index).Location.Y - 1);
                    points1[2] = new Point(GetTabRect(index).Location.X + GetTabRect(index).Width - 1, GetTabRect(index).Location.Y - 1);
                    points1[3] = new Point(GetTabRect(index).Location.X + GetTabRect(index).Width - 1, GetTabRect(index).Location.Y + GetTabRect(index).Height);
                    points1[0] = new Point(GetTabRect(index).Location.X - 1, GetTabRect(index).Location.Y + GetTabRect(index).Height);

                    Drawer.FillPolygon(new SolidBrush(Color.White), points1);

                    // Draws the title of the page
                    Drawer.DrawString(
                        TabPages[i].Text,
                        Font,
                        new SolidBrush(this.selectedTextColor),
                        HeaderSize,
                        this.CenterSringFormat);

                    //button zatvaranje
                    if (this.ShowClosingButton)
                    {
                        e.Graphics.DrawString("X", Font, ClosingColorBrush, HeaderSize.Right - 26, 11);
                        
                    }
                }
                else
                {

                    Point[] points1 = new Point[4];
                    points1[1] = new Point(GetTabRect(i).Location.X - 1, GetTabRect(i).Location.Y - 1);
                    points1[2] = new Point(GetTabRect(i).Location.X + GetTabRect(i).Width - 1, GetTabRect(i).Location.Y - 1);
                    points1[3] = new Point(GetTabRect(i).Location.X + GetTabRect(i).Width - 1, GetTabRect(i).Location.Y + GetTabRect(i).Height);
                    points1[0] = new Point(GetTabRect(i).Location.X - 1, GetTabRect(i).Location.Y + GetTabRect(i).Height);
                    Drawer.DrawLines(new Pen(Color.DarkGray, 2), points1);

                    // Simply draws the header when it is not selected
                    Drawer.DrawString(
                        TabPages[i].Text,
                        Font,
                        new SolidBrush(Color.DarkGray),
                        HeaderSize,
                        this.CenterSringFormat);
                }


                if(index != -1)
                {
                    Point[] points1 = new Point[4];
                    points1[1] = new Point(GetTabRect(index).Location.X - 1, GetTabRect(index).Location.Y - 1);
                    points1[2] = new Point(GetTabRect(index).Location.X + GetTabRect(index).Width - 1, GetTabRect(index).Location.Y - 1);
                    points1[3] = new Point(GetTabRect(index).Location.X + GetTabRect(index).Width - 1, GetTabRect(index).Location.Y + GetTabRect(index).Height);
                    points1[0] = new Point(GetTabRect(index).Location.X - 1, GetTabRect(index).Location.Y + GetTabRect(index).Height);

                    
                    Drawer.DrawLines(new Pen(this.selectedTextColor, 2), points1);

                    Drawer.DrawLine(new Pen(this.selectedTextColor, 2), new Point(0, 31), new Point(GetTabRect(index).Location.X, 31));

                    Drawer.DrawLine(new Pen(this.selectedTextColor, 2), new Point(GetTabRect(index).Location.X + GetTabRect(index).Width, 31), new Point(Width, 31));
                }

            }


            // Draws the background of the tab control
            Drawer.FillRectangle(new SolidBrush(this.backTabColor), new Rectangle(0, 32, Width, Height - 32));

            // Draws the border of the TabControl
            Point[] points = new Point[4];
            points[0] = new Point(1, 32);
            points[1] = new Point(1, Height - 1);
            points[2] = new Point(Width - 1, Height - 1);
            points[3] = new Point(Width - 1, 32);

            Drawer.DrawLines(new Pen(this.selectedTextColor, 2), points);
            Drawer.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }
        #endregion

        #region TrenutniTab
        private TabPage getPointedTab()
        {
            for (var i = 0; i <= this.TabPages.Count - 1; i++)
            {
                if (this.GetTabRect(i).Contains(this.PointToClient(Cursor.Position)))
                {
                    return this.TabPages[i];
                }
            }

            return null;
        }
        #endregion
    }
}

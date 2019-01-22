using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZdravlja.CustomControls
{
    public class CustomDataGridView:DataGridView
    {
       
        public Tip Tip { get; set; }

        public CustomDataGridView(int width, int height)
        {

            this.Width = width;
            this.Height = height;
            this.Font = new Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.MultiSelect = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.RowsDefaultCellStyle.BackColor = Color.White;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(227, 234, 244);
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 128, 196);
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.AllowUserToAddRows = false;

        }

    }
}

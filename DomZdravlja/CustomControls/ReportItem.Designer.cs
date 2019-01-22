namespace DomZdravlja.CustomControls
{
    partial class ReportItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNazivIzvjestaja = new System.Windows.Forms.Label();
            this.pibSlikaIzvjestaja = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pibSlikaIzvjestaja)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNazivIzvjestaja
            // 
            this.lblNazivIzvjestaja.AutoSize = true;
            this.lblNazivIzvjestaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivIzvjestaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(128)))));
            this.lblNazivIzvjestaja.Location = new System.Drawing.Point(65, 17);
            this.lblNazivIzvjestaja.Name = "lblNazivIzvjestaja";
            this.lblNazivIzvjestaja.Size = new System.Drawing.Size(148, 16);
            this.lblNazivIzvjestaja.TabIndex = 1;
            this.lblNazivIzvjestaja.Text = "IZVJESTAJ RAČUNI";
            this.lblNazivIzvjestaja.DoubleClick += new System.EventHandler(this.ReportItem_Click);
            // 
            // pibSlikaIzvjestaja
            // 
            this.pibSlikaIzvjestaja.BackColor = System.Drawing.Color.Transparent;
            this.pibSlikaIzvjestaja.Image = global::DomZdravlja.Properties.Resources.zaposleni;
            this.pibSlikaIzvjestaja.Location = new System.Drawing.Point(9, 9);
            this.pibSlikaIzvjestaja.Margin = new System.Windows.Forms.Padding(0);
            this.pibSlikaIzvjestaja.Name = "pibSlikaIzvjestaja";
            this.pibSlikaIzvjestaja.Size = new System.Drawing.Size(32, 32);
            this.pibSlikaIzvjestaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pibSlikaIzvjestaja.TabIndex = 0;
            this.pibSlikaIzvjestaja.TabStop = false;
            this.pibSlikaIzvjestaja.DoubleClick += new System.EventHandler(this.ReportItem_Click);
            // 
            // ReportItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblNazivIzvjestaja);
            this.Controls.Add(this.pibSlikaIzvjestaja);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReportItem";
            this.Size = new System.Drawing.Size(254, 50);
            this.DoubleClick += new System.EventHandler(this.ReportItem_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pibSlikaIzvjestaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pibSlikaIzvjestaja;
        private System.Windows.Forms.Label lblNazivIzvjestaja;
    }
}

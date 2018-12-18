namespace DomZdravlja.CustomControls
{
    partial class CustomToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomToolStrip));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnZadnji = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDOle = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGore = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPrvi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDodaj = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAzuriraj = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPretraga = new System.Windows.Forms.ToolStripButton();
            this.tsbtnObrisi = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnZadnji,
            this.tsbtnDOle,
            this.tsbtnGore,
            this.tsbtnPrvi,
            this.toolStripSeparator1,
            this.tsbtnDodaj,
            this.tsbtnAzuriraj,
            this.tsbtnPretraga,
            this.tsbtnObrisi});
            this.toolStrip1.Location = new System.Drawing.Point(375, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(395, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnZadnji
            // 
            this.tsbtnZadnji.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnZadnji.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnZadnji.Image")));
            this.tsbtnZadnji.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZadnji.Name = "tsbtnZadnji";
            this.tsbtnZadnji.Size = new System.Drawing.Size(23, 22);
            this.tsbtnZadnji.Text = "Zadnji";
            this.tsbtnZadnji.ToolTipText = "Zadnji";
            // 
            // tsbtnDOle
            // 
            this.tsbtnDOle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDOle.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDOle.Image")));
            this.tsbtnDOle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDOle.Name = "tsbtnDOle";
            this.tsbtnDOle.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDOle.Text = "Dole";
            // 
            // tsbtnGore
            // 
            this.tsbtnGore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGore.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGore.Image")));
            this.tsbtnGore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGore.Name = "tsbtnGore";
            this.tsbtnGore.Size = new System.Drawing.Size(23, 22);
            this.tsbtnGore.Text = "Gore";
            // 
            // tsbtnPrvi
            // 
            this.tsbtnPrvi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPrvi.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPrvi.Image")));
            this.tsbtnPrvi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrvi.Name = "tsbtnPrvi";
            this.tsbtnPrvi.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPrvi.Text = "Prvi";
            this.tsbtnPrvi.ToolTipText = "Prvi";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnDodaj
            // 
            this.tsbtnDodaj.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDodaj.Image")));
            this.tsbtnDodaj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDodaj.Name = "tsbtnDodaj";
            this.tsbtnDodaj.Size = new System.Drawing.Size(58, 22);
            this.tsbtnDodaj.Text = "Dodaj";
            this.tsbtnDodaj.ToolTipText = "Dodaj";
            this.tsbtnDodaj.Click += new System.EventHandler(this.tsbtnDodaj_Click);
            // 
            // tsbtnAzuriraj
            // 
            this.tsbtnAzuriraj.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAzuriraj.Image")));
            this.tsbtnAzuriraj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAzuriraj.Name = "tsbtnAzuriraj";
            this.tsbtnAzuriraj.Size = new System.Drawing.Size(67, 22);
            this.tsbtnAzuriraj.Text = "Ažuriraj";
            // 
            // tsbtnPretraga
            // 
            this.tsbtnPretraga.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPretraga.Image")));
            this.tsbtnPretraga.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPretraga.Name = "tsbtnPretraga";
            this.tsbtnPretraga.Size = new System.Drawing.Size(71, 22);
            this.tsbtnPretraga.Text = "Pretraga";
            // 
            // tsbtnObrisi
            // 
            this.tsbtnObrisi.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnObrisi.Image")));
            this.tsbtnObrisi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnObrisi.Name = "tsbtnObrisi";
            this.tsbtnObrisi.Size = new System.Drawing.Size(58, 22);
            this.tsbtnObrisi.Text = "Obriši";
            // 
            // CustomToolStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "CustomToolStrip";
            this.Size = new System.Drawing.Size(908, 33);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnDodaj;
        private System.Windows.Forms.ToolStripButton tsbtnAzuriraj;
        private System.Windows.Forms.ToolStripButton tsbtnObrisi;
        private System.Windows.Forms.ToolStripButton tsbtnPretraga;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnZadnji;
        private System.Windows.Forms.ToolStripButton tsbtnDOle;
        private System.Windows.Forms.ToolStripButton tsbtnGore;
        private System.Windows.Forms.ToolStripButton tsbtnPrvi;
    }
}

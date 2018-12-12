namespace DomZdravlja
{
    partial class PanelTabControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelTabControl));
            this.ikonica = new System.Windows.Forms.PictureBox();
            this.lblNaziv = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ikonica)).BeginInit();
            this.SuspendLayout();
            // 
            // ikonica
            // 
            this.ikonica.Image = ((System.Drawing.Image)(resources.GetObject("ikonica.Image")));
            this.ikonica.Location = new System.Drawing.Point(8, 11);
            this.ikonica.Name = "ikonica";
            this.ikonica.Size = new System.Drawing.Size(32, 32);
            this.ikonica.TabIndex = 0;
            this.ikonica.TabStop = false;
            this.ikonica.MouseEnter += new System.EventHandler(this.PanelTabControl_MouseEnter);
            this.ikonica.MouseLeave += new System.EventHandler(this.PanelTabControl_MouseLeave);
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaziv.ForeColor = System.Drawing.Color.White;
            this.lblNaziv.Location = new System.Drawing.Point(55, 16);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(99, 20);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "RECEPCIJA";
            this.lblNaziv.MouseEnter += new System.EventHandler(this.PanelTabControl_MouseEnter);
            this.lblNaziv.MouseLeave += new System.EventHandler(this.PanelTabControl_MouseLeave);
            // 
            // PanelTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(127)))));
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.ikonica);
            this.Name = "PanelTabControl";
            this.Size = new System.Drawing.Size(266, 54);
            this.MouseEnter += new System.EventHandler(this.PanelTabControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.PanelTabControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.ikonica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ikonica;
        private System.Windows.Forms.Label lblNaziv;
    }
}

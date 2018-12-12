namespace DomZdravlja
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnIzlaz = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.btnNastavi = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnIzlaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.BackColor = System.Drawing.SystemColors.Control;
            this.btnIzlaz.Image = ((System.Drawing.Image)(resources.GetObject("btnIzlaz.Image")));
            this.btnIzlaz.ImageActive = null;
            this.btnIzlaz.Location = new System.Drawing.Point(583, 12);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(25, 25);
            this.btnIzlaz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnIzlaz.TabIndex = 0;
            this.btnIzlaz.TabStop = false;
            this.btnIzlaz.Zoom = 10;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            this.btnIzlaz.MouseEnter += new System.EventHandler(this.btnIzlaz_MouseEnter);
            this.btnIzlaz.MouseLeave += new System.EventHandler(this.btnIzlaz_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "DomZdravlja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(239, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Korisnicko ime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(239, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lozinka";
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(242, 104);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(307, 20);
            this.txtKorisnickoIme.TabIndex = 5;
            // 
            // txtLozinka
            // 
            this.txtLozinka.Location = new System.Drawing.Point(242, 180);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.Size = new System.Drawing.Size(307, 20);
            this.txtLozinka.TabIndex = 6;
            this.txtLozinka.UseSystemPasswordChar = true;
            // 
            // btnNastavi
            // 
            this.btnNastavi.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(132)))), ((int)(((byte)(229)))));
            this.btnNastavi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(132)))), ((int)(((byte)(229)))));
            this.btnNastavi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNastavi.BorderRadius = 0;
            this.btnNastavi.ButtonText = "  Nastavi";
            this.btnNastavi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNastavi.DisabledColor = System.Drawing.Color.Gray;
            this.btnNastavi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNastavi.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNastavi.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNastavi.Iconimage")));
            this.btnNastavi.Iconimage_right = null;
            this.btnNastavi.Iconimage_right_Selected = null;
            this.btnNastavi.Iconimage_Selected = null;
            this.btnNastavi.IconMarginLeft = 10;
            this.btnNastavi.IconMarginRight = 0;
            this.btnNastavi.IconRightVisible = true;
            this.btnNastavi.IconRightZoom = 0D;
            this.btnNastavi.IconVisible = true;
            this.btnNastavi.IconZoom = 50D;
            this.btnNastavi.IsTab = false;
            this.btnNastavi.Location = new System.Drawing.Point(321, 241);
            this.btnNastavi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNastavi.Name = "btnNastavi";
            this.btnNastavi.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(132)))), ((int)(((byte)(229)))));
            this.btnNastavi.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(132)))), ((int)(((byte)(229)))));
            this.btnNastavi.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNastavi.selected = false;
            this.btnNastavi.Size = new System.Drawing.Size(139, 42);
            this.btnNastavi.TabIndex = 7;
            this.btnNastavi.Text = "  Nastavi";
            this.btnNastavi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNastavi.Textcolor = System.Drawing.Color.White;
            this.btnNastavi.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNastavi.Click += new System.EventHandler(this.btnNastavi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 345);
            this.Controls.Add(this.btnNastavi);
            this.Controls.Add(this.txtLozinka);
            this.Controls.Add(this.txtKorisnickoIme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnIzlaz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.btnIzlaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuImageButton btnIzlaz;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnNastavi;
        private System.Windows.Forms.TextBox txtLozinka;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}


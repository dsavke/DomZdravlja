namespace DomZdravlja.CustomControls
{
    partial class PocetnaStrana
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocetnaStrana));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSacuvajPromjene = new System.Windows.Forms.Button();
            this.tbPonovljenaSifra = new System.Windows.Forms.TextBox();
            this.tbNovaSifra = new System.Windows.Forms.TextBox();
            this.tbStaraSifra = new System.Windows.Forms.TextBox();
            this.lblPonovljenaSifra = new System.Windows.Forms.Label();
            this.lblNovaSifra = new System.Windows.Forms.Label();
            this.lblStaraSifra = new System.Windows.Forms.Label();
            this.btnSifra = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTipZaposlenog = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnSifra);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTipZaposlenog);
            this.panel1.Controls.Add(this.lblPrezime);
            this.panel1.Controls.Add(this.lblIme);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 701);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSacuvajPromjene);
            this.panel2.Controls.Add(this.tbPonovljenaSifra);
            this.panel2.Controls.Add(this.tbNovaSifra);
            this.panel2.Controls.Add(this.tbStaraSifra);
            this.panel2.Controls.Add(this.lblPonovljenaSifra);
            this.panel2.Controls.Add(this.lblNovaSifra);
            this.panel2.Controls.Add(this.lblStaraSifra);
            this.panel2.Location = new System.Drawing.Point(52, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 261);
            this.panel2.TabIndex = 9;
            this.panel2.Visible = false;
            // 
            // btnSacuvajPromjene
            // 
            this.btnSacuvajPromjene.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.btnSacuvajPromjene.Location = new System.Drawing.Point(81, 207);
            this.btnSacuvajPromjene.Name = "btnSacuvajPromjene";
            this.btnSacuvajPromjene.Size = new System.Drawing.Size(211, 33);
            this.btnSacuvajPromjene.TabIndex = 6;
            this.btnSacuvajPromjene.Text = "Sačuvaj promjene";
            this.btnSacuvajPromjene.UseVisualStyleBackColor = true;
            this.btnSacuvajPromjene.Click += new System.EventHandler(this.btnSacuvajPromjene_Click);
            // 
            // tbPonovljenaSifra
            // 
            this.tbPonovljenaSifra.Location = new System.Drawing.Point(204, 149);
            this.tbPonovljenaSifra.Name = "tbPonovljenaSifra";
            this.tbPonovljenaSifra.PasswordChar = '●';
            this.tbPonovljenaSifra.Size = new System.Drawing.Size(153, 20);
            this.tbPonovljenaSifra.TabIndex = 5;
            // 
            // tbNovaSifra
            // 
            this.tbNovaSifra.Location = new System.Drawing.Point(204, 96);
            this.tbNovaSifra.Name = "tbNovaSifra";
            this.tbNovaSifra.PasswordChar = '●';
            this.tbNovaSifra.Size = new System.Drawing.Size(153, 20);
            this.tbNovaSifra.TabIndex = 4;
            // 
            // tbStaraSifra
            // 
            this.tbStaraSifra.Location = new System.Drawing.Point(204, 43);
            this.tbStaraSifra.Name = "tbStaraSifra";
            this.tbStaraSifra.PasswordChar = '●';
            this.tbStaraSifra.Size = new System.Drawing.Size(153, 20);
            this.tbStaraSifra.TabIndex = 3;
            // 
            // lblPonovljenaSifra
            // 
            this.lblPonovljenaSifra.AutoSize = true;
            this.lblPonovljenaSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPonovljenaSifra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.lblPonovljenaSifra.Location = new System.Drawing.Point(31, 147);
            this.lblPonovljenaSifra.Name = "lblPonovljenaSifra";
            this.lblPonovljenaSifra.Size = new System.Drawing.Size(168, 20);
            this.lblPonovljenaSifra.TabIndex = 2;
            this.lblPonovljenaSifra.Text = "Potvrdite novu šifru:";
            // 
            // lblNovaSifra
            // 
            this.lblNovaSifra.AutoSize = true;
            this.lblNovaSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovaSifra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.lblNovaSifra.Location = new System.Drawing.Point(31, 94);
            this.lblNovaSifra.Name = "lblNovaSifra";
            this.lblNovaSifra.Size = new System.Drawing.Size(94, 20);
            this.lblNovaSifra.TabIndex = 1;
            this.lblNovaSifra.Text = "Nova šifra:";
            // 
            // lblStaraSifra
            // 
            this.lblStaraSifra.AutoSize = true;
            this.lblStaraSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaraSifra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.lblStaraSifra.Location = new System.Drawing.Point(31, 40);
            this.lblStaraSifra.Name = "lblStaraSifra";
            this.lblStaraSifra.Size = new System.Drawing.Size(126, 20);
            this.lblStaraSifra.TabIndex = 0;
            this.lblStaraSifra.Text = "Trenutna šifra:";
            // 
            // btnSifra
            // 
            this.btnSifra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.btnSifra.Location = new System.Drawing.Point(52, 218);
            this.btnSifra.Name = "btnSifra";
            this.btnSifra.Size = new System.Drawing.Size(112, 35);
            this.btnSifra.TabIndex = 8;
            this.btnSifra.Text = "Promijeni šifru";
            this.btnSifra.UseVisualStyleBackColor = true;
            this.btnSifra.Click += new System.EventHandler(this.btnSifra_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.label4.Location = new System.Drawing.Point(300, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tip zaposlenog:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.label3.Location = new System.Drawing.Point(300, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Prezime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.label2.Location = new System.Drawing.Point(300, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ime:";
            // 
            // lblTipZaposlenog
            // 
            this.lblTipZaposlenog.AutoSize = true;
            this.lblTipZaposlenog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipZaposlenog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.lblTipZaposlenog.Location = new System.Drawing.Point(453, 135);
            this.lblTipZaposlenog.Name = "lblTipZaposlenog";
            this.lblTipZaposlenog.Size = new System.Drawing.Size(51, 20);
            this.lblTipZaposlenog.TabIndex = 4;
            this.lblTipZaposlenog.Text = "label4";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.lblPrezime.Location = new System.Drawing.Point(453, 103);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(51, 20);
            this.lblPrezime.TabIndex = 3;
            this.lblPrezime.Text = "label3";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.lblIme.Location = new System.Drawing.Point(453, 71);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(51, 20);
            this.lblIme.TabIndex = 2;
            this.lblIme.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(196)))));
            this.label1.Location = new System.Drawing.Point(252, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trenutno ulogovan/a:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PocetnaStrana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PocetnaStrana";
            this.Size = new System.Drawing.Size(908, 800);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTipZaposlenog;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbPonovljenaSifra;
        private System.Windows.Forms.TextBox tbNovaSifra;
        private System.Windows.Forms.TextBox tbStaraSifra;
        private System.Windows.Forms.Label lblPonovljenaSifra;
        private System.Windows.Forms.Label lblNovaSifra;
        private System.Windows.Forms.Label lblStaraSifra;
        private System.Windows.Forms.Button btnSifra;
        private System.Windows.Forms.Button btnSacuvajPromjene;
    }
}

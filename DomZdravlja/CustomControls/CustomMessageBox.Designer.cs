namespace DomZdravlja.CustomControls
{
    partial class CustomMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.PictureBox();
            this.lblNazivPoruke = new System.Windows.Forms.Label();
            this.lblPoruka = new System.Windows.Forms.Label();
            this.btnDa = new System.Windows.Forms.Button();
            this.btnNe = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnX)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(127)))));
            this.panel1.Controls.Add(this.btnX);
            this.panel1.Controls.Add(this.lblNazivPoruke);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 41);
            this.panel1.TabIndex = 0;
            // 
            // btnX
            // 
            this.btnX.Image = global::DomZdravlja.Properties.Resources.x_buttonWhite;
            this.btnX.Location = new System.Drawing.Point(429, 7);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(20, 20);
            this.btnX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnX.TabIndex = 1;
            this.btnX.TabStop = false;
            this.btnX.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblNazivPoruke
            // 
            this.lblNazivPoruke.AutoSize = true;
            this.lblNazivPoruke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivPoruke.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNazivPoruke.Location = new System.Drawing.Point(6, 10);
            this.lblNazivPoruke.Name = "lblNazivPoruke";
            this.lblNazivPoruke.Size = new System.Drawing.Size(51, 20);
            this.lblNazivPoruke.TabIndex = 0;
            this.lblNazivPoruke.Text = "label1";
            // 
            // lblPoruka
            // 
            this.lblPoruka.AutoSize = true;
            this.lblPoruka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoruka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(127)))));
            this.lblPoruka.Location = new System.Drawing.Point(32, 104);
            this.lblPoruka.Name = "lblPoruka";
            this.lblPoruka.Size = new System.Drawing.Size(51, 20);
            this.lblPoruka.TabIndex = 1;
            this.lblPoruka.Text = "label1";
            // 
            // btnDa
            // 
            this.btnDa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(127)))));
            this.btnDa.Location = new System.Drawing.Point(126, 175);
            this.btnDa.Name = "btnDa";
            this.btnDa.Size = new System.Drawing.Size(86, 33);
            this.btnDa.TabIndex = 3;
            this.btnDa.Text = "DA";
            this.btnDa.UseVisualStyleBackColor = true;
            this.btnDa.Click += new System.EventHandler(this.btnDa_Click);
            // 
            // btnNe
            // 
            this.btnNe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(127)))));
            this.btnNe.Location = new System.Drawing.Point(239, 175);
            this.btnNe.Name = "btnNe";
            this.btnNe.Size = new System.Drawing.Size(86, 33);
            this.btnNe.TabIndex = 4;
            this.btnNe.Text = "NE";
            this.btnNe.UseVisualStyleBackColor = true;
            this.btnNe.Click += new System.EventHandler(this.btnNe_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 240);
            this.Controls.Add(this.btnNe);
            this.Controls.Add(this.btnDa);
            this.Controls.Add(this.lblPoruka);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnX;
        private System.Windows.Forms.Label lblNazivPoruke;
        private System.Windows.Forms.Label lblPoruka;
        private System.Windows.Forms.Button btnDa;
        private System.Windows.Forms.Button btnNe;
    }
}

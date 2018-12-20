namespace DomZdravlja
{
    partial class UCRadioButton
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
            this.lblNaziv = new System.Windows.Forms.Label();
            this.rbOpcija1 = new System.Windows.Forms.RadioButton();
            this.rbOpcija2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaziv.Location = new System.Drawing.Point(19, 18);
            this.lblNaziv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(53, 20);
            this.lblNaziv.TabIndex = 0;
            this.lblNaziv.Text = "label1";
            // 
            // rbOpcija1
            // 
            this.rbOpcija1.AutoSize = true;
            this.rbOpcija1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpcija1.Location = new System.Drawing.Point(267, 16);
            this.rbOpcija1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbOpcija1.Name = "rbOpcija1";
            this.rbOpcija1.Size = new System.Drawing.Size(113, 22);
            this.rbOpcija1.TabIndex = 1;
            this.rbOpcija1.TabStop = true;
            this.rbOpcija1.Text = "radioButton1";
            this.rbOpcija1.UseVisualStyleBackColor = true;
            this.rbOpcija1.CheckedChanged += new System.EventHandler(this.rbOpcija1_CheckedChanged);
            // 
            // rbOpcija2
            // 
            this.rbOpcija2.AutoSize = true;
            this.rbOpcija2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpcija2.Location = new System.Drawing.Point(483, 16);
            this.rbOpcija2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbOpcija2.Name = "rbOpcija2";
            this.rbOpcija2.Size = new System.Drawing.Size(113, 22);
            this.rbOpcija2.TabIndex = 2;
            this.rbOpcija2.TabStop = true;
            this.rbOpcija2.Text = "radioButton2";
            this.rbOpcija2.UseVisualStyleBackColor = true;
            this.rbOpcija2.CheckedChanged += new System.EventHandler(this.rbOpcija2_CheckedChanged);
            // 
            // UCRadioButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbOpcija2);
            this.Controls.Add(this.rbOpcija1);
            this.Controls.Add(this.lblNaziv);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCRadioButton";
            this.Size = new System.Drawing.Size(1211, 62);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.RadioButton rbOpcija1;
        private System.Windows.Forms.RadioButton rbOpcija2;
    }
}

﻿namespace DomZdravlja
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
            this.lblNaziv.Location = new System.Drawing.Point(14, 15);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(45, 16);
            this.lblNaziv.TabIndex = 0;
            this.lblNaziv.Text = "label1";
            // 
            // rbOpcija1
            // 
            this.rbOpcija1.AutoSize = true;
            this.rbOpcija1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpcija1.Location = new System.Drawing.Point(200, 13);
            this.rbOpcija1.Name = "rbOpcija1";
            this.rbOpcija1.Size = new System.Drawing.Size(95, 19);
            this.rbOpcija1.TabIndex = 1;
            this.rbOpcija1.TabStop = true;
            this.rbOpcija1.Text = "radioButton1";
            this.rbOpcija1.UseVisualStyleBackColor = true;
            // 
            // rbOpcija2
            // 
            this.rbOpcija2.AutoSize = true;
            this.rbOpcija2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpcija2.Location = new System.Drawing.Point(362, 13);
            this.rbOpcija2.Name = "rbOpcija2";
            this.rbOpcija2.Size = new System.Drawing.Size(95, 19);
            this.rbOpcija2.TabIndex = 2;
            this.rbOpcija2.TabStop = true;
            this.rbOpcija2.Text = "radioButton2";
            this.rbOpcija2.UseVisualStyleBackColor = true;
            // 
            // UCRadioButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbOpcija2);
            this.Controls.Add(this.rbOpcija1);
            this.Controls.Add(this.lblNaziv);
            this.Name = "UCRadioButton";
            this.Size = new System.Drawing.Size(908, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.RadioButton rbOpcija1;
        private System.Windows.Forms.RadioButton rbOpcija2;
    }
}

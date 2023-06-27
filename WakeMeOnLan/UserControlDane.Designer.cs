namespace WakeMeOnLan
{
    partial class UserControlDane
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStan = new System.Windows.Forms.Button();
            this.labelAdresIPU = new System.Windows.Forms.Label();
            this.labelAdresMACU = new System.Windows.Forms.Label();
            this.buttonBudzenie = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelInfoPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStan
            // 
            this.buttonStan.Location = new System.Drawing.Point(4, 4);
            this.buttonStan.Name = "buttonStan";
            this.buttonStan.Size = new System.Drawing.Size(39, 23);
            this.buttonStan.TabIndex = 0;
            this.buttonStan.UseVisualStyleBackColor = true;
            // 
            // labelAdresIPU
            // 
            this.labelAdresIPU.AutoSize = true;
            this.labelAdresIPU.Location = new System.Drawing.Point(49, 7);
            this.labelAdresIPU.Name = "labelAdresIPU";
            this.labelAdresIPU.Size = new System.Drawing.Size(44, 16);
            this.labelAdresIPU.TabIndex = 1;
            this.labelAdresIPU.Text = "label1";
            // 
            // labelAdresMACU
            // 
            this.labelAdresMACU.AutoSize = true;
            this.labelAdresMACU.Location = new System.Drawing.Point(234, 7);
            this.labelAdresMACU.Name = "labelAdresMACU";
            this.labelAdresMACU.Size = new System.Drawing.Size(44, 16);
            this.labelAdresMACU.TabIndex = 2;
            this.labelAdresMACU.Text = "label2";
            // 
            // buttonBudzenie
            // 
            this.buttonBudzenie.Location = new System.Drawing.Point(440, 5);
            this.buttonBudzenie.Name = "buttonBudzenie";
            this.buttonBudzenie.Size = new System.Drawing.Size(75, 23);
            this.buttonBudzenie.TabIndex = 3;
            this.buttonBudzenie.Text = "Obudź";
            this.buttonBudzenie.UseVisualStyleBackColor = true;
            this.buttonBudzenie.Click += new System.EventHandler(this.buttonBudzenie_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(521, 7);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 22);
            this.textBoxPort.TabIndex = 4;
            this.textBoxPort.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(625, 7);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(46, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelInfoPort
            // 
            this.labelInfoPort.AutoSize = true;
            this.labelInfoPort.Location = new System.Drawing.Point(546, 32);
            this.labelInfoPort.Name = "labelInfoPort";
            this.labelInfoPort.Size = new System.Drawing.Size(17, 16);
            this.labelInfoPort.TabIndex = 6;
            this.labelInfoPort.Text = "\"\"";
            // 
            // UserControlDane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelInfoPort);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.buttonBudzenie);
            this.Controls.Add(this.labelAdresMACU);
            this.Controls.Add(this.labelAdresIPU);
            this.Controls.Add(this.buttonStan);
            this.Name = "UserControlDane";
            this.Size = new System.Drawing.Size(674, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStan;
        private System.Windows.Forms.Label labelAdresIPU;
        private System.Windows.Forms.Label labelAdresMACU;
        private System.Windows.Forms.Button buttonBudzenie;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelInfoPort;
    }
}

namespace WakeMeOnLan
{
    partial class Form1
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSkanuj = new System.Windows.Forms.Button();
            this.labelStan = new System.Windows.Forms.Label();
            this.labelAdresIP = new System.Windows.Forms.Label();
            this.labelAdresMAC = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // buttonSkanuj
            // 
            this.buttonSkanuj.Location = new System.Drawing.Point(16, 12);
            this.buttonSkanuj.Name = "buttonSkanuj";
            this.buttonSkanuj.Size = new System.Drawing.Size(75, 23);
            this.buttonSkanuj.TabIndex = 0;
            this.buttonSkanuj.Text = "Skanuj";
            this.buttonSkanuj.UseVisualStyleBackColor = true;
            this.buttonSkanuj.Click += new System.EventHandler(this.buttonSkanuj_Click);
            // 
            // labelStan
            // 
            this.labelStan.AutoSize = true;
            this.labelStan.Location = new System.Drawing.Point(22, 43);
            this.labelStan.Name = "labelStan";
            this.labelStan.Size = new System.Drawing.Size(34, 16);
            this.labelStan.TabIndex = 1;
            this.labelStan.Text = "Stan";
            // 
            // labelAdresIP
            // 
            this.labelAdresIP.AutoSize = true;
            this.labelAdresIP.Location = new System.Drawing.Point(71, 43);
            this.labelAdresIP.Name = "labelAdresIP";
            this.labelAdresIP.Size = new System.Drawing.Size(58, 16);
            this.labelAdresIP.TabIndex = 2;
            this.labelAdresIP.Text = "Adres IP";
            // 
            // labelAdresMAC
            // 
            this.labelAdresMAC.AutoSize = true;
            this.labelAdresMAC.Location = new System.Drawing.Point(248, 43);
            this.labelAdresMAC.Name = "labelAdresMAC";
            this.labelAdresMAC.Size = new System.Drawing.Size(75, 16);
            this.labelAdresMAC.TabIndex = 3;
            this.labelAdresMAC.Text = "Adres MAC";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Location = new System.Drawing.Point(16, 62);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(572, 435);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 509);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.labelAdresMAC);
            this.Controls.Add(this.labelAdresIP);
            this.Controls.Add(this.labelStan);
            this.Controls.Add(this.buttonSkanuj);
            this.Name = "Form1";
            this.Text = "WakeMeOnLan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSkanuj;
        private System.Windows.Forms.Label labelStan;
        private System.Windows.Forms.Label labelAdresIP;
        private System.Windows.Forms.Label labelAdresMAC;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}


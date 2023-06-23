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
            this.textBoxAdresIP = new System.Windows.Forms.TextBox();
            this.labelNazwaAdresIP = new System.Windows.Forms.Label();
            this.labelNazwaMaska = new System.Windows.Forms.Label();
            this.textBoxMaska = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSkanuj
            // 
            this.buttonSkanuj.Location = new System.Drawing.Point(16, 12);
            this.buttonSkanuj.Name = "buttonSkanuj";
            this.buttonSkanuj.Size = new System.Drawing.Size(128, 31);
            this.buttonSkanuj.TabIndex = 0;
            this.buttonSkanuj.Text = "Skanuj podsieć";
            this.buttonSkanuj.UseVisualStyleBackColor = true;
            this.buttonSkanuj.Click += new System.EventHandler(this.buttonSkanuj_Click);
            // 
            // labelStan
            // 
            this.labelStan.AutoSize = true;
            this.labelStan.Location = new System.Drawing.Point(19, 79);
            this.labelStan.Name = "labelStan";
            this.labelStan.Size = new System.Drawing.Size(34, 16);
            this.labelStan.TabIndex = 1;
            this.labelStan.Text = "Stan";
            // 
            // labelAdresIP
            // 
            this.labelAdresIP.AutoSize = true;
            this.labelAdresIP.Location = new System.Drawing.Point(68, 79);
            this.labelAdresIP.Name = "labelAdresIP";
            this.labelAdresIP.Size = new System.Drawing.Size(58, 16);
            this.labelAdresIP.TabIndex = 2;
            this.labelAdresIP.Text = "Adres IP";
            // 
            // labelAdresMAC
            // 
            this.labelAdresMAC.AutoSize = true;
            this.labelAdresMAC.Location = new System.Drawing.Point(245, 79);
            this.labelAdresMAC.Name = "labelAdresMAC";
            this.labelAdresMAC.Size = new System.Drawing.Size(75, 16);
            this.labelAdresMAC.TabIndex = 3;
            this.labelAdresMAC.Text = "Adres MAC";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Location = new System.Drawing.Point(16, 107);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(572, 390);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // textBoxAdresIP
            // 
            this.textBoxAdresIP.Location = new System.Drawing.Point(263, 12);
            this.textBoxAdresIP.Name = "textBoxAdresIP";
            this.textBoxAdresIP.Size = new System.Drawing.Size(133, 22);
            this.textBoxAdresIP.TabIndex = 5;
            // 
            // labelNazwaAdresIP
            // 
            this.labelNazwaAdresIP.AutoSize = true;
            this.labelNazwaAdresIP.Location = new System.Drawing.Point(200, 16);
            this.labelNazwaAdresIP.Name = "labelNazwaAdresIP";
            this.labelNazwaAdresIP.Size = new System.Drawing.Size(57, 16);
            this.labelNazwaAdresIP.TabIndex = 6;
            this.labelNazwaAdresIP.Text = "adres IP";
            // 
            // labelNazwaMaska
            // 
            this.labelNazwaMaska.AutoSize = true;
            this.labelNazwaMaska.Location = new System.Drawing.Point(402, 15);
            this.labelNazwaMaska.Name = "labelNazwaMaska";
            this.labelNazwaMaska.Size = new System.Drawing.Size(51, 16);
            this.labelNazwaMaska.TabIndex = 7;
            this.labelNazwaMaska.Text = " maska";
            // 
            // textBoxMaska
            // 
            this.textBoxMaska.Location = new System.Drawing.Point(455, 13);
            this.textBoxMaska.Name = "textBoxMaska";
            this.textBoxMaska.Size = new System.Drawing.Size(133, 22);
            this.textBoxMaska.TabIndex = 8;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(303, 47);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(17, 16);
            this.labelInfo.TabIndex = 9;
            this.labelInfo.Text = "\"\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 509);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxMaska);
            this.Controls.Add(this.labelNazwaMaska);
            this.Controls.Add(this.labelNazwaAdresIP);
            this.Controls.Add(this.textBoxAdresIP);
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
        private System.Windows.Forms.TextBox textBoxAdresIP;
        private System.Windows.Forms.Label labelNazwaAdresIP;
        private System.Windows.Forms.Label labelNazwaMaska;
        private System.Windows.Forms.TextBox textBoxMaska;
        private System.Windows.Forms.Label labelInfo;
    }
}


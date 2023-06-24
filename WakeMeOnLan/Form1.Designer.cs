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
            this.labelPorty = new System.Windows.Forms.Label();
            this.textBoxPorty = new System.Windows.Forms.TextBox();
            this.labelInfoPorty = new System.Windows.Forms.Label();
            this.labelInfoP = new System.Windows.Forms.Label();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSkanuj
            // 
            this.buttonSkanuj.Location = new System.Drawing.Point(16, 12);
            this.buttonSkanuj.Name = "buttonSkanuj";
            this.buttonSkanuj.Size = new System.Drawing.Size(128, 31);
            this.buttonSkanuj.TabIndex = 0;
            this.buttonSkanuj.Text = "SkanujPodsiec podsieć";
            this.buttonSkanuj.UseVisualStyleBackColor = true;
            this.buttonSkanuj.Click += new System.EventHandler(this.buttonSkanuj_Click);
            // 
            // labelStan
            // 
            this.labelStan.AutoSize = true;
            this.labelStan.Location = new System.Drawing.Point(20, 130);
            this.labelStan.Name = "labelStan";
            this.labelStan.Size = new System.Drawing.Size(34, 16);
            this.labelStan.TabIndex = 1;
            this.labelStan.Text = "Stan";
            // 
            // labelAdresIP
            // 
            this.labelAdresIP.AutoSize = true;
            this.labelAdresIP.Location = new System.Drawing.Point(69, 130);
            this.labelAdresIP.Name = "labelAdresIP";
            this.labelAdresIP.Size = new System.Drawing.Size(58, 16);
            this.labelAdresIP.TabIndex = 2;
            this.labelAdresIP.Text = "Adres IP";
            // 
            // labelAdresMAC
            // 
            this.labelAdresMAC.AutoSize = true;
            this.labelAdresMAC.Location = new System.Drawing.Point(246, 130);
            this.labelAdresMAC.Name = "labelAdresMAC";
            this.labelAdresMAC.Size = new System.Drawing.Size(75, 16);
            this.labelAdresMAC.TabIndex = 3;
            this.labelAdresMAC.Text = "Adres MAC";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Location = new System.Drawing.Point(16, 159);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(855, 472);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // textBoxAdresIP
            // 
            this.textBoxAdresIP.Location = new System.Drawing.Point(268, 49);
            this.textBoxAdresIP.Name = "textBoxAdresIP";
            this.textBoxAdresIP.Size = new System.Drawing.Size(133, 22);
            this.textBoxAdresIP.TabIndex = 5;
            // 
            // labelNazwaAdresIP
            // 
            this.labelNazwaAdresIP.AutoSize = true;
            this.labelNazwaAdresIP.Location = new System.Drawing.Point(205, 53);
            this.labelNazwaAdresIP.Name = "labelNazwaAdresIP";
            this.labelNazwaAdresIP.Size = new System.Drawing.Size(57, 16);
            this.labelNazwaAdresIP.TabIndex = 6;
            this.labelNazwaAdresIP.Text = "adres IP";
            // 
            // labelNazwaMaska
            // 
            this.labelNazwaMaska.AutoSize = true;
            this.labelNazwaMaska.Location = new System.Drawing.Point(407, 52);
            this.labelNazwaMaska.Name = "labelNazwaMaska";
            this.labelNazwaMaska.Size = new System.Drawing.Size(51, 16);
            this.labelNazwaMaska.TabIndex = 7;
            this.labelNazwaMaska.Text = " maska";
            // 
            // textBoxMaska
            // 
            this.textBoxMaska.Location = new System.Drawing.Point(460, 50);
            this.textBoxMaska.Name = "textBoxMaska";
            this.textBoxMaska.Size = new System.Drawing.Size(133, 22);
            this.textBoxMaska.TabIndex = 8;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(275, 86);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(17, 16);
            this.labelInfo.TabIndex = 9;
            this.labelInfo.Text = "\"\"";
            // 
            // labelPorty
            // 
            this.labelPorty.AutoSize = true;
            this.labelPorty.Location = new System.Drawing.Point(646, 55);
            this.labelPorty.Name = "labelPorty";
            this.labelPorty.Size = new System.Drawing.Size(37, 16);
            this.labelPorty.TabIndex = 10;
            this.labelPorty.Text = "porty";
            // 
            // textBoxPorty
            // 
            this.textBoxPorty.Location = new System.Drawing.Point(689, 53);
            this.textBoxPorty.Name = "textBoxPorty";
            this.textBoxPorty.Size = new System.Drawing.Size(133, 22);
            this.textBoxPorty.TabIndex = 11;
            // 
            // labelInfoPorty
            // 
            this.labelInfoPorty.AutoSize = true;
            this.labelInfoPorty.Location = new System.Drawing.Point(608, 78);
            this.labelInfoPorty.Name = "labelInfoPorty";
            this.labelInfoPorty.Size = new System.Drawing.Size(254, 32);
            this.labelInfoPorty.TabIndex = 12;
            this.labelInfoPorty.Text = "Jeżeli chcesz wprowadzić więcej\r\nnumerów portów oddzielaj je przecinkiem.\r\n";
            this.labelInfoPorty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInfoP
            // 
            this.labelInfoP.AutoSize = true;
            this.labelInfoP.Location = new System.Drawing.Point(635, 116);
            this.labelInfoP.Name = "labelInfoP";
            this.labelInfoP.Size = new System.Drawing.Size(17, 16);
            this.labelInfoP.TabIndex = 13;
            this.labelInfoP.Text = "\"\"";
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.Location = new System.Drawing.Point(150, 12);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(82, 31);
            this.buttonAnuluj.TabIndex = 14;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = true;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 643);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.labelInfoP);
            this.Controls.Add(this.labelInfoPorty);
            this.Controls.Add(this.textBoxPorty);
            this.Controls.Add(this.labelPorty);
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
        private System.Windows.Forms.Label labelPorty;
        private System.Windows.Forms.TextBox textBoxPorty;
        private System.Windows.Forms.Label labelInfoPorty;
        private System.Windows.Forms.Label labelInfoP;
        private System.Windows.Forms.Button buttonAnuluj;
    }
}


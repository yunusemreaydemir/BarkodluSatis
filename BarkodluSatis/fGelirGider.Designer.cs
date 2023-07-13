namespace BarkodluSatis
{
    partial class fGelirGider
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
            this.lGelirGider = new BarkodluSatis.lStandart();
            this.cmbOdemeTuru = new System.Windows.Forms.ComboBox();
            this.lStandart2 = new BarkodluSatis.lStandart();
            this.tNakit = new BarkodluSatis.tNumeric();
            this.tKart = new BarkodluSatis.tNumeric();
            this.lStandart3 = new BarkodluSatis.lStandart();
            this.lStandart4 = new BarkodluSatis.lStandart();
            this.tAciklama = new BarkodluSatis.tStandart();
            this.lStandart5 = new BarkodluSatis.lStandart();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.lStandart6 = new BarkodluSatis.lStandart();
            this.bEkle = new BarkodluSatis.bStandart();
            this.SuspendLayout();
            // 
            // lGelirGider
            // 
            this.lGelirGider.AutoSize = true;
            this.lGelirGider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lGelirGider.ForeColor = System.Drawing.Color.DarkBlue;
            this.lGelirGider.Location = new System.Drawing.Point(26, 17);
            this.lGelirGider.Name = "lGelirGider";
            this.lGelirGider.Size = new System.Drawing.Size(129, 25);
            this.lGelirGider.TabIndex = 0;
            this.lGelirGider.Text = "GELİRGİDER";
            // 
            // cmbOdemeTuru
            // 
            this.cmbOdemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOdemeTuru.FormattingEnabled = true;
            this.cmbOdemeTuru.Items.AddRange(new object[] {
            "NAKİT ",
            "KART",
            "KART-NAKİT"});
            this.cmbOdemeTuru.Location = new System.Drawing.Point(31, 96);
            this.cmbOdemeTuru.Name = "cmbOdemeTuru";
            this.cmbOdemeTuru.Size = new System.Drawing.Size(295, 33);
            this.cmbOdemeTuru.TabIndex = 2;
            this.cmbOdemeTuru.SelectedIndexChanged += new System.EventHandler(this.cmbOdemeTuru_SelectedIndexChanged);
            // 
            // lStandart2
            // 
            this.lStandart2.AutoSize = true;
            this.lStandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart2.ForeColor = System.Drawing.Color.DarkBlue;
            this.lStandart2.Location = new System.Drawing.Point(26, 68);
            this.lStandart2.Name = "lStandart2";
            this.lStandart2.Size = new System.Drawing.Size(123, 25);
            this.lStandart2.TabIndex = 3;
            this.lStandart2.Text = "Ödeme Türü";
            // 
            // tNakit
            // 
            this.tNakit.BackColor = System.Drawing.Color.White;
            this.tNakit.Enabled = false;
            this.tNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tNakit.Location = new System.Drawing.Point(31, 175);
            this.tNakit.Name = "tNakit";
            this.tNakit.Size = new System.Drawing.Size(139, 30);
            this.tNakit.TabIndex = 4;
            this.tNakit.Text = "0";
            this.tNakit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tKart
            // 
            this.tKart.BackColor = System.Drawing.Color.White;
            this.tKart.Enabled = false;
            this.tKart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tKart.Location = new System.Drawing.Point(187, 175);
            this.tKart.Name = "tKart";
            this.tKart.Size = new System.Drawing.Size(139, 30);
            this.tKart.TabIndex = 5;
            this.tKart.Text = "0";
            this.tKart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lStandart3
            // 
            this.lStandart3.AutoSize = true;
            this.lStandart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart3.ForeColor = System.Drawing.Color.DarkBlue;
            this.lStandart3.Location = new System.Drawing.Point(26, 147);
            this.lStandart3.Name = "lStandart3";
            this.lStandart3.Size = new System.Drawing.Size(56, 25);
            this.lStandart3.TabIndex = 6;
            this.lStandart3.Text = "Nakit";
            // 
            // lStandart4
            // 
            this.lStandart4.AutoSize = true;
            this.lStandart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart4.ForeColor = System.Drawing.Color.DarkBlue;
            this.lStandart4.Location = new System.Drawing.Point(171, 147);
            this.lStandart4.Name = "lStandart4";
            this.lStandart4.Size = new System.Drawing.Size(48, 25);
            this.lStandart4.TabIndex = 7;
            this.lStandart4.Text = "Kart";
            // 
            // tAciklama
            // 
            this.tAciklama.BackColor = System.Drawing.Color.White;
            this.tAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tAciklama.Location = new System.Drawing.Point(31, 253);
            this.tAciklama.Multiline = true;
            this.tAciklama.Name = "tAciklama";
            this.tAciklama.Size = new System.Drawing.Size(295, 100);
            this.tAciklama.TabIndex = 8;
            // 
            // lStandart5
            // 
            this.lStandart5.AutoSize = true;
            this.lStandart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart5.ForeColor = System.Drawing.Color.DarkBlue;
            this.lStandart5.Location = new System.Drawing.Point(26, 225);
            this.lStandart5.Name = "lStandart5";
            this.lStandart5.Size = new System.Drawing.Size(92, 25);
            this.lStandart5.TabIndex = 9;
            this.lStandart5.Text = "Açıklama";
            // 
            // dtTarih
            // 
            this.dtTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih.Location = new System.Drawing.Point(31, 398);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(295, 30);
            this.dtTarih.TabIndex = 10;
            // 
            // lStandart6
            // 
            this.lStandart6.AutoSize = true;
            this.lStandart6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart6.ForeColor = System.Drawing.Color.DarkBlue;
            this.lStandart6.Location = new System.Drawing.Point(26, 370);
            this.lStandart6.Name = "lStandart6";
            this.lStandart6.Size = new System.Drawing.Size(57, 25);
            this.lStandart6.TabIndex = 11;
            this.lStandart6.Text = "Tarih";
            // 
            // bEkle
            // 
            this.bEkle.BackColor = System.Drawing.Color.Crimson;
            this.bEkle.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.bEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bEkle.ForeColor = System.Drawing.Color.White;
            this.bEkle.Image = global::BarkodluSatis.Properties.Resources.Ekle242;
            this.bEkle.Location = new System.Drawing.Point(199, 445);
            this.bEkle.Margin = new System.Windows.Forms.Padding(1);
            this.bEkle.Name = "bEkle";
            this.bEkle.Size = new System.Drawing.Size(127, 63);
            this.bEkle.TabIndex = 12;
            this.bEkle.Text = "Ekle";
            this.bEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bEkle.UseVisualStyleBackColor = false;
            this.bEkle.Click += new System.EventHandler(this.bEkle_Click);
            // 
            // fGelirGider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(358, 536);
            this.Controls.Add(this.bEkle);
            this.Controls.Add(this.lStandart6);
            this.Controls.Add(this.dtTarih);
            this.Controls.Add(this.lStandart5);
            this.Controls.Add(this.tAciklama);
            this.Controls.Add(this.lStandart4);
            this.Controls.Add(this.lStandart3);
            this.Controls.Add(this.tKart);
            this.Controls.Add(this.tNakit);
            this.Controls.Add(this.lStandart2);
            this.Controls.Add(this.cmbOdemeTuru);
            this.Controls.Add(this.lGelirGider);
            this.MaximumSize = new System.Drawing.Size(376, 583);
            this.MinimumSize = new System.Drawing.Size(376, 583);
            this.Name = "fGelirGider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GELİR-GİDER İŞLEMLERİ";
            this.Load += new System.EventHandler(this.fGelirGider_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lStandart lGelirGider;
        private System.Windows.Forms.ComboBox cmbOdemeTuru;
        private lStandart lStandart2;
        private tNumeric tNakit;
        private tNumeric tKart;
        private lStandart lStandart3;
        private lStandart lStandart4;
        private tStandart tAciklama;
        private lStandart lStandart5;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private lStandart lStandart6;
        private bStandart bEkle;
    }
}
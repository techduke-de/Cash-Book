namespace Cash_Book
{
    partial class BuchungWindow
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
            this.label5 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.cb_kategorie = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_betrag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_datum = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_beschreibung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "€";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(302, 147);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(120, 42);
            this.btn_ok.TabIndex = 18;
            this.btn_ok.Text = "eintragen";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cb_kategorie
            // 
            this.cb_kategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_kategorie.FormattingEnabled = true;
            this.cb_kategorie.Location = new System.Drawing.Point(156, 96);
            this.cb_kategorie.Name = "cb_kategorie";
            this.cb_kategorie.Size = new System.Drawing.Size(266, 28);
            this.cb_kategorie.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kategorie:";
            // 
            // tb_betrag
            // 
            this.tb_betrag.Location = new System.Drawing.Point(79, 163);
            this.tb_betrag.Name = "tb_betrag";
            this.tb_betrag.Size = new System.Drawing.Size(125, 26);
            this.tb_betrag.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Betrag:";
            // 
            // dtp_datum
            // 
            this.dtp_datum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_datum.Location = new System.Drawing.Point(16, 98);
            this.dtp_datum.Name = "dtp_datum";
            this.dtp_datum.Size = new System.Drawing.Size(107, 26);
            this.dtp_datum.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Datum:";
            // 
            // tb_beschreibung
            // 
            this.tb_beschreibung.Location = new System.Drawing.Point(16, 32);
            this.tb_beschreibung.Name = "tb_beschreibung";
            this.tb_beschreibung.Size = new System.Drawing.Size(406, 26);
            this.tb_beschreibung.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Beschreibung:";
            // 
            // BuchungWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 210);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.cb_kategorie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_betrag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_datum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_beschreibung);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BuchungWindow";
            this.Text = "Neue Buchung hinzufügen";
            this.Load += new System.EventHandler(this.BuchungWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.ComboBox cb_kategorie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_betrag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_datum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_beschreibung;
        private System.Windows.Forms.Label label1;
    }
}
namespace Cash_Book
{
    partial class NeueDatenbank
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
            this.tb_datenbankname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_abbrechen = new System.Windows.Forms.Button();
            this.btn_datenbankanlegen = new System.Windows.Forms.Button();
            this.gB_dbeinstellungen = new System.Windows.Forms.GroupBox();
            this.tb_passwortrepeat = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_passwort = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_suchen = new System.Windows.Forms.Button();
            this.tb_pfad = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gB_dbeinstellungen.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_datenbankname
            // 
            this.tb_datenbankname.Location = new System.Drawing.Point(12, 41);
            this.tb_datenbankname.Name = "tb_datenbankname";
            this.tb_datenbankname.Size = new System.Drawing.Size(228, 26);
            this.tb_datenbankname.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Datenbank Name:";
            // 
            // btn_abbrechen
            // 
            this.btn_abbrechen.Location = new System.Drawing.Point(141, 226);
            this.btn_abbrechen.Name = "btn_abbrechen";
            this.btn_abbrechen.Size = new System.Drawing.Size(99, 34);
            this.btn_abbrechen.TabIndex = 13;
            this.btn_abbrechen.Text = "abbrechen";
            this.btn_abbrechen.UseVisualStyleBackColor = true;
            this.btn_abbrechen.Click += new System.EventHandler(this.btn_abbrechen_Click);
            // 
            // btn_datenbankanlegen
            // 
            this.btn_datenbankanlegen.Location = new System.Drawing.Point(248, 226);
            this.btn_datenbankanlegen.Name = "btn_datenbankanlegen";
            this.btn_datenbankanlegen.Size = new System.Drawing.Size(174, 34);
            this.btn_datenbankanlegen.TabIndex = 12;
            this.btn_datenbankanlegen.Text = "Datenbank anlegen";
            this.btn_datenbankanlegen.UseVisualStyleBackColor = true;
            this.btn_datenbankanlegen.Click += new System.EventHandler(this.btn_datenbankanlegen_Click);
            // 
            // gB_dbeinstellungen
            // 
            this.gB_dbeinstellungen.Controls.Add(this.tb_passwortrepeat);
            this.gB_dbeinstellungen.Controls.Add(this.label3);
            this.gB_dbeinstellungen.Controls.Add(this.tb_passwort);
            this.gB_dbeinstellungen.Controls.Add(this.label2);
            this.gB_dbeinstellungen.Location = new System.Drawing.Point(12, 125);
            this.gB_dbeinstellungen.Name = "gB_dbeinstellungen";
            this.gB_dbeinstellungen.Size = new System.Drawing.Size(410, 95);
            this.gB_dbeinstellungen.TabIndex = 11;
            this.gB_dbeinstellungen.TabStop = false;
            this.gB_dbeinstellungen.Text = "Datenbank Einstellungen";
            // 
            // tb_passwortrepeat
            // 
            this.tb_passwortrepeat.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_passwortrepeat.Location = new System.Drawing.Point(225, 51);
            this.tb_passwortrepeat.Name = "tb_passwortrepeat";
            this.tb_passwortrepeat.PasswordChar = '*';
            this.tb_passwortrepeat.Size = new System.Drawing.Size(179, 30);
            this.tb_passwortrepeat.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Passwort wiederholen:";
            // 
            // tb_passwort
            // 
            this.tb_passwort.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tb_passwort.Location = new System.Drawing.Point(10, 51);
            this.tb_passwort.Name = "tb_passwort";
            this.tb_passwort.PasswordChar = '*';
            this.tb_passwort.Size = new System.Drawing.Size(179, 30);
            this.tb_passwort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Passwort:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Datenbank Pfad:";
            // 
            // btn_suchen
            // 
            this.btn_suchen.Location = new System.Drawing.Point(351, 93);
            this.btn_suchen.Name = "btn_suchen";
            this.btn_suchen.Size = new System.Drawing.Size(75, 26);
            this.btn_suchen.TabIndex = 9;
            this.btn_suchen.Text = "suchen";
            this.btn_suchen.UseVisualStyleBackColor = true;
            this.btn_suchen.Click += new System.EventHandler(this.btn_suchen_Click);
            // 
            // tb_pfad
            // 
            this.tb_pfad.Enabled = false;
            this.tb_pfad.Location = new System.Drawing.Point(12, 93);
            this.tb_pfad.Name = "tb_pfad";
            this.tb_pfad.Size = new System.Drawing.Size(333, 26);
            this.tb_pfad.TabIndex = 8;
            // 
            // NeueDatenbank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 279);
            this.Controls.Add(this.tb_datenbankname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_abbrechen);
            this.Controls.Add(this.btn_datenbankanlegen);
            this.Controls.Add(this.gB_dbeinstellungen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_suchen);
            this.Controls.Add(this.tb_pfad);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NeueDatenbank";
            this.Text = "Neue Datenbank erstellen";
            this.gB_dbeinstellungen.ResumeLayout(false);
            this.gB_dbeinstellungen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_datenbankname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_abbrechen;
        private System.Windows.Forms.Button btn_datenbankanlegen;
        private System.Windows.Forms.GroupBox gB_dbeinstellungen;
        private System.Windows.Forms.MaskedTextBox tb_passwortrepeat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tb_passwort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_suchen;
        private System.Windows.Forms.TextBox tb_pfad;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
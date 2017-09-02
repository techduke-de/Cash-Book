namespace Cash_Book
{
    partial class EinstellungenWindow
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
            this.GB_Kategorie = new System.Windows.Forms.GroupBox();
            this.btn_hinzufuegen = new System.Windows.Forms.Button();
            this.LBL_Name = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btn_loeschen = new System.Windows.Forms.LinkLabel();
            this.cb_kategorieListe = new System.Windows.Forms.CheckedListBox();
            this.GB_Kategorie.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_Kategorie
            // 
            this.GB_Kategorie.Controls.Add(this.btn_hinzufuegen);
            this.GB_Kategorie.Controls.Add(this.LBL_Name);
            this.GB_Kategorie.Controls.Add(this.tb_name);
            this.GB_Kategorie.Controls.Add(this.btn_loeschen);
            this.GB_Kategorie.Controls.Add(this.cb_kategorieListe);
            this.GB_Kategorie.Location = new System.Drawing.Point(12, 12);
            this.GB_Kategorie.Name = "GB_Kategorie";
            this.GB_Kategorie.Size = new System.Drawing.Size(402, 378);
            this.GB_Kategorie.TabIndex = 1;
            this.GB_Kategorie.TabStop = false;
            this.GB_Kategorie.Text = "Kategorie hinzufügen / löschen";
            // 
            // btn_hinzufuegen
            // 
            this.btn_hinzufuegen.Location = new System.Drawing.Point(251, 194);
            this.btn_hinzufuegen.Name = "btn_hinzufuegen";
            this.btn_hinzufuegen.Size = new System.Drawing.Size(145, 29);
            this.btn_hinzufuegen.TabIndex = 4;
            this.btn_hinzufuegen.Text = "hinzufügen";
            this.btn_hinzufuegen.UseVisualStyleBackColor = true;
            this.btn_hinzufuegen.Click += new System.EventHandler(this.btn_hinzufuegen_Click);
            // 
            // LBL_Name
            // 
            this.LBL_Name.AutoSize = true;
            this.LBL_Name.Location = new System.Drawing.Point(251, 139);
            this.LBL_Name.Name = "LBL_Name";
            this.LBL_Name.Size = new System.Drawing.Size(55, 20);
            this.LBL_Name.TabIndex = 3;
            this.LBL_Name.Text = "Name:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(251, 162);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(145, 26);
            this.tb_name.TabIndex = 2;
            // 
            // btn_loeschen
            // 
            this.btn_loeschen.AutoSize = true;
            this.btn_loeschen.Location = new System.Drawing.Point(6, 347);
            this.btn_loeschen.Name = "btn_loeschen";
            this.btn_loeschen.Size = new System.Drawing.Size(134, 20);
            this.btn_loeschen.TabIndex = 1;
            this.btn_loeschen.TabStop = true;
            this.btn_loeschen.Text = "markierte löschen";
            this.btn_loeschen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btn_loeschen_LinkClicked);
            // 
            // cb_kategorieListe
            // 
            this.cb_kategorieListe.FormattingEnabled = true;
            this.cb_kategorieListe.Location = new System.Drawing.Point(6, 25);
            this.cb_kategorieListe.Name = "cb_kategorieListe";
            this.cb_kategorieListe.Size = new System.Drawing.Size(239, 319);
            this.cb_kategorieListe.TabIndex = 0;
            // 
            // EinstellungenWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 402);
            this.Controls.Add(this.GB_Kategorie);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EinstellungenWindow";
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.EinstellungenWindow_Load);
            this.GB_Kategorie.ResumeLayout(false);
            this.GB_Kategorie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Kategorie;
        private System.Windows.Forms.Button btn_hinzufuegen;
        private System.Windows.Forms.Label LBL_Name;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.LinkLabel btn_loeschen;
        private System.Windows.Forms.CheckedListBox cb_kategorieListe;
    }
}
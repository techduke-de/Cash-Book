namespace Cash_Book
{
    partial class PasswortWindow
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
            this.tb_passwort = new System.Windows.Forms.MaskedTextBox();
            this.btn_anmelden = new System.Windows.Forms.Button();
            this.lbl_passwort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_passwort
            // 
            this.tb_passwort.Location = new System.Drawing.Point(14, 37);
            this.tb_passwort.Name = "tb_passwort";
            this.tb_passwort.PasswordChar = '*';
            this.tb_passwort.Size = new System.Drawing.Size(210, 26);
            this.tb_passwort.TabIndex = 6;
            // 
            // btn_anmelden
            // 
            this.btn_anmelden.Location = new System.Drawing.Point(116, 68);
            this.btn_anmelden.Name = "btn_anmelden";
            this.btn_anmelden.Size = new System.Drawing.Size(108, 34);
            this.btn_anmelden.TabIndex = 5;
            this.btn_anmelden.Text = "anmelden";
            this.btn_anmelden.UseVisualStyleBackColor = true;
            this.btn_anmelden.Click += new System.EventHandler(this.btn_anmelden_Click);
            // 
            // lbl_passwort
            // 
            this.lbl_passwort.AutoSize = true;
            this.lbl_passwort.Location = new System.Drawing.Point(10, 13);
            this.lbl_passwort.Name = "lbl_passwort";
            this.lbl_passwort.Size = new System.Drawing.Size(78, 20);
            this.lbl_passwort.TabIndex = 4;
            this.lbl_passwort.Text = "Passwort:";
            // 
            // PasswortWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 115);
            this.Controls.Add(this.tb_passwort);
            this.Controls.Add(this.btn_anmelden);
            this.Controls.Add(this.lbl_passwort);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PasswortWindow";
            this.Text = "Passwort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tb_passwort;
        private System.Windows.Forms.Button btn_anmelden;
        private System.Windows.Forms.Label lbl_passwort;
    }
}
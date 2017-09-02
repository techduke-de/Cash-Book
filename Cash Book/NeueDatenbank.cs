using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cash_Book
{
    public partial class NeueDatenbank : Form
    {
        public NeueDatenbank()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Datenbank Handler Klasse initialisieren
        /// </summary>
        DatabaseClass dbClass = new DatabaseClass();



        /// <summary>
        /// Funktion wird aufgerufen, wenn der Button abbrechen gecklickt wird
        /// Das Fenster wird daraufhin geschlossen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_abbrechen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// Funktion wird aufgerufen, wenn der Button Datenbank anlegen geklickt wird
        /// Validierung der Benutzereingaben und erstellen einer SQLite Datenbank.
        /// Datenbankpfad und Passwort werden in den Programmeinstellungen gespeichert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_datenbankanlegen_Click(object sender, EventArgs e)
        {
            if(File.Exists(Properties.Settings.Default.DB_Pfad) == false)
            {
                if (tb_datenbankname.Text.Length > 4)
                {
                    if (tb_pfad.Text.Length > 1)
                    {
                        if (tb_passwort.Text.Length > 5 && tb_passwort.Text == tb_passwortrepeat.Text)
                        {
                            Properties.Settings.Default.DB_Pfad = tb_pfad.Text + @"\" + tb_datenbankname.Text + ".db";
                            Properties.Settings.Default.DB_Passwort = tb_passwort.Text;

                            dbClass.SetPassword(Properties.Settings.Default.DB_Passwort);
                            dbClass.SetPfad(Properties.Settings.Default.DB_Pfad);

                            dbClass.CreateTables(dbClass.DefineConnection());
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Das Passwort muss mindestens 6 Zeichen lang sein.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else { MessageBox.Show("Es wurde kein Speicherort für die Datenbank angegeben.", "Hinweis!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Der Datenbank Name muss mindestens 4 Zeichen lang sein.", "Hinweis!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else
            {
                MessageBox.Show("Die Datenbank existiert bereits.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Funktion wird aufgerufen, wenn der Button suchen angeklickt wird.
        /// FolderBrowseDialog wird geöffnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_suchen_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tb_pfad.Text = folderBrowserDialog1.SelectedPath.ToString();
            }
        }
    }
}

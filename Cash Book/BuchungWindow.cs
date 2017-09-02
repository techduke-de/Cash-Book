using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cash_Book
{
    public partial class BuchungWindow : Form
    {
        public BuchungWindow()
        {
            InitializeComponent();
        }

        public bool isNew = false;
        public string ID = "";

        /// <summary>
        /// Datenbank Handler Klasse initialisieren
        /// </summary>
        DatabaseClass dbclass = new DatabaseClass();

        /// <summary>
        /// Funktion wird beim Laden des Fensters aufgerufen.
        /// Befüllt die ComboBox Kategorie mit Werten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuchungWindow_Load(object sender, EventArgs e)
        {
            LoadCategoryToComboBox();
        }

        /// <summary>
        /// Lädt alle Kategorien aus der Datenbank und schreibt diese in die ComboBox
        /// </summary>
        private void LoadCategoryToComboBox()
        {
            cb_kategorie.Items.Clear();

            dbclass.SetPassword(Properties.Settings.Default.DB_Passwort);
            dbclass.SetPfad(Properties.Settings.Default.DB_Pfad);

            DataTable dTable = dbclass.Select_AllEntrys_Kategorie(dbclass.DefineConnection());
            foreach(DataRow row in dTable.Rows)
            {
                cb_kategorie.Items.Add(row[0].ToString());
            }
        }

        /// <summary>
        /// Funktion wird aufgerufen sobald auf den Button eintragen geklickt wird
        /// Validiert die Eingaben durch den Benutzer und schreibt den Wert aus dem DateTimePicker 
        /// zu Text um und ruft die Funktion zum Eintragen in die Datenbank auf.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(tb_beschreibung.Text.Length >= 4) {
                if(cb_kategorie.SelectedIndex > -1)
                {
                    if(tb_betrag.Text.Length > 0)
                    {
                        try {
                            Convert.ToDouble(tb_betrag.Text);
                        }
                        catch(Exception ex) { MessageBox.Show("Der Betrag ist nicht gültig."); return; }

                        if (isNew == true)
                        {
                            string Betrag = tb_betrag.Text.Replace(",", ".");
                            string Monat = "";
                            switch (dtp_datum.Value.Month)
                            {
                                case 1: Monat = "Januar"; break;
                                case 2: Monat = "Februar"; break;
                                case 3: Monat = "Maerz"; break;
                                case 4: Monat = "April"; break;
                                case 5: Monat = "Mai"; break;
                                case 6: Monat = "Juni"; break;
                                case 7: Monat = "Juli"; break;
                                case 8: Monat = "August"; break;
                                case 9: Monat = "September"; break;
                                case 10: Monat = "Oktober"; break;
                                case 11: Monat = "November"; break;
                                case 12: Monat = "Dezember"; break;
                            }

                            if (dbclass.Insert_Entry_Monate(dbclass.DefineConnection(), tb_beschreibung.Text,
                                cb_kategorie.Text,
                                dtp_datum.Text,
                                Betrag,
                                Monat) == true)
                            {
                                dbclass.Update_Kategorie_Value(dbclass.DefineConnection(), cb_kategorie.Text, Convert.ToDouble(Betrag.Replace(".", ",")));

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        else
                        {
                            //EDIT Entry
                        }

                    }
                    else
                    {
                        MessageBox.Show("Es wurde kein Betrag eingegeben.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Es muss eine Kategorie gewählt werden.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else { MessageBox.Show("Die Bezeichnung muss min. 4 Zeichen lang sein.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            
        }
    }
}

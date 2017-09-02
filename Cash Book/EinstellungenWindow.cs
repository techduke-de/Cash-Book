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
    public partial class EinstellungenWindow : Form
    {
        public EinstellungenWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Datenbank Handler Klasse initialisieren
        /// </summary>
        DatabaseClass dbclass = new DatabaseClass();


        /// <summary>
        /// Funktion wird beim Start des Fensters aufgerufen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EinstellungenWindow_Load(object sender, EventArgs e)
        {
            LoadContent();
        }

        /// <summary>
        /// Lädt alle Kategorien aus der Datenbank in die ComboBox
        /// </summary>
        private void LoadContent()
        {
            cb_kategorieListe.Items.Clear();

            dbclass.SetPassword(Properties.Settings.Default.DB_Passwort);
            dbclass.SetPfad(Properties.Settings.Default.DB_Pfad);

            DataTable dTable = dbclass.Select_AllEntrys_Kategorie(dbclass.DefineConnection());
            foreach (DataRow row in dTable.Rows)
            {
                cb_kategorieListe.Items.Add(row[0].ToString(), false);
            }
        }

        /// <summary>
        /// Funktion wird aufgerufen, wenn der Button hinzufügen geklickt wird
        /// Validierung der Eingaben und eintragen in die Datenbank.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_hinzufuegen_Click(object sender, EventArgs e)
        {
            if(tb_name.Text.Length >= 4)
            {
                if(dbclass.Insert_Entry_Kategorie(dbclass.DefineConnection(), tb_name.Text) == true)
                {
                    tb_name.Clear();
                    LoadContent();
                }
            }
        }

        /// <summary>
        /// Funktion wird aufgerufen, wenn der Button löschen geklickt wird.
        /// Markierte Kategorien werden aus der Datenbank gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loeschen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach(int indexChecked in cb_kategorieListe.CheckedIndices)
            {
                dbclass.Delete_Entry_Kategorie(dbclass.DefineConnection(), cb_kategorieListe.Items[indexChecked].ToString());
            }

            LoadContent();
        }
    }
}

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
using System.Windows.Forms.DataVisualization.Charting;

namespace Cash_Book
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Datenbank Handler Klasse initialisieren
        /// </summary>
        DatabaseClass dbClass = new DatabaseClass();

        /// <summary>
        /// Funktion wird beim Laden des Hauptfensters aufgerufen.
        /// Alle Steuerelemente die ausschließlich nach der Anmeldung verfügbar sind werden deaktiviert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            tc_main.Enabled = false;
            btn_neueBuchung.Enabled = false;
            btn_einstellungen.Enabled = false;
            chart_uebersicht.Visible = false;
        }



        /// <summary>
        /// Funktion wird beim Klick auf den Button Neue Datenbank aufgerufen.
        /// Dabei wird das Eingabefenster zur Erstellung einer neuen Datenbank als Dialog aufgerufen.
        /// Gibt das Fenster als Dialog Result ein OK zurück werden die Steuerelemente aktiviert und der Inhalt wird geladen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dbneu_Click(object sender, EventArgs e)
        {
            NeueDatenbank neuForm = new NeueDatenbank();
            neuForm.StartPosition = FormStartPosition.CenterParent;

            if (neuForm.ShowDialog() == DialogResult.OK)
            {
                LoadDataAfterLogin();
                tc_main.Enabled = true;
            }
        }

        /// <summary>
        /// Funktion wird beim Klick auf den Button Datenbank öffnen aufgerufen. Dabei wird das OpenFileDialog aufgerufen.
        /// Nach Eingabe des Passworts werden die Steuerelemente aktiviert und die Inhalte geladen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dboeffnen_Click(object sender, EventArgs e)
        {
            openfiledialog_opendb.Filter = "Datenbank (*.db)|*.db";
            openfiledialog_opendb.Multiselect = false;
            openfiledialog_opendb.FileName = "";
            if (openfiledialog_opendb.ShowDialog() == DialogResult.OK)
            {
                if (openfiledialog_opendb.CheckFileExists == true)
                {
                    Properties.Settings.Default.DB_Pfad = openfiledialog_opendb.FileName.ToString();

                    if (File.Exists(Properties.Settings.Default.DB_Pfad))
                    {
                        PasswortWindow pwd_form = new PasswortWindow();
                        pwd_form.StartPosition = FormStartPosition.CenterParent;
                        if (pwd_form.ShowDialog() == DialogResult.OK)
                        {
                            DatabaseClass dbTool = new DatabaseClass();

                            dbTool.SetPfad(openfiledialog_opendb.FileName);
                            dbTool.SetPassword(pwd_form.pwd);

                            if(dbTool.TestConnection() == true)
                            {
                                if (dbTool.DefineConnection() != null)
                                {
                                    Properties.Settings.Default.DB_Passwort = pwd_form.pwd;
                                    LoadDataAfterLogin();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Passwort stimmt nicht.");
                            }
                           
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Funktion wird beim Klick auf den Button Neue Buchung aufgerufen.
        /// Dabei wird das Fenster BuchungWindow aufgerufen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_neueBuchung_Click(object sender, EventArgs e)
        {
            BuchungWindow buchung = new BuchungWindow
            {
                StartPosition = FormStartPosition.CenterParent,
                isNew = true
            };

            DialogResult result = buchung.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadDataAfterLogin();
            }
        }

        /// <summary>
        /// Funktion wird beim Klick auf den Button Einstellungen aufgerufen.
        /// Nach dem Beenden des Fensters wird die Kategorie Übersicht neu geladen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_einstellungen_Click(object sender, EventArgs e)
        {
            EinstellungenWindow einstellungen = new EinstellungenWindow
            {
                StartPosition = FormStartPosition.CenterParent
            };
            einstellungen.ShowDialog();

            CalcAndDisplayKategorie();
        }

        /// <summary>
        /// Funktion wird beim Klick auf den Button löschen aufgerufen.
        /// Es wird analysiert auf welcher Tabelle das Ereignis ausgelöst wurde.
        /// Der markierte Eintrag wird ausgelesen und gelöscht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loeschen_Click(object sender, EventArgs e)
        {
            string ID = "";

            switch (tc_main.SelectedTab.Text.ToString())
            {
                case "Januar":
                    ID = lv_januar.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "Januar") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_januar.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_januar.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "Februar":
                    ID = lv_februar.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "Februar") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_februar.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_februar.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "März":
                    ID = lv_maerz.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "Maerz") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_maerz.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_maerz.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "April":
                    ID = lv_april.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "April") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_april.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_april.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "Mai":
                    ID = lv_mai.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "Mai") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_mai.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_mai.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "Juni":
                    ID = lv_juni.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "Juni") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_juni.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_juni.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "Juli":
                    ID = lv_juli.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "Juli") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_juli.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_juli.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "August":
                    ID = lv_august.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "August") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_august.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_august.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "September":
                    ID = lv_september.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "September") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_september.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_september.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "Oktober":
                    ID = lv_oktober.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "Oktober") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_oktober.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_oktober.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "November":
                    ID = lv_november.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "November") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_november.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_november.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;

                case "Dezember":
                    ID = lv_dezember.SelectedItems[0].Text.ToString();
                    if (dbClass.Delete_Entry_Monate(dbClass.DefineConnection(), ID, "Dezember") != true) { return; }
                    dbClass.Update_Kategorie_Value(dbClass.DefineConnection(), lv_dezember.SelectedItems[0].SubItems[4].Text, (Convert.ToDouble(lv_dezember.SelectedItems[0].SubItems[3].Text.TrimEnd('€')) * -1.0));
                    break;
            }


            LoadDataAfterLogin(); //aktualisiert die anzuzeigenden Werte nach dem löschen

        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_januar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_februar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_maerz_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_april_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_mai_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_juni_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_juli_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_august_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_september_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_oktober_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_november_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// Zeigt das Menü zum löschen von Elementen an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_dezember_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_months.Show(Control.MousePosition);
            }
        }



        /// <summary>
        /// Lädt alle Werte in die Benutzerelemente
        /// Alle Buchungen werden in die Tabellen geladen.
        /// Bilanz wird berechnet.
        /// Übersichts-Chart wird generiert.
        /// </summary>
        private void LoadDataAfterLogin()
        {
            tc_main.Enabled = true;
            chart_uebersicht.Visible = true;
            btn_neueBuchung.Enabled = true;
            btn_einstellungen.Enabled = true;

            LoadAndDisplayBuchungen();
            CalcAndDisplayBilanz(); //muss nach der Funktion LoadAndDisplayBuchungen ausgeführt werden!
            CalcAndDisplayKategorie();
            DrawChart_Bilanz();
        }

        /// <summary>
        /// Lädt alle Buchungen aus der Datenbank und schreibt diese in die entsprechende Tabelle
        /// </summary>
        private void LoadAndDisplayBuchungen()
        {
            dbClass.SetPassword(Properties.Settings.Default.DB_Passwort);
            dbClass.SetPfad(Properties.Settings.Default.DB_Pfad);


            /*Monatsübersicht laden*/

            //Januar
            DataTable dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "Januar");
            lv_januar.Items.Clear();

            //falls ein Fehler aufgetreten ist.
            if(dTable == null) { return; }

            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_januar.Items.Add(items);
            }


            //Februar
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "Februar");
            lv_februar.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_februar.Items.Add(items);
            }


            //März
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "Maerz");
            lv_maerz.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_maerz.Items.Add(items);
            }


            //April
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "April");
            lv_april.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_april.Items.Add(items);
            }


            //Mai
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "Mai");
            lv_mai.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_mai.Items.Add(items);
            }


            //Juni
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "Juni");
            lv_juni.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_juni.Items.Add(items);
            }


            //Juli
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "Juli");
            lv_juli.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_juli.Items.Add(items);
            }


            //August
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "August");
            lv_august.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_august.Items.Add(items);
            }


            //September
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "September");
            lv_september.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_september.Items.Add(items);
            }


            //Oktober
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "Oktober");
            lv_oktober.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_oktober.Items.Add(items);
            }


            //November
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "November");
            lv_november.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_november.Items.Add(items);
            }


            //Dezember
            dTable = dbClass.Select_AllEntrys_Monate(dbClass.DefineConnection(), "Dezember");
            lv_dezember.Items.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow row = dTable.Rows[i];
                ListViewItem items = new ListViewItem(row["ID"].ToString());
                items.SubItems.Add(row["Datum"].ToString());
                items.SubItems.Add(row["Bezeichnung"].ToString());
                items.SubItems.Add(row["Wert"].ToString() + "€");
                items.SubItems.Add(row["Kategorie"].ToString());
                items.UseItemStyleForSubItems = false;
                if (Convert.ToDouble(row["Wert"].ToString()) < 0.00) { items.SubItems[3].ForeColor = Color.Red; }
                else if (Convert.ToDouble(row["Wert"].ToString()) > 0.00) { items.SubItems[3].ForeColor = Color.Green; }
                lv_dezember.Items.Add(items);
            }
        }

        /// <summary>
        /// Generiert die Chart der Jahresbilanz
        /// </summary>
        private void DrawChart_Bilanz()
        {
            chart_uebersicht.Series.Clear();

            Series chart_series = new Series("ChartSeries");
            chart_series.IsVisibleInLegend = false;
            chart_series.ChartType = SeriesChartType.Column;
            chart_series.XValueType = ChartValueType.String;
            chart_series.YValueType = ChartValueType.Double;

            chart_series.Points.AddXY("Jan", Convert.ToDouble(lv_jahresuebersicht.Items[0].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Feb", Convert.ToDouble(lv_jahresuebersicht.Items[1].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("März", Convert.ToDouble(lv_jahresuebersicht.Items[2].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("April", Convert.ToDouble(lv_jahresuebersicht.Items[3].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Mai", Convert.ToDouble(lv_jahresuebersicht.Items[4].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Juni", Convert.ToDouble(lv_jahresuebersicht.Items[5].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Juli", Convert.ToDouble(lv_jahresuebersicht.Items[6].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Aug", Convert.ToDouble(lv_jahresuebersicht.Items[7].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Sep", Convert.ToDouble(lv_jahresuebersicht.Items[8].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Okt", Convert.ToDouble(lv_jahresuebersicht.Items[9].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Nov", Convert.ToDouble(lv_jahresuebersicht.Items[10].SubItems[1].Text.TrimEnd('€')));
            chart_series.Points.AddXY("Dez", Convert.ToDouble(lv_jahresuebersicht.Items[11].SubItems[1].Text.TrimEnd('€')));

            if(Convert.ToDouble(lv_jahresuebersicht.Items[0].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[0].Color = Color.Red; } else { chart_series.Points[0].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[1].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[1].Color = Color.Red; } else { chart_series.Points[1].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[2].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[2].Color = Color.Red; } else { chart_series.Points[2].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[3].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[3].Color = Color.Red; } else { chart_series.Points[3].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[4].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[4].Color = Color.Red; } else { chart_series.Points[4].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[5].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[5].Color = Color.Red; } else { chart_series.Points[5].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[6].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[6].Color = Color.Red; } else { chart_series.Points[6].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[7].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[7].Color = Color.Red; } else { chart_series.Points[7].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[8].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[8].Color = Color.Red; } else { chart_series.Points[8].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[9].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[9].Color = Color.Red; } else { chart_series.Points[9].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[10].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[10].Color = Color.Red; } else { chart_series.Points[10].Color = Color.Green; }
            if (Convert.ToDouble(lv_jahresuebersicht.Items[11].SubItems[1].Text.TrimEnd('€')) < 0.00) { chart_series.Points[11].Color = Color.Red; } else { chart_series.Points[11].Color = Color.Green; }


            chart_uebersicht.Series.Add(chart_series);
            chart_uebersicht.ChartAreas[0].AxisX.Interval = 1;
            chart_uebersicht.Update();

            double umsatz = Convert.ToDouble(lv_jahresuebersicht.Items[0].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[1].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[2].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[3].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[4].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[5].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[6].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[7].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[8].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[9].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[10].SubItems[1].Text.TrimEnd('€')) +
                             Convert.ToDouble(lv_jahresuebersicht.Items[11].SubItems[1].Text.TrimEnd('€'));

            lbl_bilanz.Text = umsatz.ToString() + "€";

            if(umsatz > 0.0) { lbl_bilanz.ForeColor = Color.Green;}
            else if(umsatz < 0.0) { lbl_bilanz.ForeColor = Color.Red; }
            else { lbl_bilanz.ForeColor = Color.Black; }
        }
        
        /// <summary>
        /// Berechnet die Bilanz der einzelnen Kategorien und schreibt diese in die GUI
        /// </summary>
        private void CalcAndDisplayKategorie()
        {
            lv_kategorieuebersicht.Items.Clear();

            DataTable dTable = dbClass.Select_AllEntrys_Kategorie(dbClass.DefineConnection());

            foreach(DataRow row in dTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row[1].ToString() + "€");
                lv_kategorieuebersicht.Items.Add(item);
            }
        }

        /// <summary>
        /// Berechnet die Bilanz der einzelnen Monate und schreibt diese formatiert
        /// in die GUI
        /// </summary>
        private void CalcAndDisplayBilanz()
        {
            double bilanz = 0.0;

            //Januar
            for (int x = 0; x < lv_januar.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_januar.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[0].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[0].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[0].SubItems[0].ForeColor = Color.Red; }


            //Februar
            bilanz = 0.00;
            for (int x = 0; x < lv_februar.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_februar.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[1].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[1].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[1].SubItems[0].ForeColor = Color.Red; }


            //März
            bilanz = 0.00;
            for (int x = 0; x < lv_maerz.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_maerz.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[2].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[2].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[2].SubItems[0].ForeColor = Color.Red; }


            //April
            bilanz = 0.00;
            for (int x = 0; x < lv_april.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_april.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[3].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[3].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[3].SubItems[0].ForeColor = Color.Red; }


            //Mai
            bilanz = 0.00;
            for (int x = 0; x < lv_mai.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_mai.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[4].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[4].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[4].SubItems[0].ForeColor = Color.Red; }


            //Juni
            bilanz = 0.00;
            for (int x = 0; x < lv_juni.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_juni.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[5].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[5].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[5].SubItems[0].ForeColor = Color.Red; }


            //Juli
            bilanz = 0.00;
            for (int x = 0; x < lv_juli.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_juli.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[6].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[6].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[6].SubItems[0].ForeColor = Color.Red; }


            //August
            bilanz = 0.00;
            for (int x = 0; x < lv_august.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_august.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[7].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[7].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[7].SubItems[0].ForeColor = Color.Red; }


            //September
            bilanz = 0.00;
            for (int x = 0; x < lv_september.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_september.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[8].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[8].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[8].SubItems[0].ForeColor = Color.Red; }


            //Oktober
            bilanz = 0.00;
            for (int x = 0; x < lv_oktober.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_oktober.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[9].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[9].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[9].SubItems[0].ForeColor = Color.Red; }


            //November
            bilanz = 0.00;
            for (int x = 0; x < lv_november.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_november.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[10].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[10].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[10].SubItems[0].ForeColor = Color.Red; }


            //Dezember
            bilanz = 0.00;
            for (int x = 0; x < lv_dezember.Items.Count; x++)
            { bilanz += Convert.ToDouble(lv_dezember.Items[x].SubItems[3].Text.ToString().TrimEnd('€')); }
            lv_jahresuebersicht.Items[11].SubItems[1].Text = Math.Round(bilanz, 2).ToString() + "€";
            if (bilanz > 0.00) { lv_jahresuebersicht.Items[11].SubItems[0].ForeColor = Color.Green; }
            else if (bilanz < 0.00) { lv_jahresuebersicht.Items[11].SubItems[0].ForeColor = Color.Red; }
        }

        private void lbl_developedby_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.techduke.de");
        }
    }
}

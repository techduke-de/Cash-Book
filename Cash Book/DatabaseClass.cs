using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace Cash_Book
{
    class DatabaseClass
    {
        private string dbPassword, dbDirectory;

        /// <summary>
        /// Legt das Datenbankpasswort für die Datenbankverbindung fest
        /// </summary>
        /// <param name="Password">DB Passwort</param>
        public void SetPassword(string Password)
        {
            dbPassword = Password;
        }


        /// <summary>
        /// Legt den Dateiname + Pfad für die Datenbankverbindung fest
        /// </summary>
        /// <param name="Directory">Vollständiger Dateipfad + Dateiname</param>
        public void SetPfad(string Directory)
        {
            dbDirectory = Directory;
        }




        /// <summary>
        /// Instanziert eine neue Datenbankverbindung und öffnet diese
        /// Passwort und Pfad MÜSSEN zuvor festgelegt werden
        /// </summary>
        /// <returns>Instanz einer SQLite Verbindung</returns>
        public SQLiteConnection DefineConnection()
        {
            try
            {
                if(dbPassword != "" && dbDirectory != "")
                {
                    SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbDirectory + ";Password=" + dbPassword + ";");
                    connection.Open();
                    return connection;
                }
                else
                {
                    MessageBox.Show("Keine Zugangsdaten festgelegt.\n Diese müssen vor dem Aufruf der Datenbank festgelegt werden.", "Fehler Code: 001 - Authentifizierung fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 001-1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Validierung des festgelegten Datenbankpasswort
        /// </summary>
        /// <returns>True: Verbindung hergestellt; False: Verbindung fehlgeschlagen</returns>
        public bool TestConnection()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbDirectory + ";Password=" + dbPassword + ";");
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM Januar";
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Erstellt die Standarttabellen in einer neuen Datenbank
        /// </summary>
        /// <param name="connection">Instanz einer SQLite Verbindung</param>
        /// <param name="db_name">Datenbankname</param>
        /// <returns>True: Tabellen erfolgreich erstellt, False: Tabellen erstellen fehlgeschlagen</returns>
        public bool CreateTables(SQLiteConnection connection)
        {
            try {
                string sql_syntax_monatstabellen = "(ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, " +
                    "Bezeichnung VARCHAR NOT NULL, " +
                    "Wert DOUBLE NOT NULL, " +
                    "Datum VARCHAR, " +
                    "Kategorie VARCHAR NOT NULL)";

                string sql_syntax_kategorie = "(Kategorie VARCHAR NOT NULL UNIQUE, " +
                    "Wert VARCHAR NOT NULL)";

                string sql_syntax_sparplaene = "(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                    "Bezeichnung VARCHAR NOT NULL," +
                    "Start VARCHAR NOT NULL," +
                    "Ende VARCHAR NOT NULL," +
                    "Ziel VARCHAR NOT NULL," +
                    "Betrag VARCHAR NOT NULL)";

                string sql_syntax_dauerauftraege = "(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, " +
                    "Bezeichnung VARCHAR NOT NULL," +
                    "Zeitraum VARCHAR NOT NULL," +
                    "Start VARCHAR NOT NULL," +
                    "Ende VARCHAR NOT NULL," +
                    "Betrag VARCHAR NOT NULL)";

                SQLiteCommand command = new SQLiteCommand(connection);

                command.CommandText = "CREATE TABLE Januar " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE Februar " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE Maerz " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE April " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE Mai " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE Juni " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE Juli " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE August " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE September " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE Oktober " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE November " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE Dezember " + sql_syntax_monatstabellen;
                command.ExecuteNonQuery();


                command.CommandText = "CREATE TABLE Kategorie " + sql_syntax_kategorie;
                command.ExecuteNonQuery();


                command.CommandText = "CREATE TABLE IF NOT EXISTS Sparplaene " + sql_syntax_sparplaene;
                command.ExecuteNonQuery();


                command.CommandText = "CREATE TABLE IF NOT EXISTS Dauerauftraege " + sql_syntax_dauerauftraege;
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        /// Buchung in die Datenbank eintragen
        /// </summary>
        /// <param name="connection">Instanz einer SQLite Verbindung</param>
        /// <param name="Bezeichnung">Bezeichnung (string)</param>
        /// <param name="Kategorie">Kategorie (string)</param>
        /// <param name="Datum">Datum (string)</param>
        /// <param name="Betrag">Betrag (string)</param>
        /// <param name="Monat">Monat (string)</param>
        /// <returns>True: Buchung erfolgreich eingetragen; False: Buchung fehlgeschlagen.</returns>
        public bool Insert_Entry_Monate(SQLiteConnection connection, string Bezeichnung, string Kategorie, string Datum, string Betrag, string Monat)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO '" + Monat + "' (Bezeichnung, Kategorie, Wert, Datum) VALUES ('" +
                   Bezeichnung + "', '" + Kategorie + "', '" + Betrag + "', '" + Datum + "')";
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 003", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        /// <summary>
        /// Löscht eine Buchung aus der Datenbank
        /// </summary>
        /// <param name="connection">Instanz einer SQLite Verbindung</param>
        /// <param name="ID">Buchungs ID</param>
        /// <param name="Monat">Monat aus dem die Buchung entfernt werden soll (Bsp. Januar)</param>
        /// <returns>True: Buchung wurde gelöscht; False: Buchung konnte nicht gelöscht werden</returns>
        public bool Delete_Entry_Monate(SQLiteConnection connection, string ID, string Monat)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "DELETE FROM '" + Monat + "' WHERE ID='" + ID + "'";
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 004", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        /// <summary>
        /// Rückgabe aller Buchungen eines Monats
        /// </summary>
        /// <param name="connection">Instanz einer SQLite Verbindung</param>
        /// <param name="Monat">Monat der gelesen werden soll (Bsp. Januar)</param>
        /// <returns>Alle Buchungen als DataTable</returns>
        public DataTable Select_AllEntrys_Monate(SQLiteConnection connection, string Monat)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM " + Monat;

                SQLiteDataReader reader = command.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(reader);

                command.Dispose();
                connection.Close();
                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 005", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        


        /// <summary>
        /// Neue Kategorie in die Datenbank einfügen
        /// </summary>
        /// <param name="connection">Instanz einer SQLite Verbindung</param>
        /// <param name="Name">Kategorie Name</param>
        /// <returns>True: Kategorie wurde in die Datenbank geschrieben; False: Fehler beim Eintragen</returns>
        public bool Insert_Entry_Kategorie(SQLiteConnection connection, string Name)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO 'kategorie' (Kategorie, Wert) VALUES (@kategorie, @wert)";
                command.Parameters.AddWithValue("@kategorie", Name);
                command.Parameters.AddWithValue("@wert", "0");
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 006", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        /// <summary>
        /// Löscht eine Kategorie aus der Datenbank
        /// </summary>
        /// <param name="connection">Instanz einer SQLite Verbindung</param>
        /// <param name="Name">Kategorie Name</param>
        /// <returns>True: Löschen erfolgreich; False: Löschen fehlgeschlagen</returns>
        public bool Delete_Entry_Kategorie(SQLiteConnection connection, string Name)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "DELETE FROM kategorie WHERE Kategorie ='" + Name + "'";
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 007", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        /// <summary>
        /// Rückgabe aller Kategorien aus der Datenbank
        /// </summary>
        /// <param name="connection">Instanz einer SQLite Verbindung</param>
        /// <returns>Alle Kategorien mit Wert als DataTable</returns>
        public DataTable Select_AllEntrys_Kategorie(SQLiteConnection connection)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM kategorie";

                SQLiteDataReader reader = command.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(reader);

                command.Dispose();
                connection.Close();

                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 008", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }


        /// <summary>
        /// Aktualisiert den Wert einer Kategorie
        /// </summary>
        /// <param name="connection">Instanz einer SQLite Verbindung</param>
        /// <param name="Name">Name der Kategorie</param>
        /// <param name="val">+/- Betrag</param>
        /// <returns>True: Wert wurde erfolgreich aktualisiert; False: Wert konnte nicht aktualisiert werden</returns>
        public bool Update_Kategorie_Value(SQLiteConnection connection, string Name, double val)
        {
            try {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM Kategorie WHERE Kategorie = '" + Name + "'";

                SQLiteDataReader reader = command.ExecuteReader();
                double actualVal = 0.0;

                while (reader.Read())
                {
                    actualVal = Convert.ToDouble(reader[1].ToString()) + val;
                }
                reader.Close();
                command.CommandText = "UPDATE Kategorie SET Wert ='" + actualVal.ToString() + "' WHERE Kategorie = '" + Name + "' ";
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler Code: 009", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

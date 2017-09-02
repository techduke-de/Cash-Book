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
    public partial class PasswortWindow : Form
    {
        public PasswortWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Beinhaltet das eingegebene Passwort
        /// </summary>
        public string pwd;

        /// <summary>
        /// Funktion wird aufgerufen, wenn der Button anmelden geklickt wurde
        /// Das Passwort wird dabei in die globale Variable pwd übergeben.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_anmelden_Click(object sender, EventArgs e)
        {
            pwd = tb_passwort.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

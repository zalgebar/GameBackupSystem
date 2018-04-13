using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBackupSystem
{
    public partial class FormGameBackup : Form
    {
        public FormGameBackup()
        {
            InitializeComponent();
            ucGameBackup1.SaveButtonClicked += new EventHandler(GameBackup_SaveButtonClicked);
            ucGameBackup1.CancelButtonClicked += new EventHandler(GameBackup_CancelButtonClicked);
        }

        public void SetGameBackup(GameBackup gameBackup)
        {
            ucGameBackup1.SetGameBackup(gameBackup);
        }

        protected void GameBackup_SaveButtonClicked(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected void GameBackup_CancelButtonClicked(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public GameBackup GetGameBackup()
        {
            return ucGameBackup1.getGameBackup();
        }
    }
}

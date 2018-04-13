using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameBackupSystem
{
    public partial class UCGameBackup : UserControl
    {
        private ListViewItem selectedFileItem = null;
        private ListViewItem selectedFolderItem = null;

        private Color NotExistColor = Color.Red;
        private Color DuplicateColor = Color.Blue;

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        public UCGameBackup()
        {
            InitializeComponent();

            listSavesFolders.Items.Clear();
            listOptionsFiles.Items.Clear();
            checkUniqueBackupFolder.Visible = false;
            usesUniqueBackupFolder(true);
        }

        public void SetGameBackup(GameBackup gameBackup)
        {
            txtGameName.Text = gameBackup.GameName;
            txtBackupFolder.Text = gameBackup.BackupFolder;

            listSavesFolders.Items.Clear();
            foreach (string folder in gameBackup.SavesFolders)
            {
                listSavesFolders.Items.Add(folder);
            }

            listOptionsFiles.Items.Clear();
            foreach (string option in gameBackup.OptionsFiles)
            {
                listOptionsFiles.Items.Add(option);
            }
            checkSavesFoldersExist();
            checkOptionsFilesExist();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool allGood = true;
            string errorMessage = "Check the following items:\n\n";
            if (txtGameName.Text.Equals(""))
            {
                errorMessage += "• The Game Name must contain a value.\n";
                allGood = false;
            }
            if (!checkBackupFolderExists())
            {
                errorMessage += "• The Backup Folder does not exist.\n";
                allGood = false;
            }
            if (!checkSavesFoldersExist())
            {
                errorMessage += "• A Saves Folder does not exist.\n";
                allGood = false;
            }
            if (!checkSavesFoldersForDuplicates())
            {
                errorMessage += "• A Saves Folder has a duplicate.\n";
                allGood = false;
            }
            if (!checkOptionsFilesExist())
            {
                errorMessage += "• An Options File does not exist.\n";
                allGood = false;
            }
            if (!checkOptionsFilesForDuplicates())
            {
                errorMessage += "• An Options File has a duplicate.\n";
                allGood = false;
            }

            if(!allGood)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                this.SaveButtonClicked(this, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelButtonClicked(this, e);
        }

        public void usesUniqueBackupFolder(bool useUniqueBackup)
        {
            checkUniqueBackupFolder.Checked = useUniqueBackup;
            if (useUniqueBackup)
            {
                txtBackupFolder.Enabled = true;
                btnBackupFolderBrowse.Enabled = true;
            }
            else
            {
                txtBackupFolder.Enabled = false;
                btnBackupFolderBrowse.Enabled = false;
            }
        }
        
        public GameBackup getGameBackup()
        {
            GameBackup gameBackup = new GameBackup(txtGameName.Text);
            if (txtBackupFolder.Text != null && !txtBackupFolder.Text.Equals(""))
            {
                gameBackup.BackupFolder = txtBackupFolder.Text;
            }
            LinkedList<string> saves = new LinkedList<string>();
            foreach (ListViewItem item in listSavesFolders.Items)
            {
                saves.AddLast(item.Text);
            }
            if (saves != null && saves.Count > 0)
            {
                gameBackup.SavesFolders = saves;
            }
            LinkedList<string> opts = new LinkedList<string>();
            foreach(ListViewItem item in listOptionsFiles.Items)
            {
                opts.AddLast(item.Text);
            }
            if(opts != null && opts.Count > 0)
            {
                gameBackup.OptionsFiles = opts;
            }
            return gameBackup;
        }

        ///// BACKUP FOLDER /////
        private void btnBrowseBackupFolder_Click(object sender, EventArgs e)
        {
            folderDialogBrowse.ShowDialog();
            if (!folderDialogBrowse.SelectedPath.Equals(""))
            {
                txtBackupFolder.Text = folderDialogBrowse.SelectedPath;
            }
        }

        ///// SAVES (FOLDERS) /////
        private void btnAddSavesFolder_Click(object sender, EventArgs e)
        {
            folderDialogBrowse.ShowDialog();
            if (!folderDialogBrowse.SelectedPath.Equals(""))
            {
                listSavesFolders.Items.Add(folderDialogBrowse.SelectedPath);
            }
        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            listSavesFolders.Items.Remove(selectedFolderItem);
        }

        private void listSavesFolders_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedFolderItem = e.Item;
        }

        private void listSavesFolders_DoubleClick(object sender, EventArgs e)
        {
            folderDialogBrowse.ShowDialog();
            if (!folderDialogBrowse.SelectedPath.Equals(""))
            {
                selectedFolderItem.Text = folderDialogBrowse.SelectedPath;
            }
        }

        ///// OPTIONS (FILES) /////
        private void btnAddOption_Click(object sender, EventArgs e)
        {
            fileDialogAddNewFile.ShowDialog();
        }

        private void btnRemoveOption_Click(object sender, EventArgs e)
        {
            listOptionsFiles.Items.Remove(selectedFileItem);
        }

        private void listOptionsFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedFileItem = e.Item;
        }

        private void fileDialogAddNewFile_FileOk(object sender, CancelEventArgs e)
        {
            if (checkOptionsFileIsDuplicate(fileDialogAddNewFile.FileName))
            {
                selectedFileItem = new ListViewItem(fileDialogAddNewFile.FileName);
                listOptionsFiles.Items.Add(selectedFileItem);
            }
            else
            {
                MessageBox.Show("The file \"" + fileDialogAddNewFile.FileName + "\" already exists in the list of Options files.");
                e.Cancel = true;
            }
            fileDialogAddNewFile.InitialDirectory = "";
            fileDialogAddNewFile.FileName = "";
        }

        private void listOptionsFiles_DoubleClick(object sender, EventArgs e)
        {
            if (selectedFileItem != null)
            {
                selectedFileItem.ForeColor = Color.Empty;
                fileDialogChangeFile.InitialDirectory = "";
                fileDialogChangeFile.FileName = "";
                try
                {
                    if (File.Exists(selectedFileItem.Text))
                    {
                        fileDialogChangeFile.InitialDirectory = Path.GetDirectoryName(selectedFileItem.Text);
                        fileDialogChangeFile.FileName = Path.GetFileName(selectedFileItem.Text);
                    }
                }
                catch (ArgumentException)
                {
                    fileDialogChangeFile.InitialDirectory = "";
                    fileDialogChangeFile.FileName = "";
                }
                fileDialogChangeFile.ShowDialog();
            }
        }

        private void fileDialogChangeFile_FileOk(object sender, CancelEventArgs e)
        {
            if (Path.Equals(selectedFileItem.Text, fileDialogChangeFile.FileName)) return;
            if (checkOptionsFileIsDuplicate(fileDialogChangeFile.FileName))
            {
                selectedFileItem.Text = fileDialogChangeFile.FileName;
            }
            else
            {
                MessageBox.Show("The file \"" + fileDialogChangeFile.FileName + "\" already exists in the list of Options files.");
                e.Cancel = true;
            }
            fileDialogChangeFile.InitialDirectory = "";
            fileDialogChangeFile.FileName = "";
        }

        ///// UTILITY FUNCTIONS /////
        private bool checkBackupFolderExists()
        {
            if (!Directory.Exists(txtBackupFolder.Text))
            {
                txtBackupFolder.ForeColor = NotExistColor;
                return false;
            }
            return true;
        }

        private bool checkSavesFoldersExist()
        {
            bool allGood = true;
            foreach (ListViewItem item in listSavesFolders.Items)
            {
                if (!Directory.Exists(item.Text))
                {
                    item.ForeColor = NotExistColor;
                    allGood = false;
                }
            }
            return allGood;
        }

        private bool checkSavesFoldersForDuplicates()
        {
            bool allGood = true;
            foreach (ListViewItem item in listSavesFolders.Items)
            {
                foreach (ListViewItem otherItem in listSavesFolders.Items)
                {
                    if (item != otherItem && item.Text.Equals(otherItem.Text))
                    {
                        otherItem.ForeColor = DuplicateColor;
                        allGood = false;
                    }
                }
            }
            return allGood;
        }

        private bool checkSavesFolderIsDuplicate(string input)
        {
            foreach (ListViewItem item in listSavesFolders.Items)
            {
                {
                    if (item.Text.Equals(input))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool checkOptionsFilesExist()
        {
            bool allGood = true;
            foreach (ListViewItem item in listOptionsFiles.Items)
            {
                if (!File.Exists(item.Text))
                {
                    item.ForeColor = NotExistColor;
                    allGood = false;
                }
            }
            return allGood;
        }

        private bool checkOptionsFilesForDuplicates()
        {
            bool allGood = true;
            foreach (ListViewItem item in listOptionsFiles.Items)
            {
                foreach (ListViewItem otherItem in listOptionsFiles.Items)
                {
                    if (item != otherItem && item.Text.Equals(otherItem.Text))
                    {
                        otherItem.ForeColor = DuplicateColor;
                        allGood = false;
                    }
                }
            }
            return allGood;
        }

        private bool checkOptionsFileIsDuplicate(string input)
        {
            foreach (ListViewItem item in listOptionsFiles.Items)
            {
                {
                    if (item.Text.Equals(input))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void checkUniqueBackupFolder_CheckedChanged(object sender, EventArgs e)
        {
            usesUniqueBackupFolder(checkUniqueBackupFolder.Checked);
        }

        private void txtBackupFolder_TextChanged(object sender, EventArgs e)
        {
            txtBackupFolder.ForeColor = Color.Empty;
        }
    }
}

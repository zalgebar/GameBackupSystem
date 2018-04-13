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
using System.Xml;

namespace GameBackupSystem
{
    public partial class MainWindow : Form
    {
        private XmlDocument document;
        private LinkedList<GameBackup> gameBackupList;
        private volatile LinkedList<GameBackup> tempGameList;

        private bool haveFile = false;
        private string fileName = "";
        private bool[] previousSelection = null; //could be useful for future features
        private bool[] previousChecks = null;

        private bool mNeedsSaving = false;
        private bool NeedsSaving {
            get { return mNeedsSaving; }
            set
            {
                this.Text = Properties.Resources.MainWindowTitle + " - ";
                if (value == true)
                {
                    this.Text += "* ";
                }
                this.Text += fileName;
                mNeedsSaving = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            document = new XmlDocument();
            gameBackupList = new LinkedList<GameBackup>();
            
            statusProgressText.Visible = false;
            statusProgressBar.Visible = false;
            statusSelection.Text = "";
            checkSameBackupFolder.Visible = false;

            gameListView.Columns.Clear();
            gameListView.Columns.Add("Game", Properties.Settings.Default.ColumnNameWidth);
            gameListView.Columns.Add("Backup Folder", Properties.Settings.Default.ColumnBackupWidth);
            gameListView.Columns.Add("Saves", Properties.Settings.Default.ColumnFoldersWidth);
            gameListView.Columns.Add("Options", Properties.Settings.Default.ColumnFilesWidth);

            if (File.Exists(Properties.Settings.Default.LastUsedXML))
            {
                haveFile = true;
                fileName = Properties.Settings.Default.LastUsedXML;
                statusProgressText.Visible = true;
                statusProgressText.Text = "Loading XML file...";
                workerLoadXmlFile.RunWorkerAsync();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuFileOpen();
        }

        private void menuFileOpen()
        {
            dialogOpenFile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            dialogOpenFile.ShowDialog();
        }

        private void dialogOpenFile_FileOk(object sender, CancelEventArgs e)
        {
            document = new XmlDocument();
            fileName = dialogOpenFile.FileName;
            saveLastFileNameSetting(dialogOpenFile.FileName);
            statusProgressText.Visible = true;
            statusProgressText.Text = "Loading XML file...";
            workerLoadXmlFile.RunWorkerAsync();
        }

        private void workerLoadXmlFile_DoWork(object sender, DoWorkEventArgs e)
        {
            workerLoadXmlFile.ReportProgress(0);
            document.Load(fileName);
            gameBackupList = GameBackup.ImportXMLToList(document);
            workerLoadXmlFile.ReportProgress(100);
        }

        private void workerLoadXmlFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                statusProgressText.Text = "File load canceled.";
            }
            else if (e.Error != null)
            {
                MessageBox.Show("File load error!\n" + e.Error.Message);
            }
            else
            {
                statusProgressText.Text = "File loaded.";
                this.Text = Properties.Resources.MainWindowTitle + " - " + fileName;
                haveFile = true;
                NeedsSaving = false;
                string backupFolder = allItemsSameBackupFolder(null);
                
                if (backupFolder != null)    //items have unique backup folders
                {
                    txtBackupFolder.Text = backupFolder;
                }
                else
                {
                    checkSameBackupFolder.Checked = true;
                }
                refillGameBackupItems();
            }
        }

        private void refillGameBackupItems()
        {
            gameListView.Items.Clear();
            foreach (GameBackup game in gameBackupList)
            {
                ListViewItem temp = new ListViewItem(game.GameName);
                temp.SubItems.Add(game.BackupFolder);
                if (game.SavesFolders.Count == 1)
                {
                    temp.SubItems.Add(game.SavesFolders.First.Value);
                }
                else
                {
                    temp.SubItems.Add(game.SavesFolders.Count + " " +
                    Utilities.Plural(game.SavesFolders.Count, "folder", "folders"));
                }
                if (game.OptionsFiles.Count == 1)
                {
                    temp.SubItems.Add(game.OptionsFiles.First.Value);
                }
                else
                {
                    temp.SubItems.Add(game.OptionsFiles.Count + " " +
                        Utilities.Plural(game.OptionsFiles.Count, "file", "files"));
                }
                gameListView.Items.Add(temp);
            }
        }

        private void uniqueBackupFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refillGameBackupItems();
        }

        private void saveLastFileNameSetting(string fileName)
        {
            Properties.Settings.Default.LastUsedXML = fileName;
            Properties.Settings.Default.Save();
        }

        private void checkUniqueBackupFolder_CheckedChanged(object sender, EventArgs e)
        {
            txtBackupFolder.Enabled = !checkSameBackupFolder.Checked;
            btnApplyFolder.Enabled = !checkSameBackupFolder.Checked;
        }

        private void btnApplyFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            if (allItemsSameBackupFolder(null) == null)
            {
                result = MessageBox.Show("Are you sure you want to apply this Backup Folder to all items?",
                    "Apply to All?", MessageBoxButtons.YesNo);
            }
            foreach (char c in Path.GetInvalidPathChars())
            {
                Console.WriteLine(Path.GetInvalidPathChars());
                if (txtBackupFolder.Text.Contains(c))
                {
                    MessageBox.Show("Folder may not contain the character '" + c + "'.");
                    return;
                }
            }
            if (result == DialogResult.Yes)
            {
                foreach (GameBackup game in gameBackupList)
                {
                    game.BackupFolder = txtBackupFolder.Text;
                    Console.WriteLine(game.BackupFolder + " = " + txtBackupFolder.Text);
                }
                NeedsSaving = true;
                refillGameBackupItems();
            }
        }

        /// <summary>
        /// Returns null if there are Unique Backup Folders.
        /// </summary>
        /// <param name="backupFolder"></param>
        /// <returns></returns>
        private string allItemsSameBackupFolder(string backupFolder)
        {
            foreach (GameBackup game in gameBackupList)
            {
                if (backupFolder == null)
                {
                    backupFolder = game.BackupFolder;
                }
                else if (!game.BackupFolder.Equals(backupFolder))
                {
                    return null;
                }
            }
            return backupFolder;
        }

        ///// CHECK ITEMS /////
        private void checkOrSelectAll(ItemChoices checkOrSelect, bool checkOrSelectItems)
        {
            foreach (ListViewItem item in gameListView.Items)
            {
                switch(checkOrSelect)
                {
                    case ItemChoices.CHECKED:
                        item.Checked = checkOrSelectItems;
                        break;
                    case ItemChoices.SELECTED:
                        item.Selected = checkOrSelectItems;
                        break;
                }
            }
        }

        private void invertCheckOrSelectAll(ItemChoices ic)
        {
            foreach (ListViewItem item in gameListView.Items)
            {
                switch (ic)
                {
                    case ItemChoices.CHECKED:
                        item.Checked = !item.Checked;
                        break;
                    case ItemChoices.SELECTED:
                        item.Selected = !item.Selected;
                        break;
                }
            }
        }

        private void savePreviousChecks()
        {
            previousSelection = new bool[gameBackupList.Count];
            previousChecks = new bool[gameBackupList.Count];
            int index = 0;
            foreach(ListViewItem item in gameListView.Items)
            {
                previousSelection[index] = item.Selected;
                previousChecks[index] = item.Checked;
                index++;
            }
        }

        private void restorePreviousChecks()
        {
            if(previousSelection == null || previousChecks == null) return;
            int index = 0;
            foreach (ListViewItem item in gameListView.Items)
            {
                item.Selected = previousSelection[index];
                item.Checked = previousChecks[index];
                index++;
            }
            previousSelection = null;
            previousChecks = null;
        }

        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkOrSelectAll(ItemChoices.CHECKED, true);
        }

        private void checkNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkOrSelectAll(ItemChoices.CHECKED, false);
        }

        private void invertChecksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invertCheckOrSelectAll(ItemChoices.CHECKED);
        }

        private void checkSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkSelected(true);
        }

        private void checkSelected(bool selected)
        {
            foreach (ListViewItem item in gameListView.Items)
            {
                if (item.Selected) item.Checked = selected;
            }
        }

        ///// SELECT ITEMS /////
        private void selectAll(bool selected)
        {
            foreach (ListViewItem item in gameListView.Items)
            {
                item.Selected = selected;
            }
        }

        private void invertSelectAll()
        {
            foreach (ListViewItem item in gameListView.Items)
            {
                item.Selected = !item.Selected;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectAll(true);
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectAll(false);
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invertSelectAll();
        }

        ///// BACKUP GAMES /////
        private void backupAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePreviousChecks();
            checkOrSelectAll(ItemChoices.CHECKED, true);
            backupItems();
        }

        private void backupCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backupItems();
        }

        private void backupItems()
        {
            statusProgressBar.Visible = true;
            tempGameList = new LinkedList<GameBackup>();
            foreach (ListViewItem item in gameListView.Items)
            {
                if (item.Checked)
                {
                    foreach (GameBackup game in gameBackupList)
                    {
                        if (game.GameName.Equals(item.Text))
                        {
                            tempGameList.AddLast(game);
                        }
                    }
                }
            }
            workerBackupGames.RunWorkerAsync();
        }

        private void workerBackupGames_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalActions = tempGameList.Count * 2;
            int currentAction = 0;
            workerBackupGames.ReportProgress(0);
            foreach (GameBackup game in tempGameList)
            {
                game.BackupSaves(true);
                workerBackupGames.ReportProgress(++currentAction * 100 / totalActions);
                game.BackupOptions(true);
                workerBackupGames.ReportProgress(++currentAction * 100 / totalActions);
            }
        }

        private void workerBackupGames_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusProgressBar.Value = e.ProgressPercentage;
        }

        private void workerBackupGames_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusProgressText.Text = "Backup successful.";
            restorePreviousChecks();
        }

        ///// RESTORE GAMES /////
        private void restoreAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePreviousChecks();
            checkOrSelectAll(ItemChoices.CHECKED, true);
            restoreItems();
        }

        private void restoreCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restoreItems();
        }

        private void restoreItems()
        {
            statusProgressBar.Visible = true;
            tempGameList = new LinkedList<GameBackup>();
            foreach (ListViewItem item in gameListView.Items)
            {
                if (item.Checked)
                {
                    foreach (GameBackup game in gameBackupList)
                    {
                        if (game.GameName.Equals(item.Text))
                        {
                            tempGameList.AddLast(game);
                        }
                    }
                }
            }
            workerRestoreGames.RunWorkerAsync();
        }

        private void workerRestoreGames_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalActions = tempGameList.Count * 2;
            int currentAction = 0;
            workerRestoreGames.ReportProgress(0);
            foreach (GameBackup game in tempGameList)
            {
                game.RestoreSaves(true);
                workerRestoreGames.ReportProgress(++currentAction * 100 / totalActions);
                game.RestoreOptions(true);
                workerRestoreGames.ReportProgress(++currentAction * 100 / totalActions);
            }
        }

        private void workerRestoreGames_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusProgressBar.Value = e.ProgressPercentage;
        }

        private void workerRestoreGames_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusProgressText.Text = "Restore successful.";
            restorePreviousChecks();
        }

        /////
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = null;
            haveFile = false;
            NeedsSaving = true;
            gameBackupList = new LinkedList<GameBackup>();
            NeedsSaving = true;
            gameListView.Items.Clear();
        }

        private void gameListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            statusSelection.Text = gameListView.Items.Count + " items | "
                + CountCheckedItems() + " checked | "
                + CountSelectedItems() + " selected";
            backupCheckedToolStripMenuItem.Text = Properties.Resources.Backup
                + " " + CountCheckedItems() + " " + Properties.Resources.CheckedItems;
            restoreCheckedToolStripMenuItem.Text = Properties.Resources.Restore
                + " " + CountCheckedItems() + " " + Properties.Resources.CheckedItems;
            removeToolStripMenuItem.Text = Properties.Resources.Remove
                + " " + CountCheckedItems() + " " + Properties.Resources.CheckedItems;
            if (CountCheckedItems() > 0)
            {
                backupCheckedToolStripMenuItem.Enabled = true;
                restoreCheckedToolStripMenuItem.Enabled = true;
                removeToolStripMenuItem.Enabled = true;
            }
            else
            {
                backupCheckedToolStripMenuItem.Enabled = false;
                restoreCheckedToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = false;
            }
        }

        private int CountCheckedItems()
        {
            int countChecked = 0;
            foreach (ListViewItem item in gameListView.Items)
            {
                if (item.Checked) countChecked++;
            }
            return countChecked;
        }

        private void gameListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusSelection.Text = gameListView.Items.Count + " items | "
                + CountCheckedItems() + " checked | "
                + CountSelectedItems() + " selected";
        }

        private ListViewItem selectedItem = null;
        private void gameListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedItem = e.Item;
        }

        private void gameListView_DoubleClick(object sender, EventArgs e)
        {
            FormGameBackup fgb = null;
            foreach (GameBackup game in gameBackupList)
            {
                if(game.GameName.Equals(selectedItem.Text))
                {
                    fgb = new FormGameBackup();
                    fgb.SetGameBackup(game);
                    fgb.ShowDialog();
                    if (fgb.DialogResult == DialogResult.OK)
                    {
                        gameBackupList.Remove(game);
                    }
                    break;
                }
            }
            if (fgb.DialogResult == DialogResult.OK)
            {
                gameBackupList.AddLast(fgb.GetGameBackup());
                refillGameBackupItems();
            }
        }

        private int CountSelectedItems()
        {
            int countSelected = 0;
            foreach (ListViewItem item in gameListView.Items)
            {
                if (item.Selected) countSelected++;
            }
            return countSelected;
        }

        enum ItemChoices
        { CHECKED, SELECTED }

        ///// ADD ITEMS /////
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGameBackup addGameDialog = new FormGameBackup();
            addGameDialog.ShowDialog();
            if(addGameDialog.DialogResult == DialogResult.OK)
            {
                gameBackupList.AddLast(addGameDialog.GetGameBackup());
                refillGameBackupItems();
            }
        }

        ///// REMOVE ITEMS /////
        private void removeItems(ItemChoices i)
        {
            DialogResult result = DialogResult.No;
            if (i == ItemChoices.CHECKED && CountCheckedItems() > 0)
            {
                result = MessageBox.Show("Are you sure you want to remove " +
                    Utilities.Plural(CountCheckedItems(), "this item", "these items") +
                    "?\n(Once you save the configuration, " +
                    Utilities.Plural(CountCheckedItems(), "this item", "these items") +
                    " will be lost.",
                    "Remove?", MessageBoxButtons.YesNo);
            }
            if (i == ItemChoices.SELECTED && CountSelectedItems() > 0)
            {
                result = MessageBox.Show("Are you sure you want to remove " +
                    Utilities.Plural(CountSelectedItems(), "this item", "these items") +
                    "?\n(Once you save the configuration, " +
                    Utilities.Plural(CountSelectedItems(), "this item", "these items") +
                    " will be lost.",
                    "Remove?", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes)
            {
                foreach(ListViewItem item in gameListView.Items)
                {
                    switch(i)
                    {
                        case ItemChoices.CHECKED:
                            if(item.Checked) { gameListView.Items.Remove(item); }
                            break;
                        case ItemChoices.SELECTED:
                            if (item.Selected) { gameListView.Items.Remove(item); }
                            break;
                    }
                }
            }
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeItems(ItemChoices.SELECTED);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeItems(ItemChoices.CHECKED);
        }

        ///// SAVE FILE /////
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (haveFile && File.Exists(fileName))
            {
                saveFile();
            }
            else
            {
                saveAsToolStripMenuItem.PerformClick();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".xml";
            saveFileDialog1.ShowDialog();
        }

        private void saveFile()
        {
            workerSaveXmlFile.RunWorkerAsync();
            haveFile = true;

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fileName = saveFileDialog1.FileName;
            saveFile();
        }

        private void workerSaveXmlFile_DoWork(object sender, DoWorkEventArgs e)
        {
            workerSaveXmlFile.ReportProgress(0);
            document = GameBackup.ExportListToXML(gameBackupList);
            workerSaveXmlFile.ReportProgress(50);
            document.Save(fileName);
            workerSaveXmlFile.ReportProgress(100);
        }

        private void workerSaveXmlFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusProgressText.Text = "File saved.";
            NeedsSaving = false;
        }

        private void workerSaveXmlFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusProgressBar.Visible = true;
            statusProgressBar.Value = e.ProgressPercentage;
        }

        private void workerLoadXmlFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusProgressBar.Visible = true;
            statusProgressBar.Value = e.ProgressPercentage;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
    }
}

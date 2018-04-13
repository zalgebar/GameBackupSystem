namespace GameBackupSystem
{
    partial class MainWindow
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertChecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupCheckedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreCheckedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressText = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.workerLoadXmlFile = new System.ComponentModel.BackgroundWorker();
            this.gameListView = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.checkSameBackupFolder = new System.Windows.Forms.CheckBox();
            this.btnApplyFolder = new System.Windows.Forms.Button();
            this.workerBackupGames = new System.ComponentModel.BackgroundWorker();
            this.workerRestoreGames = new System.ComponentModel.BackgroundWorker();
            this.workerSaveXmlFile = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(527, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About GBS";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.removeToolStripMenuItem.Text = "Remove Checked";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.invertSelectionToolStripMenuItem,
            this.checkAllToolStripMenuItem,
            this.checkNoneToolStripMenuItem,
            this.invertChecksToolStripMenuItem,
            this.checkSelectedToolStripMenuItem});
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.selectToolStripMenuItem.Text = "Select";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectNoneToolStripMenuItem.Text = "Select None";
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            this.invertSelectionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.invertSelectionToolStripMenuItem.Text = "Invert Selection";
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // checkAllToolStripMenuItem
            // 
            this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.checkAllToolStripMenuItem.Text = "Check All";
            this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
            // 
            // checkNoneToolStripMenuItem
            // 
            this.checkNoneToolStripMenuItem.Name = "checkNoneToolStripMenuItem";
            this.checkNoneToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.checkNoneToolStripMenuItem.Text = "Check None";
            this.checkNoneToolStripMenuItem.Click += new System.EventHandler(this.checkNoneToolStripMenuItem_Click);
            // 
            // invertChecksToolStripMenuItem
            // 
            this.invertChecksToolStripMenuItem.Name = "invertChecksToolStripMenuItem";
            this.invertChecksToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.invertChecksToolStripMenuItem.Text = "Invert Checks";
            this.invertChecksToolStripMenuItem.Click += new System.EventHandler(this.invertChecksToolStripMenuItem_Click);
            // 
            // checkSelectedToolStripMenuItem
            // 
            this.checkSelectedToolStripMenuItem.Name = "checkSelectedToolStripMenuItem";
            this.checkSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.checkSelectedToolStripMenuItem.Text = "Check Selected";
            this.checkSelectedToolStripMenuItem.Click += new System.EventHandler(this.checkSelectedToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupCheckedToolStripMenuItem,
            this.backupAllToolStripMenuItem});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // backupCheckedToolStripMenuItem
            // 
            this.backupCheckedToolStripMenuItem.Name = "backupCheckedToolStripMenuItem";
            this.backupCheckedToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.backupCheckedToolStripMenuItem.Text = "Backup Checked";
            this.backupCheckedToolStripMenuItem.Click += new System.EventHandler(this.backupCheckedToolStripMenuItem_Click);
            // 
            // backupAllToolStripMenuItem
            // 
            this.backupAllToolStripMenuItem.Name = "backupAllToolStripMenuItem";
            this.backupAllToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.backupAllToolStripMenuItem.Text = "Backup All";
            this.backupAllToolStripMenuItem.Click += new System.EventHandler(this.backupAllToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreCheckedToolStripMenuItem,
            this.restoreAllToolStripMenuItem});
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.restoreToolStripMenuItem.Text = "Restore";
            // 
            // restoreCheckedToolStripMenuItem
            // 
            this.restoreCheckedToolStripMenuItem.Name = "restoreCheckedToolStripMenuItem";
            this.restoreCheckedToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.restoreCheckedToolStripMenuItem.Text = "Restore Checked";
            this.restoreCheckedToolStripMenuItem.Click += new System.EventHandler(this.restoreCheckedToolStripMenuItem_Click);
            // 
            // restoreAllToolStripMenuItem
            // 
            this.restoreAllToolStripMenuItem.Name = "restoreAllToolStripMenuItem";
            this.restoreAllToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.restoreAllToolStripMenuItem.Text = "Restore All";
            this.restoreAllToolStripMenuItem.Click += new System.EventHandler(this.restoreAllToolStripMenuItem_Click);
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dialogOpenFile_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusSelection,
            this.toolStripStatusLabel1,
            this.statusProgressText,
            this.statusProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(527, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusSelection
            // 
            this.statusSelection.Name = "statusSelection";
            this.statusSelection.Size = new System.Drawing.Size(86, 17);
            this.statusSelection.Text = "statusSelection";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(220, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // statusProgressText
            // 
            this.statusProgressText.Name = "statusProgressText";
            this.statusProgressText.Size = new System.Drawing.Size(104, 17);
            this.statusProgressText.Text = "statusProgressText";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // workerLoadXmlFile
            // 
            this.workerLoadXmlFile.WorkerReportsProgress = true;
            this.workerLoadXmlFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerLoadXmlFile_DoWork);
            this.workerLoadXmlFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerLoadXmlFile_ProgressChanged);
            this.workerLoadXmlFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerLoadXmlFile_RunWorkerCompleted);
            // 
            // gameListView
            // 
            this.gameListView.CheckBoxes = true;
            this.gameListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameListView.FullRowSelect = true;
            this.gameListView.GridLines = true;
            this.gameListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.gameListView.Location = new System.Drawing.Point(3, 38);
            this.gameListView.Name = "gameListView";
            this.gameListView.ShowGroups = false;
            this.gameListView.Size = new System.Drawing.Size(521, 341);
            this.gameListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.gameListView.TabIndex = 3;
            this.gameListView.UseCompatibleStateImageBehavior = false;
            this.gameListView.View = System.Windows.Forms.View.Details;
            this.gameListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.gameListView_ItemChecked);
            this.gameListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.gameListView_ItemSelectionChanged);
            this.gameListView.SelectedIndexChanged += new System.EventHandler(this.gameListView_SelectedIndexChanged);
            this.gameListView.DoubleClick += new System.EventHandler(this.gameListView_DoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.Controls.Add(this.gameListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(527, 382);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel2.Controls.Add(this.txtBackupFolder, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkSameBackupFolder, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnApplyFolder, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(521, 29);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackupFolder.Location = new System.Drawing.Point(167, 4);
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.Size = new System.Drawing.Size(270, 20);
            this.txtBackupFolder.TabIndex = 6;
            // 
            // checkSameBackupFolder
            // 
            this.checkSameBackupFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkSameBackupFolder.AutoSize = true;
            this.checkSameBackupFolder.Location = new System.Drawing.Point(3, 6);
            this.checkSameBackupFolder.Name = "checkSameBackupFolder";
            this.checkSameBackupFolder.Size = new System.Drawing.Size(157, 17);
            this.checkSameBackupFolder.TabIndex = 5;
            this.checkSameBackupFolder.Text = "Use unique Backup Folders";
            this.checkSameBackupFolder.UseVisualStyleBackColor = true;
            this.checkSameBackupFolder.CheckedChanged += new System.EventHandler(this.checkUniqueBackupFolder_CheckedChanged);
            // 
            // btnApplyFolder
            // 
            this.btnApplyFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnApplyFolder.Location = new System.Drawing.Point(443, 3);
            this.btnApplyFolder.Name = "btnApplyFolder";
            this.btnApplyFolder.Size = new System.Drawing.Size(75, 23);
            this.btnApplyFolder.TabIndex = 7;
            this.btnApplyFolder.Text = "Apply to All";
            this.btnApplyFolder.UseVisualStyleBackColor = true;
            this.btnApplyFolder.Click += new System.EventHandler(this.btnApplyFolder_Click);
            // 
            // workerBackupGames
            // 
            this.workerBackupGames.WorkerReportsProgress = true;
            this.workerBackupGames.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerBackupGames_DoWork);
            this.workerBackupGames.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerBackupGames_ProgressChanged);
            this.workerBackupGames.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerBackupGames_RunWorkerCompleted);
            // 
            // workerRestoreGames
            // 
            this.workerRestoreGames.WorkerReportsProgress = true;
            this.workerRestoreGames.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerRestoreGames_DoWork);
            this.workerRestoreGames.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerRestoreGames_ProgressChanged);
            this.workerRestoreGames.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerRestoreGames_RunWorkerCompleted);
            // 
            // workerSaveXmlFile
            // 
            this.workerSaveXmlFile.WorkerReportsProgress = true;
            this.workerSaveXmlFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerSaveXmlFile_DoWork);
            this.workerSaveXmlFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerSaveXmlFile_ProgressChanged);
            this.workerSaveXmlFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerSaveXmlFile_RunWorkerCompleted);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 428);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker workerLoadXmlFile;
        private System.Windows.Forms.ListView gameListView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private System.Windows.Forms.CheckBox checkSameBackupFolder;
        private System.Windows.Forms.Button btnApplyFolder;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupCheckedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreCheckedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusSelection;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.ComponentModel.BackgroundWorker workerBackupGames;
        private System.ComponentModel.BackgroundWorker workerRestoreGames;
        private System.Windows.Forms.ToolStripStatusLabel statusProgressText;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertChecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker workerSaveXmlFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}


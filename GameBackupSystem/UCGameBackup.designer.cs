namespace GameBackupSystem
{
    partial class UCGameBackup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderDialogBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSavesFolderBrowse = new System.Windows.Forms.Button();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.lblGameName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddOption = new System.Windows.Forms.Button();
            this.lblSavesFolder = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOptions = new System.Windows.Forms.Label();
            this.btnRemoveOption = new System.Windows.Forms.Button();
            this.btnBackupFolderBrowse = new System.Windows.Forms.Button();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.lblBackupFolder = new System.Windows.Forms.Label();
            this.listOptionsFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkUniqueBackupFolder = new System.Windows.Forms.CheckBox();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.listSavesFolders = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileDialogChangeFile = new System.Windows.Forms.OpenFileDialog();
            this.fileDialogAddNewFile = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSavesFolderBrowse
            // 
            this.btnSavesFolderBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSavesFolderBrowse.Location = new System.Drawing.Point(511, 93);
            this.btnSavesFolderBrowse.Name = "btnSavesFolderBrowse";
            this.btnSavesFolderBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSavesFolderBrowse.TabIndex = 3;
            this.btnSavesFolderBrowse.Text = "Add";
            this.btnSavesFolderBrowse.UseVisualStyleBackColor = true;
            this.btnSavesFolderBrowse.Click += new System.EventHandler(this.btnAddSavesFolder_Click);
            // 
            // txtGameName
            // 
            this.txtGameName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameName.Location = new System.Drawing.Point(86, 5);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(419, 20);
            this.txtGameName.TabIndex = 1;
            // 
            // lblGameName
            // 
            this.lblGameName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(3, 8);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(66, 13);
            this.lblGameName.TabIndex = 2;
            this.lblGameName.Text = "Game Name";
            this.lblGameName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddOption, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblGameName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGameName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSavesFolderBrowse, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSavesFolder, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblOptions, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveOption, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnBackupFolderBrowse, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBackupFolder, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBackupFolder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listOptionsFiles, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkUniqueBackupFolder, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveFolder, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.listSavesFolders, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 442);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnAddOption
            // 
            this.btnAddOption.Location = new System.Drawing.Point(511, 254);
            this.btnAddOption.Name = "btnAddOption";
            this.btnAddOption.Size = new System.Drawing.Size(75, 23);
            this.btnAddOption.TabIndex = 0;
            this.btnAddOption.Text = "Add";
            this.btnAddOption.UseVisualStyleBackColor = true;
            this.btnAddOption.Click += new System.EventHandler(this.btnAddOption_Click);
            // 
            // lblSavesFolder
            // 
            this.lblSavesFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSavesFolder.AutoSize = true;
            this.lblSavesFolder.Location = new System.Drawing.Point(3, 98);
            this.lblSavesFolder.Name = "lblSavesFolder";
            this.lblSavesFolder.Size = new System.Drawing.Size(74, 13);
            this.lblSavesFolder.TabIndex = 2;
            this.lblSavesFolder.Text = "Saves Folders";
            this.lblSavesFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(520, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(3, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblOptions
            // 
            this.lblOptions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(3, 259);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(67, 13);
            this.lblOptions.TabIndex = 2;
            this.lblOptions.Text = "Options Files";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRemoveOption
            // 
            this.btnRemoveOption.Location = new System.Drawing.Point(511, 284);
            this.btnRemoveOption.Name = "btnRemoveOption";
            this.btnRemoveOption.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveOption.TabIndex = 1;
            this.btnRemoveOption.Text = "Remove";
            this.btnRemoveOption.UseVisualStyleBackColor = true;
            this.btnRemoveOption.Click += new System.EventHandler(this.btnRemoveOption_Click);
            // 
            // btnBackupFolderBrowse
            // 
            this.btnBackupFolderBrowse.Location = new System.Drawing.Point(511, 33);
            this.btnBackupFolderBrowse.Name = "btnBackupFolderBrowse";
            this.btnBackupFolderBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBackupFolderBrowse.TabIndex = 7;
            this.btnBackupFolderBrowse.Text = "Browse";
            this.btnBackupFolderBrowse.UseVisualStyleBackColor = true;
            this.btnBackupFolderBrowse.Click += new System.EventHandler(this.btnBrowseBackupFolder_Click);
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackupFolder.Location = new System.Drawing.Point(86, 35);
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.Size = new System.Drawing.Size(419, 20);
            this.txtBackupFolder.TabIndex = 8;
            this.txtBackupFolder.TextChanged += new System.EventHandler(this.txtBackupFolder_TextChanged);
            // 
            // lblBackupFolder
            // 
            this.lblBackupFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBackupFolder.AutoSize = true;
            this.lblBackupFolder.Location = new System.Drawing.Point(3, 38);
            this.lblBackupFolder.Name = "lblBackupFolder";
            this.lblBackupFolder.Size = new System.Drawing.Size(76, 13);
            this.lblBackupFolder.TabIndex = 9;
            this.lblBackupFolder.Text = "Backup Folder";
            this.lblBackupFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listOptionsFiles
            // 
            this.listOptionsFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listOptionsFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOptionsFiles.FullRowSelect = true;
            this.listOptionsFiles.GridLines = true;
            this.listOptionsFiles.LabelEdit = true;
            this.listOptionsFiles.Location = new System.Drawing.Point(86, 254);
            this.listOptionsFiles.MultiSelect = false;
            this.listOptionsFiles.Name = "listOptionsFiles";
            this.tableLayoutPanel1.SetRowSpan(this.listOptionsFiles, 2);
            this.listOptionsFiles.Size = new System.Drawing.Size(419, 155);
            this.listOptionsFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listOptionsFiles.TabIndex = 10;
            this.listOptionsFiles.UseCompatibleStateImageBehavior = false;
            this.listOptionsFiles.View = System.Windows.Forms.View.Details;
            this.listOptionsFiles.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listOptionsFiles_ItemSelectionChanged);
            this.listOptionsFiles.DoubleClick += new System.EventHandler(this.listOptionsFiles_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Path";
            this.columnHeader1.Width = 396;
            // 
            // checkUniqueBackupFolder
            // 
            this.checkUniqueBackupFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkUniqueBackupFolder.AutoSize = true;
            this.checkUniqueBackupFolder.Location = new System.Drawing.Point(86, 66);
            this.checkUniqueBackupFolder.Name = "checkUniqueBackupFolder";
            this.checkUniqueBackupFolder.Size = new System.Drawing.Size(154, 17);
            this.checkUniqueBackupFolder.TabIndex = 11;
            this.checkUniqueBackupFolder.Text = "Use Unique Backup Folder";
            this.checkUniqueBackupFolder.UseVisualStyleBackColor = true;
            this.checkUniqueBackupFolder.CheckedChanged += new System.EventHandler(this.checkUniqueBackupFolder_CheckedChanged);
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Location = new System.Drawing.Point(511, 123);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFolder.TabIndex = 13;
            this.btnRemoveFolder.Text = "Remove";
            this.btnRemoveFolder.UseVisualStyleBackColor = true;
            this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemoveFolder_Click);
            // 
            // listSavesFolders
            // 
            this.listSavesFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listSavesFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSavesFolders.FullRowSelect = true;
            this.listSavesFolders.GridLines = true;
            this.listSavesFolders.LabelEdit = true;
            this.listSavesFolders.Location = new System.Drawing.Point(86, 93);
            this.listSavesFolders.MultiSelect = false;
            this.listSavesFolders.Name = "listSavesFolders";
            this.tableLayoutPanel1.SetRowSpan(this.listSavesFolders, 2);
            this.listSavesFolders.Size = new System.Drawing.Size(419, 155);
            this.listSavesFolders.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listSavesFolders.TabIndex = 12;
            this.listSavesFolders.UseCompatibleStateImageBehavior = false;
            this.listSavesFolders.View = System.Windows.Forms.View.Details;
            this.listSavesFolders.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listSavesFolders_ItemSelectionChanged);
            this.listSavesFolders.DoubleClick += new System.EventHandler(this.listSavesFolders_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Folder Path";
            this.columnHeader2.Width = 395;
            // 
            // fileDialogChangeFile
            // 
            this.fileDialogChangeFile.FileOk += new System.ComponentModel.CancelEventHandler(this.fileDialogChangeFile_FileOk);
            // 
            // fileDialogAddNewFile
            // 
            this.fileDialogAddNewFile.FileOk += new System.ComponentModel.CancelEventHandler(this.fileDialogAddNewFile_FileOk);
            // 
            // UCGameBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCGameBackup";
            this.Size = new System.Drawing.Size(598, 442);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderDialogBrowse;
        private System.Windows.Forms.Button btnSavesFolderBrowse;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSavesFolder;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog fileDialogChangeFile;
        private System.Windows.Forms.Button btnAddOption;
        private System.Windows.Forms.Button btnRemoveOption;
        private System.Windows.Forms.Button btnBackupFolderBrowse;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private System.Windows.Forms.Label lblBackupFolder;
        private System.Windows.Forms.ListView listOptionsFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.OpenFileDialog fileDialogAddNewFile;
        private System.Windows.Forms.CheckBox checkUniqueBackupFolder;
        private System.Windows.Forms.ListView listSavesFolders;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnRemoveFolder;
    }
}

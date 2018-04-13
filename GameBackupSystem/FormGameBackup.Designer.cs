namespace GameBackupSystem
{
    partial class FormGameBackup
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
            this.ucGameBackup1 = new GameBackupSystem.UCGameBackup();
            this.SuspendLayout();
            // 
            // ucGameBackup1
            // 
            this.ucGameBackup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGameBackup1.Location = new System.Drawing.Point(0, 0);
            this.ucGameBackup1.Name = "ucGameBackup1";
            this.ucGameBackup1.Size = new System.Drawing.Size(587, 453);
            this.ucGameBackup1.TabIndex = 0;
            // 
            // FormGameBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 453);
            this.Controls.Add(this.ucGameBackup1);
            this.Name = "FormGameBackup";
            this.Text = "FormGameBackup";
            this.ResumeLayout(false);

        }

        #endregion

        private UCGameBackup ucGameBackup1;
    }
}
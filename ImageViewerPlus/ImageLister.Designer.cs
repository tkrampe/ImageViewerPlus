namespace ImageViewerPlus
{
    partial class ImageLister
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
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._checkedListBox = new ImageViewerPlus.ImageLister.MyCheckedListBox();
            this._btnProcess = new System.Windows.Forms.Button();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(166, 24);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openDirectoryToolStripMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // _openDirectoryToolStripMenuItem
            // 
            this._openDirectoryToolStripMenuItem.Name = "_openDirectoryToolStripMenuItem";
            this._openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this._openDirectoryToolStripMenuItem.Text = "Open Directory";
            this._openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // _checkedListBox
            // 
            this._checkedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._checkedListBox.FormattingEnabled = true;
            this._checkedListBox.Location = new System.Drawing.Point(12, 27);
            this._checkedListBox.Name = "_checkedListBox";
            this._checkedListBox.Size = new System.Drawing.Size(142, 634);
            this._checkedListBox.TabIndex = 1;
            this._checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._checkedListBox_ItemCheck);
            this._checkedListBox.SelectedValueChanged += new System.EventHandler(this._checkedListBox_SelectedValueChanged);
            this._checkedListBox.DoubleClick += new System.EventHandler(this._checkedListBox_DoubleClick);
            // 
            // _btnProcess
            // 
            this._btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnProcess.Location = new System.Drawing.Point(79, 680);
            this._btnProcess.Name = "_btnProcess";
            this._btnProcess.Size = new System.Drawing.Size(75, 23);
            this._btnProcess.TabIndex = 2;
            this._btnProcess.Text = "Process";
            this._btnProcess.UseVisualStyleBackColor = true;
            this._btnProcess.Click += new System.EventHandler(this._btnProcess_Click);
            // 
            // ImageLister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 714);
            this.Controls.Add(this._btnProcess);
            this.Controls.Add(this._checkedListBox);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageLister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image Viewer Plus";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openDirectoryToolStripMenuItem;
        private System.Windows.Forms.Button _btnProcess;
        private ImageLister.MyCheckedListBox _checkedListBox;
    }
}


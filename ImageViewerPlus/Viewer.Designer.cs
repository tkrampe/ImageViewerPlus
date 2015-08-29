namespace ImageViewerPlus
{
    partial class Viewer
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
            this._pictureBox = new ImageViewerPlus.Viewer.MyPictureBox();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.Image = null;
            this._pictureBox.Location = new System.Drawing.Point(0, 0);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(728, 487);
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1690, 1136);
            this.Controls.Add(this._pictureBox);
            this.Location = new System.Drawing.Point(190, 0);
            this.Name = "Viewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private MyPictureBox _pictureBox;
    }
}
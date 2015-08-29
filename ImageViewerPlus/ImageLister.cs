using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageViewerPlus
{
    public partial class ImageLister : Form
    {
        private List<ImageInfo> ImageInfos = new List<ImageInfo>();
        private Viewer Viewer = new Viewer();
        private string _currentDirectory;
        private ASCIIEncoding _encoding = new ASCIIEncoding();

        public ImageLister()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length < 1 || !System.IO.Directory.Exists(args[1]))
                return;

            _currentDirectory = args[1];
            CreateImageInfosFromDirectory(_currentDirectory);
            LoadCheckedListBox();
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.SelectedPath = "E:\\Trail Cams\\2014";

            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            _currentDirectory = dialog.SelectedPath;
            CreateImageInfosFromDirectory(_currentDirectory);
            LoadCheckedListBox();
        }

        private void CreateImageInfosFromDirectory(string path)
        {
            ImageInfos.Clear();

            string[] imagePaths = System.IO.Directory.GetFiles(path, "*.jpg");

            foreach (string imagePath in imagePaths)
            {
                ImageInfos.Add(new ImageInfo(imagePath));
            }
        }

        private void LoadCheckedListBox()
        {
            _checkedListBox.Items.Clear();

            foreach (ImageInfo imageInfo in ImageInfos)
            {
                _checkedListBox.Items.Add(imageInfo.FileName);
            }
        }

        private void _checkedListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_checkedListBox.SelectedIndex >= 0)
            {
                Viewer.LoadImage(ImageInfos[_checkedListBox.SelectedIndex]);

                if (_checkedListBox.SelectedIndex < _checkedListBox.Items.Count - 2)
                    ImageInfos[_checkedListBox.SelectedIndex + 1].LoadImage_Async();

                if (_checkedListBox.SelectedIndex < _checkedListBox.Items.Count - 3)
                    ImageInfos[_checkedListBox.SelectedIndex + 2].LoadImage_Async();

                if (_checkedListBox.SelectedIndex < _checkedListBox.Items.Count - 4)
                    ImageInfos[_checkedListBox.SelectedIndex + 3].LoadImage_Async();
            }
        }

        private void _checkedListBox_DoubleClick(object sender, EventArgs e)
        {
            if (!Viewer.Visible)
                Viewer.Show();
        }

        private void _checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void _btnProcess_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to process the list?", "Confirm", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                return;

            Viewer.UnloadImage();
            Viewer.Hide();

            for (int i = 0; i < _checkedListBox.Items.Count; i++)
            {
                ImageInfo imageInfo = ImageInfos[i];
                //imageInfo.Image.Dispose();

                if (_checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                    RenameFile(imageInfo);
                else if (System.IO.File.Exists(imageInfo.Path))

                    System.IO.File.Delete(imageInfo.Path);
            }

            CreateImageInfosFromDirectory(_currentDirectory);
            LoadCheckedListBox();
        }

        private void RenameFile(ImageInfo info)
        {
            Image image = System.Drawing.Image.FromFile(info.Path);
            string meta = _encoding.GetString(image.PropertyItems[15].Value).TrimEnd('\0');
            image.Dispose();

            string[] tokens = meta.Split(' ');
            string date = tokens[0].Replace(":", string.Empty);
            string time = tokens[1].Replace(":", string.Empty);
            System.IO.DirectoryInfo parentDirectory = System.IO.Directory.GetParent(info.Path);
            string parentDirName = parentDirectory.Name;
            parentDirName = parentDirName.Replace(" ", "_");
            parentDirName = parentDirName.ToLower();

            string fileName = parentDirName + "_" + date + "_" + time + ".jpg";
            string newFilePath = System.IO.Path.Combine(parentDirectory.FullName, fileName);

            int i = 2;
            while (System.IO.File.Exists(newFilePath))
            {
                fileName = parentDirName + "_" + date + "_" + time + "_" + i + ".jpg";
                newFilePath = System.IO.Path.Combine(parentDirectory.FullName, fileName);
            }

            System.IO.File.Move(info.Path, newFilePath);
        }

        private class MyCheckedListBox : CheckedListBox
        {
            private bool _allowCheck = false;
            private System.DateTime _lastNum0PressTime = System.DateTime.MinValue;

            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.NumPad0)
                {
                    System.DateTime curNum0PressTime = System.DateTime.Now;

                    if ((curNum0PressTime - _lastNum0PressTime).TotalMilliseconds > 150d)
                    {
                        _lastNum0PressTime = curNum0PressTime;

                        int newIndex = this.SelectedIndex + 1;

                        if (newIndex < this.Items.Count)
                            this.SelectedIndex = newIndex;
                    }
                }
                else if (e.KeyCode == Keys.Space)
                {
                    _allowCheck = true;
                }
                else if (e.KeyCode == Keys.Decimal)
                {
                    _allowCheck = true;
                    int selectedIndex = this.SelectedIndex;

                    if (selectedIndex > 0)
                    {
                        bool isChecked = this.GetItemChecked(selectedIndex);

                        if (isChecked)
                            SetItemCheckState(selectedIndex, CheckState.Unchecked);
                        else
                            SetItemCheckState(selectedIndex, CheckState.Checked);
                    }
                }

                base.OnKeyDown(e);
            }

            protected override void OnItemCheck(ItemCheckEventArgs ice)
            {
                if (!_allowCheck)
                    ice.NewValue = ice.CurrentValue; //check state change was not through authorized actions

                _allowCheck = false;

                base.OnItemCheck(ice);
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                Point loc = this.PointToClient(Cursor.Position);

                for (int i = 0; i < this.Items.Count; i++)
                {
                    Rectangle rec = this.GetItemRectangle(i);
                    rec.Width = 16; //checkbox itself has a default width of about 16 pixels

                    if (rec.Contains(loc))
                    {
                        _allowCheck = true;
                        bool newValue = !this.GetItemChecked(i);
                        this.SetItemChecked(i, newValue);//check 
                        _allowCheck = false;

                        return;
                    }
                }

                base.OnMouseDown(e);
            }

        }
    }
}

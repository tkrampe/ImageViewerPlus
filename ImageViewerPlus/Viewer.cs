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
    public partial class Viewer : Form
    {
        private ImageInfo _currentImageInfo;

        public Viewer()
        {
            InitializeComponent();
        }

        public void LoadImage(ImageInfo imageInfo)
        {          
            _pictureBox.SuspendDrawing();

            _currentImageInfo = imageInfo;
            _pictureBox.Image = System.Drawing.Image.FromFile(_currentImageInfo.Path);
            CheckPictureBoxSize();

            this.Text = _currentImageInfo.Path;

            _pictureBox.ResumeDrawing();
        }

        public void UnloadImage()
        {
            _currentImageInfo = null;
            _pictureBox.Image = null;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CheckPictureBoxSize();
        }

        private void CheckPictureBoxSize()
        {
            if (_pictureBox.Image == null)
                return;

            int maxWidth = this.Width - 22;
            int maxHeight = this.Height - 46;

            float picBoxWidth;
            float picBoxHeight;

            float x = 2;
            float y = 2;

            Size imageSize = _pictureBox.Image.Size;

            float ratio = (float)imageSize.Height / (float)imageSize.Width;

            picBoxWidth = maxWidth;
            picBoxHeight = picBoxWidth * ratio;

            if (picBoxHeight > maxHeight)
            {
                picBoxHeight = maxHeight;
                picBoxWidth = picBoxHeight * (1f / ratio);
                x = (maxWidth - picBoxWidth) / 2f;
            }
            else
            {
                y = (maxHeight - picBoxHeight) / 2f;
            }

            Rectangle newBounds = Rectangle.Truncate(new RectangleF(x, y, picBoxWidth, picBoxHeight));

            if (newBounds != _pictureBox.Bounds)
                _pictureBox.Bounds = newBounds;
        }

        private class MyPictureBox : Control
        {
            private Image _image;
            private bool _suspendDrawing;

            public MyPictureBox()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            }

            public Image Image
            {
                get
                {
                    return _image;
                }
                set
                {
                    if (_image == value)
                        return;

                    Image oldImage = _image;
                    _image = value;

                    Invalidate();

                    if (oldImage != null)
                        oldImage.Dispose();
                }
            }

            public void SuspendDrawing()
            {
                _suspendDrawing = true;
            }

            public void ResumeDrawing()
            {
                _suspendDrawing = false;
                Invalidate();
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                Invalidate();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                if (_suspendDrawing)
                    return;

                if (_image != null)
                    e.Graphics.DrawImage(_image, new Rectangle(Point.Empty, this.Size));
                //else
                //    e.Graphics.Clear(this.BackColor);
            }
        }
    }
}

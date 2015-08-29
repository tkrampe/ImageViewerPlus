using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageViewerPlus
{
    public class ImageInfo
    {
        private string _path;
        private string _fileName;
        private System.Drawing.Image _image;
        private object _imageLock = new object();
        private System.Drawing.Size _size;

        public ImageInfo(string path)
        {
            _path = path;
            _fileName = System.IO.Path.GetFileNameWithoutExtension(path);
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
        }

        public System.Drawing.Image Image
        {
            get
            {
                lock (_imageLock)
                {
                    if (_image == null)
                        LoadImage();

                    return _image;
                }
            }
        }

        public System.Drawing.Size Size
        {
            get
            {
                lock (_imageLock)
                {
                    if (_image == null)
                        LoadImage();

                    return _size;
                }
            }
        }

        public void LoadImage()
        {
            return;
            lock (_imageLock)
            {
                if (_image != null)
                    return;

                _image = System.Drawing.Image.FromFile(_path);
                _size = _image.Size;
            }
        }

        public void LoadImage_Async()
        {
            System.Threading.ThreadStart thread = new System.Threading.ThreadStart(LoadImage);
            thread.BeginInvoke(null, null);
        }
    }
}

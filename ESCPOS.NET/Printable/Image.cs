using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace ESCPOS.NET.Printable
{
    public class Image : IPrintable
    {
        private readonly Bitmap _image;

        public Image(Bitmap image)
        {
            _image = image;
        }

        public Image(string path)
        {
            _image = new Bitmap(path);
        }

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}

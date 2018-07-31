using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;

namespace ESCPOS.NET.Printable
{
    public class Image : IPrintable
    {
        //private readonly Bitmap _image;

        //public Image(Bitmap image)
        //{
        //    _image = image;
        //}

        //public Image(string path)
        //{
        //    if (!File.Exists(path))
        //    {
        //        throw new FileNotFoundException("File not found.", path);
        //    }
        //    _image = new Bitmap(path);
        //}

        public byte[] GetBytes()
        {
            return File.ReadAllBytes("./binary.bin");
        }
    }
}

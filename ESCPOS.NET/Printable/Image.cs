using System;
using System.IO;
using System.Linq;
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
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }
            _image = new Bitmap(path);
        }

        public byte[] GetBytes()
        {
            int width = _image.Width;
            int height = _image.Height;

            byte[,] imgArray = new byte[width, height];

            if (width != 384 || height > 65635)
            {
                throw new Exception("Image width must be 384px, height cannot exceed 65635px.");
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < (width / 8); x++)
                {
                    imgArray[x, y] = 0;
                    for (byte n = 0; n < 8; n++)
                    {
                        Color pixel = _image.GetPixel(x * 8 + n, y);
                        if (pixel.GetBrightness() > 0.5)
                        {
                            imgArray[x, y] += (byte)(1 << n);
                        }
                    }
                }
            }

            List<byte> bytes = new List<byte> { 18, 118, (byte)(height & 255), (byte)(height >> 8) };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < (width / 8); x++)
                {
                    bytes.Add(imgArray[x, y]);
                }
            }

            return bytes.ToArray();
        }
    }
}

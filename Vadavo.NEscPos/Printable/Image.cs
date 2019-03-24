using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Vadavo.NEscPos.Printable
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
                throw new FileNotFoundException("File not found.", path);
            
            _image = new Bitmap(path);
        }
        
        public byte[] GetBytes()
        {
            byte[] imageBytes;
            
            using (var stream = new MemoryStream())
            {
                _image.Save(stream, ImageFormat.Bmp);
                imageBytes = stream.ToArray();
            }

            return _generateHeader()
                .Concat(imageBytes)
                .ToArray();
        }

        private byte[] _generateHeader()
        {
            var widthBytes = (_image.Width + 7) / 8;
            var heightPixels = _image.Height;
            
            return new[] {(byte) Control.GroupSeparator, (byte) 'v', (byte) 0, Convert.ToByte(3)}
                .Concat(_intLowHigh(widthBytes, 2))
                .Concat(_intLowHigh(heightPixels, 2))
                .ToArray();
        }

        private static byte[] _intLowHigh(int input, int length)
        {
            var output = string.Empty;

            for (var i = 0; i < length; i++)
            {
                output += (char) input % 256;
                input = input / 256;
            }

            return Encoding.Default.GetBytes(output);
        }
    }
}

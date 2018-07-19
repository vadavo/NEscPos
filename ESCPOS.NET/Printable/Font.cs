using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ESCPOS.NET.Printable
{
    public enum FontMode
    {
        FontA = 0,
        FontB = 1,
        Emphasized = 8,
        DoubleHeight = 16,
        DoubleWidth = 32,
        Underline = 128,
    }

    public class Font : IPrintable
    {
        private FontMode[] _mode;

        public Font(params FontMode[] mode)
        {
            if (mode == null)
            {
                mode = new[] {FontMode.FontA};
            }

            _mode = mode;
        }

        public Font(FontMode mode = FontMode.FontA)
        {
            _mode = new[] {mode};
        }

        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            foreach (var mode in _mode)
            {
                bytes.AddRange(new[] { (byte) Control.Escape, (byte) '!' });
                bytes.Add((byte) mode);
            }

            return bytes.ToArray();
        }
    }
}

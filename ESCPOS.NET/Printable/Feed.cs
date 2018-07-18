using System;
using System.Collections.Generic;
using System.Text;

namespace ESCPOS.NET.Printable
{
    public class Feed : IPrintable
    {
        public byte[] GetBytes() => new[] {(byte) Control.LineFeed};
    }
}

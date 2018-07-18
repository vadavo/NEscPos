using System;
using System.Collections.Generic;
using System.Text;

namespace ESCPOS.NET.Printable
{
    public class Reset : IPrintable
    {
        public byte[] GetBytes() => new[] {(byte) Control.Escape, (byte) '@'};
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ESCPOS.NET.Printable
{
    public class Bytes : IPrintable
    {
        private readonly byte[] _bytes;

        public Bytes(byte[] bytes) => _bytes = bytes;
        public byte[] GetBytes() => _bytes;
    }
}

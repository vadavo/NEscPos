using System;
using System.Collections.Generic;
using System.Text;

namespace ESCPOS.NET.Printable
{
    public enum JustificationType
    {
        Left, Center, Right
    }

    public class Justification : IPrintable
    {
        private JustificationType _type;

        public Justification(JustificationType type = JustificationType.Left)
        {
            _type = type;
        }

        public byte[] GetBytes() => new[] { (byte) Control.Escape, (byte) 'a', (byte) _type };
    }
}

using ESCPOS.NET.Connectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using ESCPOS.NET.Printable;

namespace ESCPOS.NET
{
    public class Printer : IPrinter
    {
        private IPrintConnector _connector;

        public Printer(IPrintConnector connector)
        {
            _connector = connector;
        }

        public void Cut(int lines = 3)
        {
            _connector.Write(_encodeUTF8(Control.GROUP_SEPARATOR + "V" + Char.ConvertFromUtf32(65) + Char.ConvertFromUtf32(lines)));
        }

        public void Feed()
        {
            _connector.Write(_encodeUTF8(Control.LINE_FEED));
        }

        public void Print(IPrintable printable)
        {
            _connector.Write(printable.GetBytes());
        }

        public void Print(string content)
        {
            _connector.Write(_encodeUTF8(content));
            Feed();
        }

        private byte[] _encodeUTF8(string content)
        {
            return Encoding.UTF8.GetBytes(content);
        }
    }
}

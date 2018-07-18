using ESCPOS.NET.Connectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Resources;
using ESCPOS.NET.Printable;

namespace ESCPOS.NET
{
    public class Printer : IPrinter, IDisposable
    {
        private readonly IPrintConnector _connector;

        public Printer(IPrintConnector connector)
        {
            _connector = connector;
            Reset();
        }

        ~Printer() => Dispose();

        public void Cut(CutType type = CutType.Full) => Print(new Cut(type));

        public void Feed() => Print(new Feed());

        public void Reset() => Print(new Reset());

        public void Print(IPrintable printable) => _connector.Write(printable.GetBytes());

        public void Print(string content)
        {
            _connector.Write(Encoding.UTF8.GetBytes(content));
            Feed();
        }

        public void Dispose()
        {
            Reset();
            _connector.Dispose();
        }
    }
}

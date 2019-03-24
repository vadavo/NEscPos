﻿using System;
using System.Text;
using Vadavo.NEscPos.Connectors;
using Vadavo.NEscPos.Printable;

namespace Vadavo.NEscPos
{
    public class Printer : IPrinter
    {
        private readonly IPrinterConnector _connector;

        public Printer(IPrinterConnector connector)
        {
            _connector = connector;
            Reset();
        }

        public void Cut(CutType type = CutType.Full) => Print(new Cut(type));

        public void Feed() => Print(new Feed());

        public void Reset() => Print(new Reset());

        public void Print(IPrintable printable) => _connector.Write(printable.GetBytes());

        public void Print(string content) => _connector.Write(new TextLine(content).GetBytes());

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Reset();
            
            _connector?.Dispose();
        }

        ~Printer() => Dispose(false);
    }
}

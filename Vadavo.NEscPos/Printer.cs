using System;
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
            this.Reset();
        }

        public void Print(IPrintable printable) => _connector.Write(printable.GetBytes());

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                this.Reset();
            
            _connector?.Dispose();
        }

        ~Printer() => Dispose(false);
    }
}

using System;

namespace Vadavo.NEscPos.Printable
{
    public class Bytes : IPrintable
    {
        private readonly byte[] _bytes;

        public Bytes(byte[] bytes) => _bytes = bytes;
        public byte[] GetBytes() => _bytes;
    }

    public static class BytesExtensions
    {
        public static void SendBytes(this IPrinter printer, byte[] bytes)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new Bytes(bytes));
        }
    }
}

using System;

namespace Vadavo.NEscPos.Printable
{
    public class Reset : IPrintable
    {
        public byte[] GetBytes() => new[] {(byte) Control.Escape, (byte) '@'};
    }

    public static class ResetExtensions
    {
        /// <summary>
        ///     Reset the printer.
        /// </summary>
        public static void Reset(this IPrinter printer)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new Reset());
        }
    }
}

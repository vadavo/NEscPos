using System;

namespace Vadavo.NEscPos.Printable
{
    public class Feed : IPrintable
    {
        public byte[] GetBytes() => new[] {(byte) Control.LineFeed};
    }

    public static class FeedExtensions
    {
        /// <summary>
        /// Feed the printer buffer.
        /// </summary>
        public static void Feed(this IPrinter printer)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new Feed());
        }
    }
}

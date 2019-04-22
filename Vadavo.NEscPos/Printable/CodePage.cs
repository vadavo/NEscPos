using System;

namespace Vadavo.NEscPos.Printable
{
    public enum CodePage
    {
        Default = 0,
        Pc437 = 0,
        Katakana = 1,
        Pc850 = 2,
        Pc860 = 3
    }
    
    public class SetCodePage : IPrintable
    {
        private readonly byte _codePage;
        
        public SetCodePage(CodePage codePage)
        {
            _codePage = (byte) codePage;
        }

        public SetCodePage(byte codePage)
        {
            _codePage = codePage;
        }

        public byte[] GetBytes()
        {
            return new[] {(byte) Control.Escape, (byte) 't', _codePage};
        }
    }

    public static class CodePageExtensions
    {
        public static void SetCodePage(this IPrinter printer, CodePage codePage)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new SetCodePage(codePage));
        }

        public static void SetCodePage(this IPrinter printer, byte codePage)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new SetCodePage(codePage));
        }
    }
}
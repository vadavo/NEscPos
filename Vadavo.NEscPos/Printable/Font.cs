using System;

namespace Vadavo.NEscPos.Printable
{
    [Flags]
    public enum FontMode
    {
        FontA = 0,
        FontB = 1,
        Emphasized = 8,
        DoubleHeight = 16,
        DoubleWidth = 32,
        Underline = 128,
    }

    public class Font : IPrintable
    {
        private FontMode _mode;

        public Font(FontMode mode = FontMode.FontA)
        {
            _mode = mode;
        }

        public byte[] GetBytes() =>
            new[] { (byte) Control.Escape, (byte) '!', (byte) _mode };
    }

    public static class FontExtensions
    {
        public static void SetFontMode(this IPrinter printer, FontMode fontMode = FontMode.FontA)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new Font(fontMode));
        }

        public static void SetFontA(this IPrinter printer) => printer.SetFontMode();
        public static void SetFontB(this IPrinter printer) => printer.SetFontMode(FontMode.FontB);
        public static void SetEmphasizedFont(this IPrinter printer) => printer.SetFontMode(FontMode.Emphasized);
        public static void SetDoubleHeightFont(this IPrinter printer) => printer.SetFontMode(FontMode.DoubleHeight);
        public static void SetDoubleWidthFont(this IPrinter printer) => printer.SetFontMode(FontMode.DoubleWidth);

        public static void SetDoubleFont(this IPrinter printer) =>
            printer.SetFontMode(FontMode.DoubleWidth | FontMode.DoubleHeight);
        
        public static void SetUnderlineFont(this IPrinter printer) => printer.SetFontMode(FontMode.Underline);
    }
}

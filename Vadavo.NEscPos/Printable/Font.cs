using System;
using Vadavo.NEscPos.Helpers;

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

    public class SetFont : IPrintable
    {
        private FontMode _mode;

        public SetFont(FontMode mode = FontMode.FontA)
        {
            _mode = mode;
        }

        public byte[] GetBytes() =>
            new[] { (byte) Control.Escape, (byte) '!', (byte) _mode };
    }

    public static class FontExtensions
    {
        public static void SetFont(this IPrinter printer, FontMode fontMode = FontMode.FontA)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new SetFont(fontMode));
        }

        public static void SetFontA(this IPrinter printer) => printer.SetFont();
        public static void SetFontB(this IPrinter printer) => printer.SetFont(FontMode.FontB);
        public static void SetEmphasizedFont(this IPrinter printer) => printer.SetFont(FontMode.Emphasized);
        public static void SetDoubleHeightFont(this IPrinter printer) => printer.SetFont(FontMode.DoubleHeight);
        public static void SetDoubleWidthFont(this IPrinter printer) => printer.SetFont(FontMode.DoubleWidth);

        public static void SetDoubleFont(this IPrinter printer) =>
            printer.SetFont(FontMode.DoubleWidth | FontMode.DoubleHeight);
        
        public static void SetUnderlineFont(this IPrinter printer) => printer.SetFont(FontMode.Underline);

        public static PrintableBuilder SetFont(this PrintableBuilder builder, FontMode fontMode = FontMode.FontA)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.Add(new SetFont(fontMode));
        }

        public static PrintableBuilder SetFontA(this PrintableBuilder builder) => builder.SetFont();

        public static PrintableBuilder SetFontB(this PrintableBuilder builder) => builder.SetFont(FontMode.FontB);

        public static PrintableBuilder SetEmphasizedFont(this PrintableBuilder builder) =>
            builder.SetFont(FontMode.Emphasized);

        public static PrintableBuilder SetDoubleHeightFont(this PrintableBuilder builder) =>
            builder.SetFont(FontMode.DoubleHeight);

        public static PrintableBuilder SetDoubleWidthFont(this PrintableBuilder builder) =>
            builder.SetFont(FontMode.DoubleWidth);

        public static PrintableBuilder SetDoubleFont(this PrintableBuilder builder) =>
            builder.SetFont(FontMode.DoubleWidth | FontMode.DoubleHeight);
    }
}

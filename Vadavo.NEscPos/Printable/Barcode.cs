using System;
using System.Linq;
using Vadavo.NEscPos.Helpers;

namespace Vadavo.NEscPos.Printable
{
    public enum BarcodeType
    {
        UpcA, UpcE, Ean13, Ean8, Code39, I25, Codebar, Code93, Code128, Code11, Msi
    }

    /// <summary>
    ///     A barcode printable implementation.
    /// </summary>
    /// <remarks>
    ///     This printable type reset the printer.
    /// </remarks>
    public class Barcode : IPrintable
    {
        private readonly string _content;
        private readonly int _height;
        private readonly BarcodeType _type;

        public Barcode(string content, int height = 32, BarcodeType type = BarcodeType.Code128)
        {
            _content = content;
            _height = height;
            _type = type;
        }

        public byte[] GetBytes()
        {
            return new PrintableBuilder()
                .Add(new Reset())
                .Add(new[] {(byte) Control.GroupSeparator, (byte) 'h', (byte) _height})
                .Add(new[] {(byte) Control.GroupSeparator, (byte) 'k', (byte) _type, (byte) _content.Length})
                .Add(_content.ToCharArray().Select(e => (byte) e))
                .Add(new[] {(byte) 0, (byte) _content.Length, (byte) 0})
                .Add(new Reset())
                .ToArray();
        }
    }

    public static class BarcodeExtensions
    {
        public static void PrintBarcode(this IPrinter printer, string content, int height = 32,
            BarcodeType barcodeType = BarcodeType.Code128)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new Barcode(content, height, barcodeType));
        }

        public static PrintableBuilder AddBarcode(this PrintableBuilder builder, string content = "", int height = 32,
            BarcodeType barcodeType = BarcodeType.Code128)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.Add(new Barcode(content, height, barcodeType));
        }
    }
}

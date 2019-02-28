using System.Linq;
using System.Text;

namespace Vadavo.NEscPos.Printable
{
    public enum BarcodeType
    {
        UpcA, UpcE, Ean12, Ean8, Code39, I25, Codebar, Code93, Code128, Code11, MSI
    }

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

        public byte[] GetBytes() =>
            new Reset().GetBytes() // Reset
                .Concat(new Justification(JustificationType.Center).GetBytes()) // Center
                .Concat(new[] { (byte)Control.GroupSeparator, (byte)'h', (byte)_height }) // Set barcode height
                .Concat(new[] { (byte)Control.GroupSeparator, (byte)'k', (byte)_type } // Set barcode type
                .Concat(Encoding.UTF8.GetBytes(_content)).Concat(new[] { (byte) 0, (byte) _content.Length, (byte) 0 })) // Set barcode content.
                .Concat(new Reset().GetBytes()) // Reset
                .ToArray();
    }
}

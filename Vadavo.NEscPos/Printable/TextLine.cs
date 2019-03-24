using System.Linq;
using System.Text;

namespace Vadavo.NEscPos.Printable
{
    public class TextLine : IPrintable
    {
        private readonly string _line;

        public TextLine(string line = "")
        {
            _line = line;
        }
        
        public byte[] GetBytes()
        {
            var lineBytes = Encoding.Convert(Encoding.Unicode, Encoding.GetEncoding("ISO-8859-1"),
                Encoding.Unicode.GetBytes(_line));

            return IsoCodePage.Concat(lineBytes).Concat(new Feed().GetBytes()).Concat(DefaultCodePage).ToArray();
        }

        private byte[] IsoCodePage => new[] {(byte) Control.Escape, (byte) 't', (byte) 37};
        private byte[] DefaultCodePage => new[] {(byte) Control.Escape, (byte) 't', (byte) 0};
    }
}
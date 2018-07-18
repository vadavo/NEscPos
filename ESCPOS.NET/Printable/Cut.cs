using System.Linq;

namespace ESCPOS.NET.Printable
{
    public enum CutType
    {
        Partial = 65,
        Full = 66,
    }

    public class Cut : IPrintable
    {
        private readonly CutType _type;

        public Cut(CutType type = CutType.Partial)
        {
            _type = type;
        }

        public byte[] GetBytes() => new[] {(byte) Control.GroupSeparator, (byte) 'V', (byte) _type}
            .Concat(new Feed().GetBytes()).Concat(new Reset().GetBytes()).ToArray();
    }
}

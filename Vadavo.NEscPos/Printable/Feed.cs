namespace Vadavo.NEscPos.Printable
{
    public class Feed : IPrintable
    {
        public byte[] GetBytes() => new[] {(byte) Control.LineFeed};
    }
}

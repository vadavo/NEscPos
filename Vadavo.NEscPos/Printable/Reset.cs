namespace Vadavo.NEscPos.Printable
{
    public class Reset : IPrintable
    {
        public byte[] GetBytes() => new[] {(byte) Control.Escape, (byte) '@'};
    }
}

namespace Vadavo.NEscPos.Printable
{
    public class Bytes : IPrintable
    {
        private readonly byte[] _bytes;

        public Bytes(byte[] bytes) => _bytes = bytes;
        public byte[] GetBytes() => _bytes;
    }
}

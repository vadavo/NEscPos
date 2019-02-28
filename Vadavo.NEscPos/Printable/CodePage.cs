namespace Vadavo.NEscPos.Printable
{
    public enum CodePageType
    {
        Default = 0,
        Cp437 = 1,
        Cp858 = 2,
        Cp852 = 3,
    }

    public class CodePage : IPrintable
    {
        private readonly CodePageType _type;

        public CodePage(CodePageType type = CodePageType.Default) => _type = type;

        public byte[] GetBytes() => new[] {(byte) Control.Escape, (byte) Control.GroupSeparator, (byte) 't', (byte) _type};
    }
}

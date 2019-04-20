using System.Collections.Generic;
using System.Linq;
using Vadavo.NEscPos.Printable;

namespace Vadavo.NEscPos.Helpers
{
    public class PrintableBuilder
    {
        private readonly IList<byte> _bytes = new List<byte>();

        public PrintableBuilder Add(IPrintable printable)
        {
            foreach (var @byte in printable.GetBytes())
                _bytes.Add(@byte);

            return this;
        }

        public PrintableBuilder Add(byte @byte)
        {
            _bytes.Add(@byte);

            return this;
        }

        public PrintableBuilder Add(IEnumerable<byte> bytes)
        {
            foreach (var @byte in bytes)
                Add(@byte);

            return this;
        }

        public byte[] ToArray() => _bytes.ToArray();
    }
}
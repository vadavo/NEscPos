using System.Linq;
using System.Collections.Generic;
using System.Text;
using ESCPOS.NET;

namespace ESCPOS.NET.Printable
{
    public class Code128 : IPrintable
    {
        private readonly string _content;

        public Code128(string content)
        {
            _content = content;
        }

        public byte[] GetBytes()
        {
            byte[] init = { 29, 107, 8 };
            byte[] content = System.Text.Encoding.UTF8.GetBytes(_content);
            byte[] end = { 0, (byte)_content.Length, 0 };

            return init.Concat(content).Concat(end).ToArray();
        }
    }
}

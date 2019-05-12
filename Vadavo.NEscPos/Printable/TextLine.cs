using System;
using System.Linq;
using System.Text;
using Vadavo.NEscPos.Helpers;

namespace Vadavo.NEscPos.Printable
{
    public class TextLine : IPrintable
    {
        private readonly string _content;
        private readonly bool _feed;
        private readonly byte _codePage;
        private readonly Encoding _encoding;

        public TextLine(string content = "", CodePage codePage = CodePage.Default, Encoding encoding = null, bool feed = true)
        {
            _content = content ?? throw new ArgumentNullException(nameof(content));
            _codePage = (byte) codePage;
            _encoding = encoding ?? DefaultEncoding;
            _feed = feed;
        }

        public TextLine(string content = "", byte codePage = 0, Encoding encoding = null, bool feed = true)
        {
            _content = content ?? throw new ArgumentNullException(nameof(content));
            _feed = feed;
            _codePage = codePage;
            _encoding = encoding ?? DefaultEncoding;
        }
        
        public byte[] GetBytes()
        {
            var builder = new PrintableBuilder();

            var contentBytes = _encoding.GetBytes(_content);
            
            builder
                .Add(new SetCodePage(_codePage))
                .Add(contentBytes);

            if (_feed)
                builder.Add(new Feed());

            builder.Add(new SetCodePage(CodePage.Default));

            return builder.ToArray();
        }
        
        public static Encoding DefaultEncoding => Encoding.GetEncoding("ISO-8859-1");
    }

    public static class TextLineExtensions
    {
        /// <summary>
        ///     Print a line of text.
        /// </summary>
        public static void PrintLine(this IPrinter printer, string content = "", CodePage codePage = CodePage.Default,
            Encoding encoding = null, bool feed = true)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            if (encoding == null)
                encoding = TextLine.DefaultEncoding;
            
            printer.Print(new TextLine(content, codePage, encoding, feed));
        }

        public static void PrintLine(this IPrinter printer, string content, byte codePage, Encoding encoding,
            bool feed = true)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));

            if (encoding == null)
                encoding = TextLine.DefaultEncoding;
            
            printer.Print(new TextLine(content, codePage, encoding, feed));
        }

        public static PrintableBuilder AddTextLine(this PrintableBuilder builder, string content = "",
            CodePage codePage = CodePage.Default, Encoding encoding = null, bool feed = true)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.Add(new TextLine(content, codePage, encoding, feed));
        }

        public static PrintableBuilder AddTextLine(this PrintableBuilder builder, string content, byte codePage,
            Encoding encoding, bool feed = true)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.Add(new TextLine(content, codePage, encoding, feed));
        }
    }
}
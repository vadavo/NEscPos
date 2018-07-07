using System;
using System.Collections.Generic;
using System.Text;

namespace ESCPOS.NET
{
    public class Control
    {
        public const string NULL = "\x00";

        public const string LINE_FEED = "\x0a";

        public const string ESC = "\x1b";

        public const string FORM_SEPARATOR = "\x1c";
        public const string FORM_FEED = "\x0c";

        public const string GROUP_SEPARATOR = "\x1d";

        public const string DATA_LINK_ESCAPE = "\x10";

        public const string END_OF_TRANSMISSION = "\x04";
    }
}

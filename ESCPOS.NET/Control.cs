using System;
using System.Collections.Generic;
using System.Text;

namespace ESCPOS.NET
{
    public enum Control
    {
        Null = 0x00,
        LineFeed = 0x0A,
        Escape = 0x1B,
        GroupSeparator = 0x1D
    }
}

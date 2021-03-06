﻿using System;
using System.Linq;
using Vadavo.NEscPos.Helpers;

namespace Vadavo.NEscPos.Printable
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

        public byte[] GetBytes()
        {
            return new[] {(byte) Control.GroupSeparator, (byte) 'V', (byte) _type}
                .Concat(new Feed().GetBytes())
                .ToArray();
        }
    }

    public static class CutExtensions
    {
        /// <summary>
        /// Cut the paper.
        /// </summary>
        public static void Cut(this IPrinter printer, CutType type = CutType.Partial)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new Cut(type));
        }

        public static PrintableBuilder Cut(this PrintableBuilder builder, CutType type = CutType.Partial)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.Add(new Cut(type));
        }
    }
}

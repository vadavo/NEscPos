using System;
using Vadavo.NEscPos.Printable;

namespace Vadavo.NEscPos
{
    public interface IPrinter : IDisposable
    {
        /// <summary>
        ///     Print an object.
        /// </summary>
        /// <param name="printable"></param>
        void Print(IPrintable printable);
    }
}

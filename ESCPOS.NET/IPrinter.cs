using ESCPOS.NET.Printable;
using System.Drawing;

namespace ESCPOS.NET
{
    public interface IPrinter
    {
        /// <summary>
        /// Cut the paper.
        /// </summary>
        /// <param name="lines">Lines to feed before cutting. Default to 3.</param>
        void Cut(int lines = 3);

        /// <summary>
        /// Feed the printer buffer.
        /// </summary>
        void Feed();

        /// <summary>
        /// Print a line of text.
        /// </summary>
        /// <param name="content">The content to print.</param>
        void Print(string content);

        /// <summary>
        /// Print an object.
        /// </summary>
        /// <param name="printable"></param>
        void Print(IPrintable printable);
    }
}

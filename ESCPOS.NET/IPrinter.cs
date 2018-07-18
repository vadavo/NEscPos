using ESCPOS.NET.Printable;
using System.Drawing;

namespace ESCPOS.NET
{
    public interface IPrinter
    {
        /// <summary>
        /// Cut the paper.
        /// </summary>
        /// <param name="type">Partial or full cut.</param>
        void Cut(CutType type = CutType.Full);

        /// <summary>
        /// Feed the printer buffer.
        /// </summary>
        void Feed();

        /// <summary>
        /// Print a line of text and feed.
        /// </summary>
        /// <param name="content">The content to print.</param>
        void Print(string content);

        /// <summary>
        /// Reset printer format to default.
        /// </summary>
        void Reset();

        /// <summary>
        /// Print an object.
        /// </summary>
        /// <param name="printable"></param>
        void Print(IPrintable printable);
    }
}

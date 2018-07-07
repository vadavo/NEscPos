using System.Drawing;

namespace ESCPOS.NET
{
    public interface IPrinter
    {
        /// <summary>
        /// Print text.
        /// </summary>
        /// <param name="content">The content to print.</param>
        void Print(string content);

        /// <summary>
        /// Print text and add new line.
        /// </summary>
        /// <param name="content">The content to print.</param>
        void PrintLine(string content);

        /// <summary>
        /// Encode string into barcode and print it.
        /// </summary>
        /// <param name="content">The content to encode.</param>
        void PrintBarCode(string content);

        /// <summary>
        /// Print an image.
        /// </summary>
        /// <param name="image">The image to print.</param>
        void PrintImage(Bitmap image);

        /// <summary>
        /// Print an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        void PrintImage(string path);

        /// <summary>
        /// Leave n lines in blank and cut the paper.
        /// </summary>
        /// <param name="lines">Lines to leave in blank. Default to 3.</param>
        void Cut(int lines = 3);
    }
}

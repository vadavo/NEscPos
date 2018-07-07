using System;
using System.Collections.Generic;
using System.Text;

namespace ESCPOS.NET.Connectors
{
    public interface IPrintConnector
    {
        /// <summary>
        /// Write data to the printer.
        /// </summary>
        /// <param name="data">The data to write.</param>
        void Write(byte[] data);

        /// <summary>
        /// Read data from the printer.
        /// </summary>
        /// <returns>The read data.</returns>
        byte[] Read();
    }
}

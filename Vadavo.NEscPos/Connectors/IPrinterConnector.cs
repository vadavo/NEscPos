using System;

namespace Vadavo.NEscPos.Connectors
{
    public interface IPrinterConnector : IDisposable
    {
        /// <summary>
        ///     Write data to the printer.
        /// </summary>
        /// <param name="data">The data to write.</param>
        void Write(byte[] data);

        /// <summary>
        ///     Read data from the printer.
        /// </summary>
        /// <returns>The read data.</returns>
        byte[] Read();
    }
}

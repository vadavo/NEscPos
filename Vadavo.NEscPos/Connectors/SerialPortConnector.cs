using System.IO;
using RJCP.IO.Ports;

namespace Vadavo.NEscPos.Connectors
{
    public class SerialPortConnector : IPrinterConnector
    {
        private readonly SerialPortStream _portStream;

        public SerialPortConnector(string portName, int baudRate)
        {
            _portStream = new SerialPortStream(portName, baudRate);
        }
        
        public void Write(byte[] data)
        {
            
        }

        public byte[] Read()
        {
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
            _portStream?.Close();
            _portStream?.Dispose();
        }
    }
}
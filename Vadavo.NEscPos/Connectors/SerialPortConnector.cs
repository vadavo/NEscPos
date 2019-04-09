using System.IO;
using RJCP.IO.Ports;

namespace Vadavo.NEscPos.Connectors
{
    public class SerialPortConnector : IPrinterConnector
    {
        private readonly SerialPortStream _portStream;
        private readonly BinaryWriter _writer;
        private readonly BinaryReader _reader;

        public SerialPortConnector(string portName, int baudRate)
        {
            _portStream = new SerialPortStream(portName, baudRate);
            _writer = new BinaryWriter(_portStream);
            _reader = new BinaryReader(_portStream);
        }
        
        public void Write(byte[] data)
        {
            _writer.Write(data);
        }

        public byte[] Read()
        {
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
            _reader?.Close();
            _reader?.Dispose();
            
            _writer?.Close();
            _writer?.Dispose();
            
            _portStream?.Close();
            _portStream?.Dispose();
        }
    }
}
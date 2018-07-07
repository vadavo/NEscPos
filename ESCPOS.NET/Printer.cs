using ESCPOS.NET.Connectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ESCPOS.NET
{
    public class Printer : IPrinter
    {
        private IPrintConnector _connector;

        public Printer(IPrintConnector connector)
        {
            _connector = connector;
        }

        public void Cut(int lines = 3)
        {
            throw new NotImplementedException();
        }

        public void Print(string content)
        {
            _connector.Write(Encoding.UTF8.GetBytes(content));
        }

        public void PrintBarCode(string content)
        {
            throw new NotImplementedException();
        }

        public void PrintImage(Bitmap image)
        {
            throw new NotImplementedException();
        }

        public void PrintImage(string path)
        {
            throw new NotImplementedException();
        }

        public void PrintLine(string content)
        {
            throw new NotImplementedException();
        }
    }
}

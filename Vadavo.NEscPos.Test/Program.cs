using System;
using System.Globalization;
using System.Net;
using Vadavo.NEscPos.Connectors;

namespace Vadavo.NEscPos.Test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("VADAVO NEscPos test program.");
            Console.WriteLine();

            using (var printer = _printMenu())
            {
                printer.Print("===Start fake ticket===");
                printer.Feed();
                printer.Feed();
                
                var ticket = new Ticket("Tech store!", "X123456789", new []
                {
                    new Product("SmartPhone", 2, 120.95m),
                    new Product("Smart TV", 1, 250.95m),
                    new Product("Computer game", 2, 19.95m),
                    new Product("Graphic card", 1, 650.49m),
                    new Product("SIM Card", 5, 14.99m),
                });
                
                printer.Print(ticket);
                
                printer.Reset();
                printer.Feed();
                printer.Feed();
                printer.Print("===End fake ticket===");
                
                printer.Cut();
            }
        }

        private static IPrinter _printMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Connect to printer via USB");
                Console.WriteLine("2. Connect to printer via serial port");
                Console.WriteLine("3. Connect to printer via TCP network");
                ConsoleHelpers.WriteErrorLine("0. Exit");

                var option = ConsoleHelpers.PromptKey("Select option:");
                Console.WriteLine();

                IPrinterConnector connector;

                switch (option.Key)
                {
                    case ConsoleKey.D1:
                        connector = _printUsbMenu();
                        break;
                    case ConsoleKey.D2:
                        connector = _printSerialMenu();
                        break;
                    case ConsoleKey.D3:
                        connector = _printNetworkMenu();
                        break;
                    case ConsoleKey.D0:
                        Environment.Exit(0);
                        continue;
                    default:
                        ConsoleHelpers.WriteErrorLine("Invalid option, try again.");
                        Console.WriteLine();
                        continue;
                }

                return new Printer(connector);
            }
        }

        private static IPrinterConnector _printUsbMenu()
        {
            throw new NotImplementedException();
        }

        private static IPrinterConnector _printSerialMenu()
        {
            var portName = ConsoleHelpers.PromptLine("Port name:");

            var baudRate = 0;
            var baudRateIsValid = false;
            while (!baudRateIsValid)
            {
                baudRateIsValid = int.TryParse(ConsoleHelpers.PromptLine("Baud rate:"), out baudRate);

                if (!baudRateIsValid)
                    ConsoleHelpers.WriteErrorLine("Baud rate must be an integer number, try again.");
            }

            return new SerialPortConnector(portName, baudRate);
        }

        private static IPrinterConnector _printNetworkMenu()
        {
            var addressIsValid = false;
            IPAddress ipAddress = null;
            while (!addressIsValid)
            {
                addressIsValid = IPAddress.TryParse(ConsoleHelpers.PromptLine("IP Address:"), out ipAddress);

                if (!addressIsValid)
                    ConsoleHelpers.WriteErrorLine("IP Address is not valid, try again.");
            }

            var portIsValid = false;
            int port = 0;
            while (!portIsValid)
            {
                if (int.TryParse(ConsoleHelpers.PromptLine("TCP Port (ej 9100):"), out port))
                    if (port >= 0 && port < 65535)
                        portIsValid = true;

                if (!portIsValid)
                    ConsoleHelpers.WriteErrorLine("Port number is not valid, try again.");
            }
            
            return new NetworkPrinterConnector(ipAddress, port);
        }
    }
}
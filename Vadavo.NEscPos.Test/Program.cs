using System;
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
                printer.Print("Hello!");
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Exit");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Select option: ");
                Console.ResetColor();
                var option = Console.ReadKey();
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
                        Console.WriteLine("Invalid option, try again.");
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
            throw new NotImplementedException();
        }

        private static IPrinterConnector _printNetworkMenu()
        {
            var addressIsValid = false;
            IPAddress ipAddress = null;
            while (!addressIsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("IP Address: ");
                Console.ResetColor();
                
                addressIsValid = IPAddress.TryParse(Console.ReadLine(), out ipAddress);

                if (!addressIsValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("IP Address is not valid, try again.");
                    Console.ResetColor();
                }
            }

            var portIsValid = false;
            int port = 0;
            while (!portIsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("TCP Port (ej 9100): ");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out port))
                    if (port >= 0 && port < 65535)
                        portIsValid = true;

                if (!portIsValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Port number is not valid, try again.");
                    Console.ResetColor();
                }
            }
            
            return new NetworkPrinterConnector(ipAddress, port);
        }
    }
}
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Port name: ");
            Console.ResetColor();
            var portName = Console.ReadLine();

            var baudRate = 0;
            var baudRateIsValid = false;
            while (!baudRateIsValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Baud rate: ");
                Console.ResetColor();
                baudRateIsValid = int.TryParse(Console.ReadLine(), out baudRate);

                if (!baudRateIsValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Baud rate must be an integer number, try again.");
                    Console.ResetColor();
                }
            }

            return new SerialPortConnector(portName, baudRate);
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
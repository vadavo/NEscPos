# NEscPos

NEscPos is open-source library for using ESC/POS thermal printers in a .NET project. NEscPos is implemented in .NET Stardard.

## Connectors

An connector is the bridge between the physical thermal printer and the `Vadavo.NEscPos.IPrinter` interface that represents the printer.

The connector tells the `Vadavo.NEscPos.Printer` class how the computer is connected with the thermal printer (network, USB, serial port, file, etc).

All connectors implements the `Vadavo.NEscPos.Connectors.IPrinterConnector` interface.

## Usage

The usage of NEscPos is very simple, first create a connector, then create the printer attaching the connector with the printer:

```
using (var connector = new Vadavo.NEscPos.Connectors.NetworkConnector("10.0.0.50", 9100))
using (var printer = new Vadavo.NEscPos.Printer(connector))
{
    printer.Reset();
    printer.Print("Hello from .NET");
    printer.Cut();
}

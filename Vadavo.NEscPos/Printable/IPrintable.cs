namespace Vadavo.NEscPos.Printable
{
    /// <summary>
    ///     The instance of the class that implements this interface,
    ///     can be printed with an ESC/POS printer.
    /// </summary>
    public interface IPrintable
    {
        /// <summary>
        ///     Get bytes to send to the printer.
        /// </summary>
        byte[] GetBytes();
    }
}

namespace Vadavo.NEscPos.Printable
{
    /// <summary>
    /// The instance of the class thats implements this interface,
    /// can print with an ESC/POS printer.
    /// </summary>
    public interface IPrintable
    {
        /// <summary>
        /// Get bytes to send to the printer.
        /// </summary>
        /// <returns></returns>
        byte[] GetBytes();
    }
}

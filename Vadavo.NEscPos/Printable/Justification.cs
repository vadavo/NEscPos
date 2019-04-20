using System;

namespace Vadavo.NEscPos.Printable
{
    public enum JustificationType
    {
        Left, Center, Right
    }

    public class Justification : IPrintable
    {
        private JustificationType _type;

        public Justification(JustificationType type = JustificationType.Left)
        {
            _type = type;
        }

        public byte[] GetBytes() => new[] { (byte) Control.Escape, (byte) 'a', (byte) _type };
    }

    public static class JustificationExtensions
    {
        public static void SetJustification(this IPrinter printer, JustificationType justificationType = JustificationType.Left)
        {
            if (printer == null)
                throw new ArgumentNullException(nameof(printer));
            
            printer.Print(new Justification(justificationType));
        }

        public static void SetLeftJustification(this IPrinter printer) => printer.SetJustification();

        public static void SetCenterJustification(this IPrinter printer) =>
            printer.SetJustification(JustificationType.Center);

        public static void SetRightJustification(this IPrinter printer) =>
            printer.SetJustification(JustificationType.Right);
    }
}

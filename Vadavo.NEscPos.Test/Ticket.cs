using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Vadavo.NEscPos.Printable;

namespace Vadavo.NEscPos.Test
{
    public class Ticket : IPrintable
    {
        public string CompanyName { get; set; }
        public string CompanyDocument { get; set; }
        public IEnumerable<Product> Products;

        public Ticket(string companyName, string companyDocument, IEnumerable<Product> products)
        {
            Products = products;
            CompanyName = companyName;
            CompanyDocument = companyDocument;
        }
        
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes = bytes
                .Concat(new Justification(JustificationType.Center).GetBytes())
                .Concat(new TextLine(CompanyName).GetBytes())
                .Concat(new Justification(JustificationType.Center).GetBytes())
                .Concat(new Font(FontMode.FontB).GetBytes())
                .Concat(new TextLine($"Doc. {CompanyDocument}").GetBytes())
                .Concat(new Feed().GetBytes())
                .Concat(new Feed().GetBytes())
                .Concat(new Justification().GetBytes())
                .ToList();

            bytes = Products.Aggregate(bytes, (current, product) => current
                .Concat(new Font().GetBytes())
                .Concat(new TextLine($"{product.Quantity} x {product.Name}").GetBytes())
                .Concat(new Font(FontMode.FontB).GetBytes())
                .Concat(new TextLine($"${product.PricePerUnit.ToString(CultureInfo.InvariantCulture)} x " +
                                     $"{product.Quantity} = ${product.TotalAmount.ToString(CultureInfo.InvariantCulture)}")
                    .GetBytes())
                .Concat(new Feed().GetBytes())
                .ToList());

            bytes = bytes.Concat(new Reset().GetBytes())
                .Concat(new Justification(JustificationType.Right).GetBytes())
                .Concat(new Font(FontMode.DoubleWidth).GetBytes())
                .Concat(new TextLine(
                    $"Total: ${Products.Sum(e => e.TotalAmount).ToString(CultureInfo.InvariantCulture)}").GetBytes())
                .ToList();

            bytes = bytes.Concat(new Reset().GetBytes())
                .Concat(new Feed().GetBytes())
                .Concat(new Justification(JustificationType.Center).GetBytes())
                .Concat(new Barcode(CompanyName).GetBytes())
                .ToList();

            return bytes.ToArray();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalAmount => PricePerUnit * Quantity;

        public Product(string name, int quantity, decimal pricePerUnit)
        {
            Name = name;
            Quantity = quantity;
            PricePerUnit = pricePerUnit;
        }
    }
}
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Vadavo.NEscPos.Helpers;
using Vadavo.NEscPos.Printable;

namespace Vadavo.NEscPos.Test
{
    public class Ticket : IPrintable
    {
        public string CompanyName { get; }
        public string CompanyDocument { get; }
        public IEnumerable<Product> Products { get; }

        public Ticket(string companyName, string companyDocument, IEnumerable<Product> products)
        {
            Products = products;
            CompanyName = companyName;
            CompanyDocument = companyDocument;
        }
        
        public byte[] GetBytes()
        {
            var builder = new PrintableBuilder();

            builder
                .Add(new Justification(JustificationType.Center))
                .Add(new TextLine(CompanyName))
                .Add(new Font(FontMode.FontB))
                .Add(new TextLine($"Doc. {CompanyDocument}"))
                .Add(new Feed())
                .Add(new Feed())
                .Add(new Justification());

            foreach (var product in Products)
            {
                builder
                    .Add(new Font())
                    .Add(new TextLine($"{product.Quantity} x {product.Name}"))
                    .Add(new Font(FontMode.FontB))
                    .Add(new TextLine($"${product.PricePerUnit.ToString(CultureInfo.InvariantCulture)} x " +
                                      $"{product.Quantity} = ${product.TotalAmount.ToString(CultureInfo.InvariantCulture)}"))
                    .Add(new Feed());
            }

            builder
                .Add(new Justification(JustificationType.Right))
                .Add(new Font(FontMode.DoubleWidth | FontMode.Underline))
                .Add(new TextLine($"Total: ${Products.Sum(e => e.TotalAmount).ToString(CultureInfo.InvariantCulture)}"))
                .Add(new Reset())
                .Add(new Feed())
                .Add(new Barcode(CompanyName));

            return builder.ToArray();
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
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
                .SetCenterJustification()
                .AddTextLine(CompanyName)
                .SetFontB()
                .AddTextLine($"Doc. {CompanyDocument}")
                .Feed()
                .Feed()
                .SetJustification();

            foreach (var product in Products)
            {
                builder
                    .SetFont()
                    .AddTextLine($"{product.Quantity} x {product.Name}")
                    .SetFontB()
                    .AddTextLine($"${product.PricePerUnit.ToString(CultureInfo.InvariantCulture)} x " +
                                 $"{product.Quantity} = ${product.TotalAmount.ToString(CultureInfo.InvariantCulture)}")
                    .Feed();
            }

            builder
                .SetRightJustification()
                .SetDoubleFont()
                .AddTextLine($"Total: ${Products.Sum(e => e.TotalAmount).ToString(CultureInfo.InvariantCulture)}")
                .Reset()
                .Feed()
                .AddBarcode(CompanyName);

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
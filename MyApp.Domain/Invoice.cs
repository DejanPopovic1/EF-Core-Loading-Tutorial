using System.Collections.Generic;

namespace MyApp.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Item> Items { get; set; }
        public Customer Customer { get; set; }

        //public ICollection<Item> Items { get; set; }
        //public Customer Customer { get; set; }
    }
}

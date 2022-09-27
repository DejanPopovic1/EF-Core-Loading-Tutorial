using System.Collections.Generic;

namespace MyApp.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        //public virtual ICollection<Invoice> Invoices { get; set; }
    }
}

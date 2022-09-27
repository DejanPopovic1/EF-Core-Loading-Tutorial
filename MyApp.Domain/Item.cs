namespace MyApp.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        //public Invoice Invoice { get; set; }
    }
}

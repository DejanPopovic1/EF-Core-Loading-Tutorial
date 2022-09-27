using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using System.Linq;

namespace MyApp
{
    class Program
    {
        private static MyContext _context = new MyContext();
        static void Main(string[] args)
        {
            NoLoading();
            EagerLoading1();
            EagerLoading2();
            EagerLoading3();
            EagerLoading4();
            LazyLoading1();
            LazyLoading2();
            ExplicitLoading();
        }

        static void NoLoading()
        {
            var noLoading = _context.Invoices.ToList();
        }

        static void EagerLoading1()
        {
            var eagerLoading = _context.Invoices
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .ToList();
        }

        static void EagerLoading2()
        {
            var invoices = _context.Invoices.Include(x => x.Items).ToList();
            foreach (var invoice in invoices)
            {
                var items = invoice.Items;
            }
        }

        static void EagerLoading3()
        {
            var eagerLoading = _context.Customers
                .Include(x => x.Invoices)
                .ThenInclude(x => x.Items)
                .ToList();
        }

        static void EagerLoading4()
        {
            var eagerLoading = _context.Invoices
                .Include(x => x.Items.Where(y => y.Price >= 500))
                .ToList();
        }

        static void LazyLoading1()
        {
            var invoices = _context.Invoices.ToList();
            foreach (var invoice in invoices)
            {
                var items = invoice.Items;
            }
        }

        static void LazyLoading2()
        {
            var invoices = _context.Invoices.Include(x => x.Items);
            foreach (var invoice in invoices)
            {
                var items = invoice.Items;
            }
        }

        static void ExplicitLoading()
        {
            var explicitLoading = _context.Invoices.Find(1);
            //Business Logic
            _context.Entry(explicitLoading).Collection(x => x.Items).Load();
            _context.Entry(explicitLoading).Reference(x => x.Customer).Load();
        }
    }
}

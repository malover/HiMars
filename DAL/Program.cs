using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var contextOptions = new DbContextOptionsBuilder<WarehouseContext>()
            //   .UseSqlServer(@"Server=DESKTOP-7SP73R7;Database=HiMarsWarehouse_db;Trusted_Connection=True;MultipleActiveResultSets=true")
            //   .Options;
            //var _context = new WarehouseContext(contextOptions);

            //foreach (var item in _context.Categories)
            //{
            //    _context.Remove(item);
            //}

            //foreach (var item in _context.Goods)
            //{
            //    _context.Remove(item);
            //}
            //_context.SaveChanges();
            //DbInitializer.Initialize(_context);
        }
    }
}
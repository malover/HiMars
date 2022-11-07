using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContextFactory : IDesignTimeDbContextFactory<WarehouseContext>
    {
        public WarehouseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7SP73R7;Database=HiMarsWarehouse_db;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new WarehouseContext(optionsBuilder.Options);
        }
    }
}

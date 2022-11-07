using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Good
    {
        public Guid GoodId { get; set; }
        public string GoodName { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

    }
}

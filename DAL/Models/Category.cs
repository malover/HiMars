using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Good> Goods { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GoodDTO_full
    {
        public string GoodName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string CategoryName { get; set; }
    }
}

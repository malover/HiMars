using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CategoryDTO_full
    {
        public string CategoryName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<GoodDTO_short> Goods { get; set; }
    }
}

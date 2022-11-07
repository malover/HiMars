using AutoMapper;
using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Profiles
{
    public class CategoryProfile
    {
        public IMapper CategoryMapper { get; set; }
        public CategoryProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO_short>();
                cfg.CreateMap<Category, CategoryDTO_full>();
                cfg.CreateMap<CategoryDTO_full, Category>();
            });
            IMapper mapper = config.CreateMapper();
            CategoryMapper = mapper;
        }
    }
}

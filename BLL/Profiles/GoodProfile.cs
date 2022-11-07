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
    public class GoodProfile : Profile
    {
        public IMapper GoodMapper { get; set; }
        public GoodProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Good, GoodDTO_short>();
                cfg.CreateMap<Good, GoodDTO_full>();
                cfg.CreateMap<GoodDTO_full, Good>();
            });
            IMapper mapper = config.CreateMapper();
            GoodMapper = mapper;
        }
    }
}

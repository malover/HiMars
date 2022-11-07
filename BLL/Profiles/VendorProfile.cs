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
    public class VendorProfile
    {
        public IMapper VendorMapper { get; set; }
        public VendorProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vendor, VendorDTO>();
                cfg.CreateMap<VendorDTO, Vendor>();
            });
            IMapper mapper = config.CreateMapper();
            VendorMapper = mapper;
        }
    }
}

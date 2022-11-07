using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class VendorController
    {
        private readonly UnitOfWork _unitOfWork;

        public VendorController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Vendor> GetVendors()
        {
            return _unitOfWork.VendorRepository.GetAll().ToList();
        }

        public Vendor GetVendorById(Guid id)
        {
            return _unitOfWork.VendorRepository.GetById(id);
        }

        public void AddVendor(Vendor vendor)
        {
            _unitOfWork.VendorRepository.Add(vendor);
            _unitOfWork.Save();
        }

        public void EditVendor(Vendor vendor)
        {
            _unitOfWork.VendorRepository.Edit(vendor);
            _unitOfWork.Save();
        }

        public void DeleteVendor(Guid id)
        {
            _unitOfWork.VendorRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}

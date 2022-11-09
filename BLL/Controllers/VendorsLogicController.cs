using AutoMapper;
using BLL.DTO;
using BLL.Profiles;
using DAL.Controllers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public class VendorsLogicController
    {
        private readonly IMapper _mapper;
        private readonly VendorController _vendorController;

        public VendorsLogicController()
        {
            _vendorController = new VendorController();
            var profile = new VendorProfile();
            _mapper = profile.VendorMapper;
        }

        public ObservableCollection<VendorDTO> GetAllVendors()
        {
            var vendors = _vendorController.GetVendors().ToList();

            var vendorsDTO = new ObservableCollection<VendorDTO>();

            foreach (var vendor in vendors)
            {
                var vendorDTO = _mapper.Map<Vendor, VendorDTO>(vendor);
                vendorsDTO.Add(vendorDTO);
            }
            return vendorsDTO;
        }

        public void DeleteVendorByName(string name, string lname)
        {
            var vendor = _vendorController.GetVendors().SingleOrDefault(x => x.FirstName == name && x.LastName == lname);

            _vendorController.DeleteVendor(vendor.VendorId);
        }

        public void CreateNewVendor(string firstName, string lastName)
        {
            var vendorDTO = new VendorDTO { FirstName = firstName, LastName = lastName };

            var vendor = _mapper.Map<VendorDTO, Vendor>(vendorDTO);

            _vendorController.AddVendor(vendor);
        }

        public void EditVendor(string firstName, string lastName, VendorDTO original)
        {
            var vendorDB = _vendorController.GetVendors().SingleOrDefault(x => x.FirstName == original.FirstName);
            vendorDB.FirstName = firstName;
            vendorDB.LastName = lastName;

            _vendorController.EditVendor(vendorDB);
        }

        public string CheckDataValid(string firstName, string lastName)
        {
            Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
            string errorMessage = string.Empty;

            if (!regex.IsMatch(firstName))
            {
                errorMessage += "*Fist name can only contain letters, start with capital letter, and contain one word; \n";
            }
            if (!regex.IsMatch(lastName))
            {
                errorMessage += "*Last name can only contain letters, start with capital letter, and contain one word; \n";
            }
            if (_vendorController.GetVendors().Where(x => x.FirstName == firstName && x.LastName == lastName).Count() > 0)
            {
                errorMessage += "*This vendor is already presented in the list.; \n";
            }
            return errorMessage;
        }

        public ObservableCollection<VendorDTO> SortByFirstName(ObservableCollection<VendorDTO> list, int counter)
        {
            var sortedList = new List<VendorDTO>();
            if (counter == 0)
            {
                sortedList = list.OrderBy(x => x.FirstName).ToList();
            }
            else
            {
                sortedList = list.OrderByDescending(x => x.FirstName).ToList();
            }
            var returnList = new ObservableCollection<VendorDTO>();
            foreach (var item in sortedList)
            {
                returnList.Add(item);
            }
            return returnList;
        }

        public ObservableCollection<VendorDTO> SortByLastName(ObservableCollection<VendorDTO> list, int counter)
        {
            var sortedList = new List<VendorDTO>();
            if (counter == 0)
            {
                sortedList = list.OrderBy(x => x.LastName).ToList();
            }
            else
            {
                sortedList = list.OrderByDescending(x => x.LastName).ToList();
            }
            var returnList = new ObservableCollection<VendorDTO>();
            foreach (var item in sortedList)
            {
                returnList.Add(item);
            }
            return returnList;
        }
    }
}

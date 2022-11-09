using BLL.Controllers;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestVendorLogicController
    {
        private VendorsLogicController _vendorsLogicController;

        [Fact]
        public void TestVendorLogicController_GetAllVendors()
        {
            //Arrange
            _vendorsLogicController = new VendorsLogicController();
            //Act
            var list = _vendorsLogicController.GetAllVendors();
            //Assert
            Assert.NotEmpty(list);
        }

        [Fact]
        public void TestVendorLogicController_CheckValidData_ValidInput()
        {
            //Arrange
            _vendorsLogicController = new VendorsLogicController();
            string vendorFirstName = "Name";
            string vendorLastName = "Surname";
            string expected = string.Empty;
            //Act
            string actual = _vendorsLogicController.CheckDataValid(vendorFirstName, vendorLastName);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestVendorLogicController_CheckValidData_InvalidInput()
        {
            //Arrange
            _vendorsLogicController = new VendorsLogicController();
            string vendorFirstName = "!@#!@#";
            string vendorLastName = "!@#!@#";
            string expected = "*Fist name can only contain letters, start with capital letter, and contain one word; \n*Last name can only contain letters, start with capital letter, and contain one word; \n";
            //Act
            string actual = _vendorsLogicController.CheckDataValid(vendorFirstName, vendorLastName);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestVendorLogicController_CheckValidData_CategoryNameRepeat()
        {
            //Arrange
            _vendorsLogicController = new VendorsLogicController();
            string vendorFirstName = "Sam";
            string vendorLastName = "Wilkins";
            string expected = "*This vendor is already presented in the list.; \n";
            //Act
            string actual = _vendorsLogicController.CheckDataValid(vendorFirstName, vendorLastName);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestVendorLogicController_SortByFirstName_ByAscendingOrder()
        {
            //Arrange
            _vendorsLogicController = new VendorsLogicController();
            //Here we can add whatever amount of vendors we want to then sort it
            var vendor1 = new VendorDTO {FirstName = "Somename", LastName = "Somesurname" };

            var vendors = new ObservableCollection<VendorDTO>();
            vendors.Add(vendor1);
            var expected = new ObservableCollection<VendorDTO>();
            expected.Add(vendor1);
            int order = 0; // 0 - is for ascending order
            //Act
            var actual = _vendorsLogicController.SortByFirstName(vendors, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestVendorLogicController_SortByFirstName_ByDescendingOrder()
        {
            //Arrange
            _vendorsLogicController = new VendorsLogicController();
            //Here we can add whatever amount of vendors we want to then sort it
            var vendor1 = new VendorDTO { FirstName = "Somename", LastName = "Somesurname" };

            var vendors = new ObservableCollection<VendorDTO>();
            vendors.Add(vendor1);
            var expected = new ObservableCollection<VendorDTO>();
            expected.Add(vendor1);
            int order = 1; // 0 - is for ascending order
            //Act
            var actual = _vendorsLogicController.SortByFirstName(vendors, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestVendorLogicController_SortByLastName_ByAscendingOrder()
        {
            //Arrange
            _vendorsLogicController = new VendorsLogicController();
            //Here we can add whatever amount of vendors we want to then sort it
            var vendor1 = new VendorDTO { FirstName = "Somename", LastName = "Somesurname" };

            var vendors = new ObservableCollection<VendorDTO>();
            vendors.Add(vendor1);
            var expected = new ObservableCollection<VendorDTO>();
            expected.Add(vendor1);
            int order = 0; // 0 - is for ascending order
            //Act
            var actual = _vendorsLogicController.SortByLastName(vendors, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestVendorLogicController_SortByLastName_ByDescendingOrder()
        {
            //Arrange
            _vendorsLogicController = new VendorsLogicController();
            //Here we can add whatever amount of vendors we want to then sort it
            var vendor1 = new VendorDTO { FirstName = "Somename", LastName = "Somesurname" };

            var vendors = new ObservableCollection<VendorDTO>();
            vendors.Add(vendor1);
            var expected = new ObservableCollection<VendorDTO>();
            expected.Add(vendor1);
            int order = 1; // 0 - is for ascending order
            //Act
            var actual = _vendorsLogicController.SortByLastName(vendors, order);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}

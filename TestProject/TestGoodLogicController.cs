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
    public class TestGoodLogicController
    {
        private GoodLogicController _goodLogicController;

        [Fact]
        public void TestGoodLogicController_GetAllGoods_shortDescription()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            //Act
            var list = _goodLogicController.GetAllGoods_shortDescription();
            //Assert
            Assert.NotEmpty(list);
        }

        [Fact]
        public void TestGoodLogicController_GetGoodByName_fullDescription()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            var expected = new GoodDTO_full { GoodName = "Here is just some toy", ShortDescription = "Here is just some toy", LongDescription = "Here is just some toy", Price = 100.00m, Brand = "HotWheels", Quantity = 20 };
            //Act
            var actual = _goodLogicController.GetGoodByName_fullDescription("Here is just some toy");
            //Assert
            Assert.Equal(expected.GoodName, actual.GoodName);
            Assert.Equal(expected.ShortDescription, actual.ShortDescription);
            Assert.Equal(expected.LongDescription, actual.LongDescription);
            Assert.Equal(expected.Brand, actual.Brand);
            Assert.Equal(expected.Quantity, actual.Quantity);
        }

        [Fact]
        public void TestGoodLogicController_CheckValidData_ValidData()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            string goodName = "Here is just some toy new";
            string shortDescription = "Here is just some toy.";
            string longDescription = "Here is just some toy";
            decimal price = 100.00m;
            string brand = "HotWheels";
            int quantity = 20;
            string categoryName = "Toys";


            string expected = string.Empty;
            //Act
            string actual = _goodLogicController.CheckDateValid(goodName, shortDescription, longDescription, quantity, price, brand, categoryName);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_CheckValidData_InvalidData()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            string goodName = "^!@#^!@^#";
            string shortDescription = "!#!@#";
            string longDescription = "!@#!@#";
            decimal price = -100m;
            string brand = "!@#!@#";
            int quantity = -100;
            string categoryName = "Toys";

            string expected = "*Good name: only letters and digits available; \n*Good short description: only letters and digits available; \n*Good long description: only letters and digits available; \n*Quantity: put the number in range from 0 to 9999; \n*Price: put the number in range from 0 to 999999; \n*Good brand: only letters and digits available; \n";
            //Act
            string actual = _goodLogicController.CheckDateValid(goodName, shortDescription, longDescription, quantity, price, brand, categoryName);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_CheckValidData_GoodNameRepeat()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            string goodName = "Here is just some toy";
            string shortDescription = "Here is just some toy.";
            string longDescription = "Here is just some toy";
            decimal price = 100.00m;
            string brand = "HotWheels";
            int quantity = 20;
            string categoryName = "Toys";

            string expected = $"*Good name: good with this name already exist in category: {categoryName}; \n";
            //Act
            string actual = _goodLogicController.CheckDateValid(goodName, shortDescription, longDescription, quantity, price, brand, categoryName);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_SortByPrice_ByAscendingOrder()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            //Here we can add whatever amount of goods we want to then sort it
            var good1 = new GoodDTO_short { GoodName = "Here is just some toy", ShortDescription = "Here is just some toy", Price = 100.00m, Brand = "HotWheels", Quantity = 20 };

            var goods = new ObservableCollection<GoodDTO_short>();
            goods.Add(good1);
            var expected = new ObservableCollection<GoodDTO_short>();
            expected.Add(good1);
            int order = 0; // 0 - is for ascending order
            //Act
            var actual = _goodLogicController.SortByPrice(goods, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_SortByPrice_ByDescendingOrder()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            //Here we can add whatever amount of goods we want to then sort it
            var good1 = new GoodDTO_short { GoodName = "Here is just some toy", ShortDescription = "Here is just some toy", Price = 100.00m, Brand = "HotWheels", Quantity = 20 };

            var goods = new ObservableCollection<GoodDTO_short>();
            goods.Add(good1);
            var expected = new ObservableCollection<GoodDTO_short>();
            expected.Add(good1);
            int order = 1; // 1 - is for descending order
            //Act
            var actual = _goodLogicController.SortByPrice(goods, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_SortByBrand_ByAscendingOrder()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            //Here we can add whatever amount of goods we want to then sort it
            var good1 = new GoodDTO_short { GoodName = "Here is just some toy", ShortDescription = "Here is just some toy", Price = 100.00m, Brand = "HotWheels", Quantity = 20 };

            var goods = new ObservableCollection<GoodDTO_short>();
            goods.Add(good1);
            var expected = new ObservableCollection<GoodDTO_short>();
            expected.Add(good1);
            int order = 0; // 0 - is for ascending order
            //Act
            var actual = _goodLogicController.SortByBrand(goods, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_SortByBrand_ByDescendingOrder()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            //Here we can add whatever amount of goods we want to then sort it
            var good1 = new GoodDTO_short { GoodName = "Here is just some toy", ShortDescription = "Here is just some toy", Price = 100.00m, Brand = "HotWheels", Quantity = 20 };

            var goods = new ObservableCollection<GoodDTO_short>();
            goods.Add(good1);
            var expected = new ObservableCollection<GoodDTO_short>();
            expected.Add(good1);
            int order = 1; // 1 - is for descending order
            //Act
            var actual = _goodLogicController.SortByBrand(goods, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_SortByName_ByAscendingOrder()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            //Here we can add whatever amount of goods we want to then sort it
            var good1 = new GoodDTO_short { GoodName = "Here is just some toy", ShortDescription = "Here is just some toy", Price = 100.00m, Brand = "HotWheels", Quantity = 20 };

            var goods = new ObservableCollection<GoodDTO_short>();
            goods.Add(good1);
            var expected = new ObservableCollection<GoodDTO_short>();
            expected.Add(good1);
            int order = 0; // 0 - is for ascending order
            //Act
            var actual = _goodLogicController.SortByName(goods, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_SortByName_ByDescendingOrder()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            //Here we can add whatever amount of goods we want to then sort it
            var good1 = new GoodDTO_short { GoodName = "Here is just some toy", ShortDescription = "Here is just some toy", Price = 100.00m, Brand = "HotWheels", Quantity = 20 };

            var goods = new ObservableCollection<GoodDTO_short>();
            goods.Add(good1);
            var expected = new ObservableCollection<GoodDTO_short>();
            expected.Add(good1);
            int order = 1; // 1 - is for descending order
            //Act
            var actual = _goodLogicController.SortByName(goods, order);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGoodLogicController_GetAllGoodsForCategoryByName_name_amount()
        {
            //Arrange
            _goodLogicController = new GoodLogicController();
            string categoryName = "Toys";
            //Act
            var list = _goodLogicController.GetAllGoodsForCategoryByName_name_amount("Toys");

            //Assert
            Assert.NotNull(list);
        }
    }
}

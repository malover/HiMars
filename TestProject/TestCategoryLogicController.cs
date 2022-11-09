using BLL.DTO;
using DAL.Models;

namespace TestProject
{
    public class TestCategoryLogicController
    {
        private CategoryLogicContoller _categoryLogicContoller;
        [Fact]
        public void TestCategoryLogicController_GetAllCategories_shortDescription()
        {
            //Arrange
            _categoryLogicContoller = new CategoryLogicContoller();
            //Act
            var list = _categoryLogicContoller.GetAllCategories_shortDescription();
            //Assert
            Assert.NotEmpty(list);
        }

        [Fact]
        public void TestCategoryLogicController_GetCategoryByName_fullDescription()
        {
            //Arrange
            _categoryLogicContoller = new CategoryLogicContoller();
            var expected = new CategoryDTO_full { CategoryName = "Toys", Goods = new List<GoodDTO_short>(), ShortDescription = "Here is some short des", LongDescription = "Here is some long des" };
            //Act
            var actual = _categoryLogicContoller.GetCategoryByName_fullDescription("Toys");
            //Assert
            Assert.Equal(expected.CategoryName, actual.CategoryName);
            Assert.Equal(expected.ShortDescription, actual.ShortDescription);
            Assert.Equal(expected.LongDescription, actual.LongDescription);
        }

        [Fact]
        public void TestCategoryLogicController_CheckValidData_ValidInput()
        {
            //Arrange
            _categoryLogicContoller = new CategoryLogicContoller();
            string categoryName = "Something";
            string shortDescription = "Valid short description.";
            string longDescription = "Valid long description";
            var category = new CategoryDTO_short { CategoryName = categoryName, ShortDescription = shortDescription };
            string shortcat = category.CategoryName;
            string shortdis = category.ShortDescription;
            string expected = string.Empty;
            //Act
            string actual = _categoryLogicContoller.CheckDataValid(categoryName, shortDescription, longDescription);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCategoryLogicController_CheckValidData_InvalidInput()
        {
            //Arrange
            _categoryLogicContoller = new CategoryLogicContoller();
            string categoryName = "^#@!&#^!@#";
            string shortDescription = "!@#!@#.";
            string longDescription = "!@#!@#!@#";

            string expected = "*Category name: only letters and digits available;*Category short description: only letters and digits available;*Category long description: only letters and digits available;";
            //Act
            string actual = _categoryLogicContoller.CheckDataValid(categoryName, shortDescription, longDescription);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCategoryLogicController_CheckValidData_CategoryNameRepeat()
        {
            //Arrange
            _categoryLogicContoller = new CategoryLogicContoller();
            string categoryName = "Toys";
            string shortDescription = "Valid short description.";
            string longDescription = "Valid long description";

            string expected = "*Category name: category with this name already exist;";
            //Act
            string actual = _categoryLogicContoller.CheckDataValid(categoryName, shortDescription, longDescription);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
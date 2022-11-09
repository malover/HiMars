using AutoMapper;
using BLL.DTO;
using BLL.Profiles;
using DAL.Controllers;
using DAL.Models;

namespace BLL.Controllers
{
    public class CategoryLogicContoller
    {
        private readonly CategoryController _categoryController;
        private readonly IMapper _mapper;

        public CategoryLogicContoller()
        {
            _categoryController = new CategoryController();
            var profile = new CategoryProfile();
            _mapper = profile.CategoryMapper;
        }

        public List<CategoryDTO_short> GetAllCategories_shortDescription()
        {
            var categories = _categoryController.GetCategories().ToList();

            var categoriesDTO = new List<CategoryDTO_short>();

            foreach (var category in categories)
            {
                var categoryDTO = _mapper.Map<Category, CategoryDTO_short>(category);
                categoriesDTO.Add(categoryDTO);
            }
            return categoriesDTO;
        }

        public CategoryDTO_full GetCategoryByName_fullDescription(string name)
        {
            var category = _categoryController.GetCategories().Where(x => x.CategoryName == name).FirstOrDefault();

            return _mapper.Map<Category, CategoryDTO_full>(category);
        }

        public void CreateNewCategory(string categoryName, string shortDescription, string longDescription)
        {
            var categoryDTO = new CategoryDTO_full { CategoryName = categoryName, ShortDescription = shortDescription, LongDescription = longDescription };
            var categoryDB = _mapper.Map<CategoryDTO_full, Category>(categoryDTO);

            _categoryController.AddCategory(categoryDB);
        }

        public void EditCategory(string categoryName, string shortDescription, string longDescription, CategoryDTO_full original)
        {
            var categoryDB = _categoryController.GetCategories().SingleOrDefault(x => x.CategoryName == original.CategoryName);
            categoryDB.CategoryName = categoryName;
            categoryDB.ShortDescription = shortDescription;
            categoryDB.LongDescription = longDescription;
            _categoryController.EditCategory(categoryDB);
        }

        public void DeleteCategoryByName(string name)
        {
            var category = _categoryController.GetCategories().SingleOrDefault(x => x.CategoryName == name);

            _categoryController.DeleteCategory(category.CategoryId);
        }

        public string CheckDataValid(string categoryName, string shortDescription, string longDescription)
        {
            string errorMessage = string.Empty;
            if (!categoryName.All(c => Char.IsLetterOrDigit(c) || c == '.' || Char.IsWhiteSpace(c)))
            {
                errorMessage += "*Category name: only letters and digits available;";
            }
            if (!shortDescription.All(c => Char.IsLetterOrDigit(c) || c == '.' || Char.IsWhiteSpace(c)))
            {
                errorMessage += "*Category short description: only letters and digits available;";
            }
            if (!longDescription.All(c => Char.IsLetterOrDigit(c) || c == '.' || Char.IsWhiteSpace(c)))
            {
                errorMessage += "*Category long description: only letters and digits available;";
            }
            if (_categoryController.GetCategories().Where(x => x.CategoryName == categoryName).Count() > 0)
            {
                errorMessage += "*Category name: category with this name already exist;";
            }
            return errorMessage;
        }

    }
}

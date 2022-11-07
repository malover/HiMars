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

        public string CreateNewCategory(string categoryName, string shortDescription, string longDescription)
        {
            var categoryDTO = new CategoryDTO_full { CategoryName = categoryName, ShortDescription = shortDescription, LongDescription = longDescription };
            var categoryDB = _mapper.Map<CategoryDTO_full, Category>(categoryDTO);

            if (_categoryController.GetCategories().Any(x => x.CategoryName == categoryDB.CategoryName))
            {
                return "This category already exist.";
            }
            else
            {
                _categoryController.AddCategory(categoryDB);
                return string.Empty;
            }
        }

        public string EditCategory(string categoryName, string shortDescription, string longDescription, CategoryDTO_full original)
        {
            var categoryDB = _categoryController.GetCategories().SingleOrDefault(x => x.CategoryName == original.CategoryName);
            categoryDB.CategoryName = categoryName;
            categoryDB.ShortDescription = shortDescription;
            categoryDB.LongDescription = longDescription;

            if (_categoryController.GetCategories().Where(x => x.CategoryName == categoryDB.CategoryName).Count() > 1)
            {
                return "This category already exist.";
            }
            else
            {
                _categoryController.EditCategory(categoryDB);
                return string.Empty;
            }
        }

        public void DeleteCategoryByName(string name)
        {
            var category = _categoryController.GetCategories().SingleOrDefault(x => x.CategoryName == name);

            _categoryController.DeleteCategory(category.CategoryId);
        }

    }
}

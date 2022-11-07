using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class CategoryController
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Category> GetCategories()
        {
            return _unitOfWork.CategoryRepository.GetAll().ToList();
        }

        public Category GetCategoryById(Guid id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Save();
        }

        public void EditCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Edit(category);
            _unitOfWork.Save();
        }

        public void DeleteCategory(Guid id)
        {
            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}

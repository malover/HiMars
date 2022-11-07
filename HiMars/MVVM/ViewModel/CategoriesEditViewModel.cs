using BLL.Controllers;
using BLL.DTO;
using PL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.MVVM.ViewModel
{
    public class CategoriesEditViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private CategoryDTO_full _category;
        private string _categoryName;
        private string _categoryShortDescription;
        private string _categoryLongDescription;
        private string _errorMessage;
        private CategoryLogicContoller _logicController;
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; OnPropertyChanged(); }
        }
        public string CategoryShortDescription
        {
            get { return _categoryShortDescription; }
            set { _categoryShortDescription = value; OnPropertyChanged(); }
        }
        public string CategoryLongDescription
        {
            get { return _categoryLongDescription; }
            set { _categoryLongDescription = value; OnPropertyChanged(); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        public RelayCommand Save { get; set; }
        public RelayCommand Cancel { get; set; }
        public CategoriesEditViewModel(CategoryDTO_full category, MainViewModel mainviewmodel)
        {
            _category = category;
            _mainViewModel = mainviewmodel;

            CategoryName = _category.CategoryName;
            CategoryShortDescription = _category.ShortDescription;
            CategoryLongDescription = _category.LongDescription;

            _logicController = new CategoryLogicContoller();

            Save = new RelayCommand(o =>
            {
                var result = _logicController.EditCategory(CategoryName, CategoryShortDescription, CategoryLongDescription, _category);
                if (result == String.Empty)
                {
                    _mainViewModel.CurrentView = new CategoryDetailsViewModel(new CategoryDTO_short { CategoryName = CategoryName, ShortDescription = CategoryShortDescription}, _mainViewModel);
                }
                else
                {
                    ErrorMessage = result;
                    return;
                }
            });

            Cancel = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new CategoriesViewModel(_mainViewModel);
            });
        }
    }
}

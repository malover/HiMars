using BLL.Controllers;
using BLL.DTO;
using DAL.Models;
using PL.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.MVVM.ViewModel
{
    public class CreateCategoryViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private readonly CategoryLogicContoller _categoryLogicContoller;
        private string _categoryName;
        private string _categoryShortDescription;
        private string _categoryLongDescription;

        private string _errorMessage;

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

        public RelayCommand Ok { get; set; }
        public RelayCommand Cancel { get; set; }

        public CreateCategoryViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _categoryLogicContoller = new CategoryLogicContoller();

            Ok = new RelayCommand(o =>
            {
                var result = _categoryLogicContoller.CheckDataValid(CategoryName, CategoryShortDescription, CategoryLongDescription);
                if (result == String.Empty)
                {
                    _categoryLogicContoller.CreateNewCategory(CategoryName, CategoryShortDescription, CategoryLongDescription);
                    _mainViewModel.CurrentView = new CategoriesViewModel(_mainViewModel);
                }
                else
                {
                    ErrorMessage = result;
                    return;
                }
            });

            Cancel = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new CategoriesViewModel(mainViewModel);
            });
        }
    }
}

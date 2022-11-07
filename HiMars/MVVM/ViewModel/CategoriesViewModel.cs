using BLL.Controllers;
using BLL.DTO;
using HiMars;
using PL.Core;
using PL.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PL.MVVM.ViewModel
{
    public class CategoriesViewModel
    {
        private CategoryDTO_short _selectedCategory;
        private readonly CategoryLogicContoller _logicContoller;
        private readonly MainViewModel _mainViewModel;
        public ObservableCollection<CategoryDTO_short> Categories { get; set; }
        public CategoryDTO_short SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                _mainViewModel.CurrentView = new CategoryDetailsViewModel(_selectedCategory, _mainViewModel);
            }
        }
        public RelayCommand CreateNew { get;set; }

        public CategoriesViewModel(MainViewModel mainViewModel)
        {
            CreateNew = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new CreateCategoryViewModel(mainViewModel);
            });

            Categories = new ObservableCollection<CategoryDTO_short>();
            _logicContoller = new CategoryLogicContoller();
            _mainViewModel = mainViewModel;
            PopulateCategories();
        }
        private void PopulateCategories()
        {
            var categories = _logicContoller.GetAllCategories_shortDescription();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }
    }
}

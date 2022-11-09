using BLL.Controllers;
using BLL.DTO;
using PL.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.MVVM.ViewModel
{
    public class GoodEditViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private string _goodName;
        private string _goodShortDescription;
        private string _goodLongDescription;
        private string _brand;
        private ObservableCollection<string> _availableCategories;
        private string _categoryName;
        private int _quantity;
        private GoodDTO_full _good;
        private readonly GoodLogicController _goodLogicController;
        private readonly CategoryLogicContoller _categoryLogicController;
        private decimal _price;
        private string _selectedCategory;
        private string _errorMessage;
        public string GoodName
        {
            get { return _goodName; }
            set { _goodName = value; OnPropertyChanged(); }
        }

        public string GoodShortDescription
        {
            get { return _goodShortDescription; }
            set { _goodShortDescription = value; OnPropertyChanged(); }
        }

        public string GoodLongDescription
        {
            get { return _goodLongDescription; }
            set { _goodLongDescription = value; OnPropertyChanged(); }
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; OnPropertyChanged(); }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        public ObservableCollection<string> AvailableCategories
        {
            get { return _availableCategories; }
            set { _availableCategories = value; OnPropertyChanged(); }
        }

        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; OnPropertyChanged(); }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; OnPropertyChanged(); }
        }
        public RelayCommand Save { get; set; }
        public RelayCommand Cancel { get; set; }

        public GoodEditViewModel(MainViewModel mainViewModel, GoodDTO_full good)
        {
            Save = new RelayCommand(o =>
            {
                var result = _goodLogicController.CheckDateValid(GoodName, GoodShortDescription, GoodLongDescription, Quantity, Price, Brand, CategoryName);
                if (result == string.Empty)
                {
                    _goodLogicController.EditGood(GoodName, GoodShortDescription, GoodLongDescription, Quantity, Price, Brand, SelectedCategory, _good);
                    _mainViewModel.CurrentView = new GoodsViewModel(_mainViewModel);
                }
                else
                {
                    ErrorMessage = result;
                    return;
                }
            });
            Cancel = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new GoodsViewModel(_mainViewModel);
            });

            _mainViewModel = mainViewModel;
            _goodLogicController = new GoodLogicController();
            _categoryLogicController = new CategoryLogicContoller();
            _good = good;

            GoodName = _good.GoodName;
            GoodShortDescription = _good.ShortDescription;
            GoodLongDescription = _good.LongDescription;
            Quantity = _good.Quantity;
            CategoryName = _good.CategoryName;
            Price = _good.Price;
            Brand = _good.Brand;

            GetAllAvailableCategories();

            SelectedCategory = _good.CategoryName;
            _errorMessage = string.Empty;
        }

        private void GetAllAvailableCategories()
        {
            var categories = _categoryLogicController.GetAllCategories_shortDescription();
            var temp = new ObservableCollection<string>();
            foreach (var category in categories)
            {
                temp.Add(category.CategoryName);
            }
            AvailableCategories = temp;
        }
    }
}

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
    public class CreateGoodViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private string _goodName;
        private string _goodShortDescription;
        private string _goodLongDescription;
        private string _categoryName;
        private int _quantity;
        private readonly GoodLogicController _goodLogicController;
        private string _errorMessage;
        private decimal _price;
        private string _brand;
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

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; OnPropertyChanged(); }
        }

        public RelayCommand Ok { get; set; }
        public RelayCommand Cancel { get; set; }

        public CreateGoodViewModel(MainViewModel mainViewModel, CategoryDTO_short category)
        {
            _categoryName = category.CategoryName;

            Ok = new RelayCommand(o =>
            {
                var result = _goodLogicController.CheckDateValid(GoodName, GoodShortDescription, GoodLongDescription, Quantity, Price, Brand, CategoryName);
                if (result == String.Empty)
                {
                    _goodLogicController.CreateNewGood(GoodName, GoodShortDescription, GoodLongDescription, Quantity, Price, Brand, CategoryName, category);
                    _mainViewModel.CurrentView = new CategoryDetailsViewModel(category, _mainViewModel);
                }
                else
                {
                    ErrorMessage = result;
                    return;
                }
            });
            Cancel = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new CategoryDetailsViewModel(category, _mainViewModel);
            });

            _mainViewModel = mainViewModel;
            _goodLogicController = new GoodLogicController();

            _errorMessage = string.Empty;
        }
    }
}

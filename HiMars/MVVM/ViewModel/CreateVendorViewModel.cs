using BLL.Controllers;
using PL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.MVVM.ViewModel
{
    public class CreateVendorViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private readonly VendorsLogicController _logicController;

        private string _firstName;
        private string _lastName;
        private string _errorMessage;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }
        
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public RelayCommand Ok { get; set; }
        public RelayCommand Cancel { get; set; }

        public CreateVendorViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _logicController = new VendorsLogicController();

            ErrorMessage = string.Empty;

            Ok = new RelayCommand(o =>
            {
                var result = _logicController.CheckDataValid(FirstName, LastName);

                if (result == String.Empty)
                {
                    _logicController.CreateNewVendor(FirstName, LastName);
                    _mainViewModel.CurrentView = new VendorsViewModel(_mainViewModel);
                }
                else
                {
                    ErrorMessage = result;
                    return;
                }
            });
            Cancel = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new VendorsViewModel(_mainViewModel);
            });
        }
    }
}

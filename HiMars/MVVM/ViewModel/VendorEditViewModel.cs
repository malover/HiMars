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
    public class VendorEditViewModel : ObservableObject
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

        public RelayCommand Save { get; set; }
        public RelayCommand Cancel { get; set; }

        public VendorEditViewModel(MainViewModel mainViewModel, VendorDTO vendor)
        {
            _mainViewModel = mainViewModel;
            _logicController = new VendorsLogicController();

            ErrorMessage = string.Empty;

            _firstName = vendor.FirstName;
            _lastName = vendor.LastName;

            Save = new RelayCommand(o =>
            {
                _logicController.EditVendor(FirstName, LastName, vendor);
                _mainViewModel.CurrentView = new VendorDetailsViewModel(_mainViewModel, new VendorDTO { FirstName = _firstName, LastName = _lastName });
            });
            Cancel = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new VendorDetailsViewModel(_mainViewModel, new VendorDTO { FirstName = _firstName, LastName = _lastName });
            });
        }
    }
}

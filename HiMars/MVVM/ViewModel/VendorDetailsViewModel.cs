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
    public class VendorDetailsViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private readonly VendorsLogicController _logicController;
        private VendorDTO _vendor;

        public VendorDTO Vendor
        {
            get { return _vendor; }
            set { _vendor = value; OnPropertyChanged(); }
        }

        public RelayCommand Delete { get; set; }
        public RelayCommand Edit { get; set; }

        public VendorDetailsViewModel(MainViewModel mainViewModel, VendorDTO vendor)
        {
            _mainViewModel = mainViewModel;
            _logicController = new VendorsLogicController();
            _vendor = vendor;

            Delete = new RelayCommand(o =>
            {
                _logicController.DeleteVendorByName(_vendor.FirstName, _vendor.LastName);
                _mainViewModel.CurrentView = new VendorsViewModel(_mainViewModel);
            });

            Edit = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new VendorEditViewModel(_mainViewModel, _vendor);
            });
        }
    }
}

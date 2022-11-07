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
    public class VendorsViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private readonly VendorsLogicController _logicController;
        private ObservableCollection<VendorDTO> _visibleVendors;
        private ObservableCollection<VendorDTO> _allVendors;
        private VendorDTO _selectedVendor;
        private int _sortCounter = 0;
        private string _searchBoxText;

        public ObservableCollection<VendorDTO> Vendors
        {
            get { return _allVendors; }
            set { _allVendors = value; OnPropertyChanged(); }
        }

        public ObservableCollection<VendorDTO> VisibleVendors
        {
            get { return _visibleVendors; }
            set { _visibleVendors = value; OnPropertyChanged(); }
        }

        public VendorDTO SelectedVendor
        {
            get { return _selectedVendor; }
            set
            {
                _selectedVendor = value; 
                OnPropertyChanged();
                _mainViewModel.CurrentView = new VendorDetailsViewModel(_mainViewModel, _selectedVendor);
            }
        }

        public string SearchBoxText
        {
            get { return _searchBoxText; }
            set { _searchBoxText = value; OnPropertyChanged(); Search(value); }
        }

        public RelayCommand SortByFistName { get; set; }
        public RelayCommand SortByLastName { get; set; }
        public RelayCommand CreateNew { get; set; }
        public VendorsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _logicController = new VendorsLogicController();

            SortByFistName = new RelayCommand(o =>
            {
                if (_sortCounter == 0)
                    _sortCounter++;
                else
                    _sortCounter--;
                VisibleVendors = _logicController.SortByFirstName(VisibleVendors, _sortCounter);
                return;
            });

            SortByLastName = new RelayCommand(o =>
            {
                if (_sortCounter == 0)
                    _sortCounter++;
                else
                    _sortCounter--;
                VisibleVendors = _logicController.SortByLastName(VisibleVendors, _sortCounter);
                return;
            });

            CreateNew = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new CreateVendorViewModel(_mainViewModel);
            });
            PopulateVendors();

            VisibleVendors = _allVendors;
        }

        private void PopulateVendors()
        {
            Vendors = _logicController.GetAllVendors();
        }

        private void Search(string searchText)
        {
            searchText = searchText.ToLower();
            var result = Vendors.Where(x => x.FirstName.ToLower().Contains(searchText) || x.LastName.ToLower().Contains(searchText));

            var temp = new ObservableCollection<VendorDTO>();
            foreach (var good in result)
            {
                temp.Add(good);
            }
            VisibleVendors = temp;
        }
    }
}

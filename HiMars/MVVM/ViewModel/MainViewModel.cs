using PL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private object _currentView;

        //Command for chaning the main window view in content space
        public RelayCommand CategoriesViewCommand { get; set; }
        public RelayCommand GoodsViewCommand { get; set; }
        public RelayCommand VendorsViewCommand { get; set; }
        
        //ViewModels properties
        public CategoriesViewModel CategoriesVm { get; set; }
        public GoodsViewModel GoodsVm { get; set; }
        public VendorsViewModel VendorsVm { get; set; }

        //Current view in main window content space
        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CategoriesVm = new CategoriesViewModel(this);

            //Set categories as the default viewmodel for content space
            CurrentView = CategoriesVm;

            //Initializing commands
            CategoriesViewCommand = new RelayCommand(o =>
            {
                CategoriesVm = new CategoriesViewModel(this);
                CurrentView = CategoriesVm;
            });
            GoodsViewCommand = new RelayCommand(o =>
            {
                GoodsVm = new GoodsViewModel(this);
                CurrentView = GoodsVm;
            });
            VendorsViewCommand = new RelayCommand(o =>
            {
                VendorsVm = new VendorsViewModel(this);
                CurrentView = VendorsVm;
            });
        }
    }
}

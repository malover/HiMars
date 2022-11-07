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
    public class GoodsViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private GoodDTO_short _selectedGood;
        private readonly GoodLogicController _logicContoller;
        private string _searchBoxText;
        private ObservableCollection<GoodDTO_short> _visibleGoods;
        private int _sortCounter = 0;
        public ObservableCollection<GoodDTO_short> VisibleGoods
        {
            get { return _visibleGoods; }
            set
            {
                _visibleGoods = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<GoodDTO_short> Goods { get; set; }
        public string SearchBoxText
        {
            get { return _searchBoxText; }
            set
            {
                _searchBoxText = value;
                OnPropertyChanged();
                Search(value);
            }
        }
        public GoodDTO_short SelectedGood
        {
            get { return _selectedGood; }
            set
            {
                _selectedGood = value;
                _mainViewModel.CurrentView = new GoodDetailsViewModel(_selectedGood, _mainViewModel);
            }
        }

        public RelayCommand SortByPrice { get; set; }
        public RelayCommand SortByName { get; set; }
        public RelayCommand SortByBrand { get; set; }
        public GoodsViewModel(MainViewModel mainViewModel)
        {
            Goods = new ObservableCollection<GoodDTO_short>();
            _logicContoller = new GoodLogicController();
            _mainViewModel = mainViewModel;
            
            PopulateCollection();
            _visibleGoods = Goods;

            SortByPrice = new RelayCommand(o =>
            {
                if (_sortCounter == 0)
                    _sortCounter++;
                else
                    _sortCounter--;
                VisibleGoods = _logicContoller.SortByPrice(VisibleGoods , _sortCounter);
                return;
            });

            SortByName = new RelayCommand(o =>
            {
                if (_sortCounter == 0)
                    _sortCounter++;
                else
                    _sortCounter--;
                VisibleGoods = _logicContoller.SortByName(VisibleGoods, _sortCounter);
                return;
            });

            SortByBrand = new RelayCommand(o =>
            {
                if (_sortCounter == 0)
                    _sortCounter++;
                else
                    _sortCounter--;
                VisibleGoods = _logicContoller.SortByBrand(VisibleGoods, _sortCounter);
                return;
            });
        }

        private void PopulateCollection()
        {
            var goods = _logicContoller.GetAllGoods_shortDescription();
            var temp = new ObservableCollection<GoodDTO_short>();
            foreach (var good in goods)
            {
                temp.Add(good);
            }
            Goods = temp;
        }

        private void Search(string searchText)
        {
            searchText = searchText.ToLower();
            var result = Goods.Where(x => x.GoodName.ToLower().Contains(searchText) || x.Brand.ToLower().Contains(searchText));

            var temp = new ObservableCollection<GoodDTO_short>();
            foreach (var good in result)
            {
                temp.Add(good);
            }
            VisibleGoods = temp;
        }
    }
}

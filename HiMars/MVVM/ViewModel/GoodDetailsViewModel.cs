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
    public class GoodDetailsViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private readonly GoodLogicController _logicController;
        private GoodDTO_full _good;

        public GoodDTO_full Good
        {
            get { return _good; }
            set
            {
                _good = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand Delete { get; set; }
        public RelayCommand Edit { get; set; }
        public GoodDetailsViewModel(GoodDTO_short good, MainViewModel mainviewmodel)
        {
            _mainViewModel = mainviewmodel;
            _logicController = new GoodLogicController();

            _good = _logicController.GetGoodByName_fullDescription(good.GoodName);

            Delete = new RelayCommand(o =>
            {
                _logicController.DeleteGoodByName(_good.GoodName);
                _mainViewModel.CurrentView = new GoodsViewModel(_mainViewModel);
            });
            Edit = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new GoodEditViewModel(_mainViewModel, _good);
            });
        }


    }
}

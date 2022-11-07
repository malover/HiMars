using BLL.Controllers;
using BLL.DTO;
using PL.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace PL.MVVM.ViewModel
{
    public class CategoryDetailsViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private readonly CategoryLogicContoller _categoryLogicContoller;
        private readonly GoodLogicController _goodsLogicController;
        private CategoryDTO_full _category;
        private GoodDTO_short _selectedGood;
        public RelayCommand Delete { get; set; }
        public RelayCommand Edit { get; set; }
        public RelayCommand AddGood { get; set; }
        public RelayCommand DeleteGood { get; set; }
        public ObservableCollection<GoodDTO_short> _goods { get; set; }

        public ObservableCollection<GoodDTO_short> Goods
        {
            get { return _goods; }
            set
            {
                _goods = value;
                OnPropertyChanged();
            }
        }
        public CategoryDTO_full Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        public GoodDTO_short SelectedGood
        {
            get { return _selectedGood; }
            set { _selectedGood = value; OnPropertyChanged(); }
        }
        public CategoryDetailsViewModel(CategoryDTO_short category, MainViewModel mainviewmodel)
        {
            _mainViewModel = mainviewmodel;

            Delete = new RelayCommand(o =>
            {
                _categoryLogicContoller.DeleteCategoryByName(_category.CategoryName);
                _mainViewModel.CurrentView = new CategoriesViewModel(_mainViewModel);
            });
            Edit = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new CategoriesEditViewModel(_category, _mainViewModel);
            });
            AddGood = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new CreateGoodViewModel(_mainViewModel, category);
            });
            DeleteGood = new RelayCommand(o =>
            {
                _goodsLogicController.DeleteGoodByName(_selectedGood.GoodName);
                PopulateGoodsForCategory();
            });

            _categoryLogicContoller = new CategoryLogicContoller();
            _goodsLogicController = new GoodLogicController();
            _category = _categoryLogicContoller.GetCategoryByName_fullDescription(category.CategoryName);
            Goods = new ObservableCollection<GoodDTO_short>();
            PopulateGoodsForCategory();
        }

        private void PopulateGoodsForCategory()
        {
            var listOfGoods = _goodsLogicController.GetAllGoodsForCategoryByName_name_amount(Category.CategoryName);
            var temp = new ObservableCollection<GoodDTO_short>();

            foreach (var good in listOfGoods)
            {
                temp.Add(good);
            }
            Goods = temp;
        }
    }
}

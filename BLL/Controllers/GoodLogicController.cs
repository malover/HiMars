using AutoMapper;
using BLL.DTO;
using BLL.Profiles;
using DAL.Controllers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public class GoodLogicController
    {
        private readonly GoodController _goodController;
        private readonly CategoryController _categoryController;
        private readonly IMapper _mapper;

        public GoodLogicController()
        {
            _goodController = new GoodController();
            _categoryController = new CategoryController();
            var profile = new GoodProfile();
            _mapper = profile.GoodMapper;
        }

        public List<GoodDTO_short> GetAllGoods_shortDescription()
        {
            var goods = _goodController.GetGoods().ToList();

            var goodsDTO = new List<GoodDTO_short>();

            foreach (var good in goods)
            {
                var goodDTO = _mapper.Map<Good, GoodDTO_short>(good);
                goodsDTO.Add(goodDTO);
            }
            return goodsDTO;
        }

        public List<GoodDTO_short> GetAllGoodsForCategoryByName_name_amount(string categoryName)
        {
            var goods = _goodController.GetGoodsForCategory(categoryName);
            var goodsDTO = new List<GoodDTO_short>();

            foreach (var good in goods)
            {
                var goodDTO = _mapper.Map<Good, GoodDTO_short>(good);
                goodsDTO.Add(goodDTO);
            }
            return goodsDTO;
        }

        public GoodDTO_full GetGoodByName_fullDescription(string name)
        {
            var good = _goodController.GetGoods().ToList().SingleOrDefault(x => x.GoodName == name);
            var goodDTO = _mapper.Map<Good, GoodDTO_full>(good);

            var categoryDTO = _categoryController.GetCategories().SingleOrDefault(x => x.CategoryId == good.CategoryId);
            goodDTO.CategoryName = categoryDTO.CategoryName;

            return goodDTO;
        }

        public void DeleteGoodByName(string name)
        {
            var good = _goodController.GetGoods().SingleOrDefault(x => x.GoodName == name);

            _goodController.DeleteGood(good.GoodId);
        }

        public void CreateNewGood(string goodName, string shortDescription, string longDescription, int quantity, decimal price, string brand, string categoryName, CategoryDTO_short categoryDTO)
        {
            var goodDTO = new GoodDTO_full { CategoryName = categoryName, ShortDescription = shortDescription, LongDescription = longDescription, GoodName = goodName, Quantity = quantity, Price = price, Brand = brand };

            var good = _mapper.Map<GoodDTO_full, Good>(goodDTO);

            var categoryDB = _categoryController.GetCategories().SingleOrDefault(x => x.CategoryName == categoryDTO.CategoryName);
            good.CategoryId = categoryDB.CategoryId;

            _goodController.AddGood(good);
        }

        public void EditGood(string goodName, string shortDescription, string longDescription, int quantity, decimal price, string brand, string categoryName, GoodDTO_full original)
        {
            var goodDB = _goodController.GetGoods().SingleOrDefault(x => x.GoodName == original.GoodName);
            goodDB.GoodName = goodName;
            goodDB.ShortDescription = shortDescription;
            goodDB.LongDescription = longDescription;
            goodDB.Quantity = quantity;
            goodDB.Price = price;
            goodDB.Brand = brand;

            var categoryDB = _categoryController.GetCategories().SingleOrDefault(x => x.CategoryName == categoryName);

            goodDB.CategoryId = categoryDB.CategoryId;

            _goodController.EditGood(goodDB);
        }

        public string CheckDateValid(string goodName, string shortDescription, string longDescription, int quantity, decimal price, string brand, string categoryName)
        {
            string errorMessage = string.Empty;
            if (!goodName.All(c => Char.IsLetterOrDigit(c) || c == '.' || Char.IsWhiteSpace(c)))
            {
                errorMessage += "*Good name: only letters and digits available; \n";
            }
            if (!shortDescription.All(c => Char.IsLetterOrDigit(c) || c == '.' || Char.IsWhiteSpace(c)))
            {
                errorMessage += "*Good short description: only letters and digits available; \n";
            }
            if (!longDescription.All(c => Char.IsLetterOrDigit(c) || c == '.' || Char.IsWhiteSpace(c)))
            {
                errorMessage += "*Good long description: only letters and digits available; \n";
            }
            if (quantity < 0 || quantity > 9999)
            {
                errorMessage += "*Quantity: put the number in range from 0 to 9999; \n";
            }
            if (price < 0 || price > 999999)
            {
                errorMessage += "*Price: put the number in range from 0 to 999999; \n";
            }
            if (!brand.All(c => Char.IsLetterOrDigit(c) || c == '.' || Char.IsWhiteSpace(c)))
            {
                errorMessage += "*Good brand: only letters and digits available; \n";
            }
            if (_goodController.GetGoodsForCategory(categoryName).Where(x => x.GoodName == goodName).Count() > 0)
            {
                errorMessage += $"*Good name: good with this name already exist in category: {categoryName}; \n";
            }
            return errorMessage;
        }

        public ObservableCollection<GoodDTO_short> SortByPrice(ObservableCollection<GoodDTO_short> list, int counter)
        {
            var sortedList = new List<GoodDTO_short>();
            if (counter == 0)
            {
                sortedList = list.OrderBy(x => x.Price).ToList();
            }
            else
            {
                sortedList = list.OrderByDescending(x => x.Price).ToList();
            }
            var returnList = new ObservableCollection<GoodDTO_short>();
            foreach (var item in sortedList)
            {
                returnList.Add(item);
            }
            return returnList;
        }

        public ObservableCollection<GoodDTO_short> SortByName(ObservableCollection<GoodDTO_short> list, int counter)
        {
            var sortedList = new List<GoodDTO_short>();
            if (counter == 0)
            {
                sortedList = list.OrderBy(x => x.GoodName).ToList();
            }
            else
            {
                sortedList = list.OrderByDescending(x => x.GoodName).ToList();
            }
            var returnList = new ObservableCollection<GoodDTO_short>();
            foreach (var item in sortedList)
            {
                returnList.Add(item);
            }
            return returnList;
        }

        public ObservableCollection<GoodDTO_short> SortByBrand(ObservableCollection<GoodDTO_short> list, int counter)
        {
            var sortedList = new List<GoodDTO_short>();
            if (counter == 0)
            {
                sortedList = list.OrderBy(x => x.Brand).ToList();
            }
            else
            {
                sortedList = list.OrderByDescending(x => x.Brand).ToList();
            }
            var returnList = new ObservableCollection<GoodDTO_short>();
            foreach (var item in sortedList)
            {
                returnList.Add(item);
            }
            return returnList;
        }
    }
}

using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class GoodController
    {
        private readonly UnitOfWork _unitOfWork;

        public GoodController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Good> GetGoods()
        {
            return _unitOfWork.GoodRepository.GetAll().ToList();
        }

        public List<Good> GetGoodsForCategory(string categoryName)
        {
            var category = _unitOfWork.CategoryRepository.GetAll().SingleOrDefault(x => x.CategoryName == categoryName);

            var goods = _unitOfWork.GoodRepository.GetAll().Where(x => x.CategoryId == category.CategoryId).ToList();
            return goods;
        }

        public Good GetGoodById(Guid id)
        {
            return _unitOfWork.GoodRepository.GetById(id);
        }

        public void AddGood(Good good)
        {
            _unitOfWork.GoodRepository.Add(good);
            _unitOfWork.Save();
        }

        public void EditGood(Good good)
        {
            _unitOfWork.GoodRepository.Edit(good);
            _unitOfWork.Save();
        }

        public void DeleteGood(Guid id)
        {
            _unitOfWork.GoodRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}

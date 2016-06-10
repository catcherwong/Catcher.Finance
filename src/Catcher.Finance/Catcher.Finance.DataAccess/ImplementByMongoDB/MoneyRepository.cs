using System;
using System.Collections.Generic;
using MongoRepository;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using System.Linq;

namespace Catcher.Finance.DataAccess.ImplementByMongoDB
{
    public class MoneyRepository : IMoneyRepository
    {
        MongoRepository<MoneyInfo> mRepo = new MongoRepository<MoneyInfo>();
        MongoRepository<UserInfo> uRepo = new MongoRepository<UserInfo>();
        MongoRepository<CategoryInfo> cRepo = new MongoRepository<CategoryInfo>();

        public bool Add(MoneyInfo entity)
        {
            return mRepo.Add(entity) != null;
        }

        public bool Delete(MoneyInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(object Id)
        {
            throw new NotImplementedException();
        }

        public IList<MoneyInfo> GetAll()
        {
            return mRepo.ToList();
        }

        public IList<MoneyVM> GetAllMoneyRecord()
        {
            //var list = mRepo.ToList();
            //IList<MoneyVM> vmList = new List<MoneyVM>();
            //foreach (var x in list)
            //{
            //    CategoryInfo c = cRepo.GetById(x.MoneyCategoryID);
            //    UserInfo u = uRepo.GetById(x.MoneyUID);
            //}
            //return null;

            return mRepo.ToList().Select(x => new MoneyVM
            {
                MoneyId = x.Id,
                MoneyAbout = x.MoneyAbout,
                MoneyDate = x.MoneyDate.ToString("yyyy-MM-dd"),
                MoneyType = x.MoneyType,
                MoneyValue = x.MoneyValue.ToString(),
                CategoryName = cRepo.GetById(x.MoneyCategoryID).CategoryName,
                UserName = uRepo.GetById(x.MoneyUID).UserName
            }).ToList();
        }

        public MoneyInfo GetById(object Id)
        {
            return mRepo.GetById((string)Id);
        }

        public int GetIncomeRecordCount()
        {
            return mRepo.Count(x => x.MoneyType == "income");
        }

        public MoneyVM GetMoneyDetialById(object id)
        {
            var x = mRepo.GetById((string)id);
            return new MoneyVM
            {
                MoneyId = x.Id,
                MoneyAbout = x.MoneyAbout,
                MoneyDate = x.MoneyDate.ToString("yyyy-MM-dd"),
                MoneyType = x.MoneyType,
                MoneyValue = x.MoneyValue.ToString(),
                CategoryName = cRepo.GetById(x.MoneyCategoryID).CategoryName,
                UserName = uRepo.GetById(x.MoneyUID).UserName
            };
        }

        public int GetMoneyRecordCount()
        {
            return (int)mRepo.Count();
        }

        public int GetPayRecordCount()
        {
            return mRepo.Count(x => x.MoneyType == "pay");
        }

        public decimal GetTotalIncome()
        {

             var list =  mRepo.Where(x => x.MoneyType == "income").Select(x => x.MoneyValue).ToList();
            return list.Sum();
        }

        public decimal GetTotalIncome(object uid)
        {
            string id = uid.ToString();
            return mRepo.Where(x => x.MoneyType == "income"&& x.MoneyUID == id).Sum(x => x.MoneyValue);
        }

        public decimal GetTotalPay()
        {
            var list = mRepo.Where(x => x.MoneyType == "pay").Select(x=>x.MoneyValue).ToList();
            return list.Sum();
        }

        public decimal GetTotalPay(object uid)
        {
            string id = uid.ToString();
            var list = mRepo.Where(x => x.MoneyType == "pay" && x.MoneyUID == id).Select(x => x.MoneyValue);
            return list.Sum();
        }

        public IList<MoneyListViewVM> GetUserMoneyDetial(object uid)
        {
            string id = uid.ToString();
            return mRepo.Where(x => x.MoneyUID == id).Select(x => new MoneyListViewVM
            {
                MoneyId = x.Id,
                MoneyAbout = x.MoneyAbout,
                MoneyDate = x.MoneyDate.ToString("yyyy-MM-dd"),
                MoneyType = x.MoneyType,
                MoneyValue = x.MoneyValue.ToString(),
                CategoryName = cRepo.GetById(x.MoneyCategoryID).CategoryName
            }).ToList();
        }

        public bool Update(MoneyInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}

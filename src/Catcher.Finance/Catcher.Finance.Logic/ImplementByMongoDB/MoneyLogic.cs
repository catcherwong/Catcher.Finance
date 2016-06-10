using System;
using System.Collections.Generic;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using Catcher.Finance.DataAccess.ImplementByMongoDB;
using Catcher.Finance.DataAccess;

namespace Catcher.Finance.Logic.ImplementByMongoDB
{
    public class MoneyLogic : IMoneyLogic
    {
        private IMoneyRepository _repo;
        public MoneyLogic()
        {
            _repo = new MoneyRepository();
        }

        public ResponseModel AddMoneyRecord(MoneyInfo entity)
        {
            bool flag = _repo.Add(entity);
            ResponseModel model = new ResponseModel();
            if (flag)
            {
                model.Code = "0000";
                model.Msg = "add success";
            }
            else
            {
                model.Code = "0001";
                model.Msg = "add fail";
            }
            return model;
        }

        public IList<MoneyVM> GetAllMoneyRecord()
        {
            return _repo.GetAllMoneyRecord();
        }

        public int GetIncomeRecordCount()
        {
            return _repo.GetIncomeRecordCount();
        }

        public MoneyVM GetMoneyInfoById(object id)
        {
            return _repo.GetMoneyDetialById(id);
        }

        public int GetMoneyRecordCount()
        {
            return _repo.GetMoneyRecordCount();
        }

        public int GetPayRecordCount()
        {
            return _repo.GetPayRecordCount();
        }

        public decimal GetTotalIncome()
        {
            return _repo.GetTotalIncome();
        }

        public decimal GetTotalIncome(object uid)
        {
            try
            {
                return _repo.GetTotalIncome(uid);
            }
            catch (Exception ex)
            {
                return 0;                
            }            
        }

        public decimal GetTotalPay()
        {
            return _repo.GetTotalPay();
        }

        public decimal GetTotalPay(object uid)
        {
            try
            {
                return _repo.GetTotalPay(uid);
            }
            catch (Exception ex)
            {
                return 0;
            }            
        }

        public IList<MoneyListViewVM> GetUserMoneyDetial(object uid)
        {
            try
            {
                return _repo.GetUserMoneyDetial(uid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}

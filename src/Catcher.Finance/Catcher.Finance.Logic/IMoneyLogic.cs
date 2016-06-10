using System;
using System.Collections.Generic;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;

namespace Catcher.Finance.Logic
{
    public interface IMoneyLogic
    {
        ResponseModel AddMoneyRecord(MoneyInfo entity);

        decimal GetTotalIncome(object uid);

        decimal GetTotalPay(object uid);

        IList<MoneyListViewVM> GetUserMoneyDetial(object uid);

        int GetMoneyRecordCount();

        int GetIncomeRecordCount();

        int GetPayRecordCount();

        decimal GetTotalIncome();

        decimal GetTotalPay();

        MoneyVM GetMoneyInfoById(object id);

        IList<MoneyVM> GetAllMoneyRecord();

    }
}

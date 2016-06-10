using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using System.Collections.Generic;

namespace Catcher.Finance.DataAccess
{
    public interface IMoneyRepository : IBaseRepository<MoneyInfo>
    {
        decimal GetTotalIncome(object uid);

        decimal GetTotalPay(object uid);

        IList<MoneyListViewVM> GetUserMoneyDetial(object uid);

        int GetMoneyRecordCount();

        int GetIncomeRecordCount();

        int GetPayRecordCount();

        decimal GetTotalIncome();

        decimal GetTotalPay();

        IList<MoneyVM> GetAllMoneyRecord();

        MoneyVM GetMoneyDetialById(object id);
    }
}

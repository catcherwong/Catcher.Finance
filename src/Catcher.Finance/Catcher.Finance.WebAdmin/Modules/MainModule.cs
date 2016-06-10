using Catcher.Finance.Logic;
using Nancy;
using Nancy.Security;
using Newtonsoft.Json;

namespace Catcher.Finance.WebAdmin.Modules
{
    public class MainModule : NancyModule
    {
        private IUserLogic _userLogic;
        private IMoneyLogic _moneyLogic;

        public MainModule(IUserLogic userLogic, IMoneyLogic moneyLogic) :base("/main")
        {
            this._moneyLogic = moneyLogic;
            this._userLogic = userLogic;

            this.RequiresAuthentication();

            Get["/"] = _ => ShowMainPage();
            
            Post["/usercount"] = _ => GetUserCount();
            
            Post["/recordcount"] = _ => GetRecordCount();
            
            Post["/incomeinfo"] = _ => GetIncomeInfo();
            
            Post["/payinfo"] = _ => GetPayInfo();            
        }

        /// <summary>
        /// get the pay money infomation
        /// </summary>
        /// <returns></returns>
        private dynamic GetPayInfo()
        {
            var json = new
            {
                Code = "0000",
                Count = _moneyLogic.GetPayRecordCount(),
                Money = _moneyLogic.GetTotalPay()
            };
            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get the income money infomation
        /// </summary>
        /// <returns></returns>
        private dynamic GetIncomeInfo()
        {
            var json = new
            {
                Code = "0000",
                Count = _moneyLogic.GetIncomeRecordCount(),
                Money = _moneyLogic.GetTotalIncome()
            };
            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get the money record count
        /// </summary>
        /// <returns></returns>
        private dynamic GetRecordCount()
        {
            var json = new
            {
                Code = "0000",
                Count = _moneyLogic.GetMoneyRecordCount()
            };
            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get the active user count
        /// </summary>
        /// <returns></returns>
        private dynamic GetUserCount()
        {
            var json = new
            {
                Code = "0000",
                Count = _userLogic.GetAllActiveUserCount()
            };
            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get the main page
        /// </summary>
        /// <returns></returns>
        private dynamic ShowMainPage()
        {
            ViewBag.name = Request.Session["name"];

            ViewBag.userCount = _userLogic.GetAllActiveUserCount();
            ViewBag.totalIncome = _moneyLogic.GetTotalIncome();
            ViewBag.incomeCount = _moneyLogic.GetIncomeRecordCount();
            ViewBag.totalPay = _moneyLogic.GetTotalPay();
            ViewBag.payCount = _moneyLogic.GetPayRecordCount();
            ViewBag.totalRecordCount = _moneyLogic.GetMoneyRecordCount();

            return View["index"];
        }
    }
}
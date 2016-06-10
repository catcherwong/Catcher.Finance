using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Catcher.Finance.Logic;
using Catcher.Finance.Entities;

namespace Catcher.Finance.DataServiceViaNancyFx.Modules
{
    public class MoneyModule : NancyModule
    {
        private IMoneyLogic _moneyLogic;
        private IUserLogic _userLogic;
        public MoneyModule(IMoneyLogic moneyLogic, IUserLogic userLogic) : base("/money")
        {
            this._moneyLogic = moneyLogic;
            this._userLogic = userLogic;

            Post["/addmoneyrecord"] = _ => AddMoneyRecord(Request.Form["uName"], Request.Form["moneyType"], Request.Form["categoryId"], Request.Form["moneyValue"], Request.Form["moneyDate"], Request.Form["moneyAbout"]);

            Get["/gettotalinfo"] = _ => GetTotalInfo(Request.Form["uName"]);

            Get["/getmoneydetial"] = _ => GetMoneyDetial(Request.Form["uName"]);
        }

        /// <summary>
        /// get the money record of the user
        /// </summary>
        /// <param name="uName">the name of the user</param>
        /// <returns></returns>
        private dynamic GetMoneyDetial(string uName)
        {
            try
            {
                var json = new
                {
                    Code = "0000",
                    Msg = "OK",
                    Data = _moneyLogic.GetUserMoneyDetial(_userLogic.GetUIDbyUserName(Request.Form["uName"]))
                };
                return Response.AsJson(json);
            }
            catch (Exception ex)
            {
                return Response.AsJson(new { Code = "0009", Msg = ex.Message });
            }
        }

        /// <summary>
        /// get the summary of the user record
        /// </summary>
        /// <param name="uName">the name of the user</param>
        /// <returns></returns>
        private dynamic GetTotalInfo(string uName)
        {
            try
            {
                var json = new
                {
                    Code = "0000",
                    Msg = "OK",
                    Income = _moneyLogic.GetTotalIncome(_userLogic.GetUIDbyUserName(uName)),
                    Pay = _moneyLogic.GetTotalPay(_userLogic.GetUIDbyUserName(uName))
                };
                return Response.AsJson(json);
            }
            catch (Exception ex)
            {
                return Response.AsJson(new { Code = "0009", Msg = ex.Message });
            }
        }

        /// <summary>
        /// add the money recored
        /// </summary>
        /// <param name="uName">the Identity of the user</param>
        /// <param name="moneyType">the type of the record</param>
        /// <param name="categoryId">the identity of the category</param>
        /// <param name="moneyValue">the money user input</param>
        /// <param name="moneyDate">the date</param>
        /// <param name="moneyAbout">something about the record</param>
        /// <returns></returns>
        private dynamic AddMoneyRecord(string uName, string moneyType, string categoryId, string moneyValue, string moneyDate, string moneyAbout)
        {
            try
            {
                MoneyInfo entity = new MoneyInfo();
                //entity.MoneyID = Guid.NewGuid();
                entity.MoneyUID = _userLogic.GetUIDbyUserName(uName);
                entity.MoneyType = moneyType;
                entity.MoneyCategoryID = categoryId;
                entity.MoneyValue = decimal.Parse(moneyValue);
                entity.MoneyDate = DateTime.Parse(moneyDate);
                entity.MoneyAbout = moneyAbout;
                ResponseModel responseModel = _moneyLogic.AddMoneyRecord(entity);
                return Response.AsJson(responseModel);
            }
            catch (Exception ex)
            {
                return Response.AsJson(new ResponseModel() { Msg = ex.Message, Code = "0009" });
            }
        }
    }
}
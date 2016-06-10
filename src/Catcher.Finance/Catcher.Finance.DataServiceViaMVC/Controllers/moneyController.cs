using Catcher.Finance.Logic;
using Catcher.Finance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catcher.Finance.DataServiceViaMVC.Controllers
{
    public class moneyController : Controller
    {
        private IMoneyLogic _moneyLogic;
        private IUserLogic _userLogic;
        public moneyController(IMoneyLogic moneyLogic, IUserLogic userLogic)
        {
            this._moneyLogic = moneyLogic;
            this._userLogic = userLogic;
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
        [HttpPost]
        public ActionResult addmoneyrecord(string uName, string moneyType,string categoryId,string moneyValue,string moneyDate,string moneyAbout)
        {           
            try
            {
                MoneyInfo entity = new MoneyInfo();                
                entity.MoneyUID = _userLogic.GetUIDbyUserName(uName);
                entity.MoneyType = moneyType;
                entity.MoneyCategoryID = categoryId;
                entity.MoneyValue = decimal.Parse(moneyValue);
                entity.MoneyDate = DateTime.Parse(moneyDate);
                entity.MoneyAbout = moneyAbout;
                ResponseModel responseModel = _moneyLogic.AddMoneyRecord(entity);
                return Json(responseModel);
            }
            catch (Exception ex)
            {
                return Json(new ResponseModel() { Msg = ex.Message,Code="0009" });
            }            
        }

        /// <summary>
        /// get the summary of the user record
        /// </summary>
        /// <param name="uName">the name of the user</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult gettotalinfo(string uName)
        {
            try
            {
                var json = new
                {
                    Code="0000",
                    Msg = "OK",
                    Income =_moneyLogic.GetTotalIncome(_userLogic.GetUIDbyUserName(uName)),
                    Pay= _moneyLogic.GetTotalPay(_userLogic.GetUIDbyUserName(uName))
                };
                return Json(json,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Code="0009",Msg =ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult getmoneydetial(string uName)
        {

            try
            {
                var json = new
                {
                    Code = "0000",
                    Msg = "OK",                    
                    Data = _moneyLogic.GetUserMoneyDetial(_userLogic.GetUIDbyUserName(uName))
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Code = "0009", Msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }            
        }
    }
}
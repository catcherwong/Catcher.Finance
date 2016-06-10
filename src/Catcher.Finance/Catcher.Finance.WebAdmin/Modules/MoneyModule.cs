using Catcher.Finance.Logic;
using Nancy;
using Nancy.Security;
using Newtonsoft.Json;
using System;

namespace Catcher.Finance.WebAdmin.Modules
{
    public class MoneyModule : NancyModule
    {
        private IMoneyLogic _moneyLogic;

        public MoneyModule(IMoneyLogic moneyLogic) : base("/main/money")
        {
            this.RequiresAuthentication();

            this._moneyLogic = moneyLogic;

            Get["/"] = _ => ShowMoneyPage();

            Post["/getall"] = _ => GetAllUser();

            Post["/getmoneyrecord"] = _ => GetMoneyRecord((string)Request.Form["mid"]);
            
        }

        /// <summary>
        /// get the money detial
        /// </summary>
        /// <param name="mid">the identity of the record</param>
        /// <returns></returns>
        private dynamic GetMoneyRecord(string mid)
        {
            var json = new
            {
                Code = "0000",
                Msg = "success",
                Row = _moneyLogic.GetMoneyInfoById(mid)
            };
            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get all users 
        /// </summary>
        /// <returns></returns>
        private dynamic GetAllUser()
        {
            var json = new
            {
                Code = "0000",
                Msg = "success",
                Row = _moneyLogic.GetAllMoneyRecord()
            };
            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get the money page
        /// </summary>
        /// <returns></returns>
        private dynamic ShowMoneyPage()
        {
            ViewBag.name = Request.Session["name"];
            return View["index"];
        }
    }
}
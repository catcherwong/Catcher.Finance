using System;
using System.Web.Mvc;
using Catcher.Finance.Common;
using Catcher.Finance.Logic;
using Catcher.Finance.Entities;

namespace Catcher.Finance.DataServiceViaMVC.Controllers
{
    public class userController : Controller
    {
        private IUserLogic _userLogic;

        public userController(IUserLogic userLogic)
        {
            this._userLogic = userLogic;
        }

        /// <summary>
        /// app user login
        /// </summary>
        /// <param name="userName">the name user input</param>
        /// <param name="userPassword">the password user input</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult login(string userName,string userPassword)
        {
            try
            {
                ResponseModel response = _userLogic.Login(DESHelper.DESDecrypt(userName), DESHelper.DESDecrypt(userPassword));

                return Json(response);
            }
            catch (Exception ex)
            {             
                return Json(new { Code="0009",Msg = "exception" });
            }
        }

        /// <summary>
        /// app user register
        /// </summary>
        /// <param name="userName">the name user input</param>
        /// <param name="userPassword">the password user input</param>
        /// <param name="gender">the gender user select</param>
        /// <param name="email">the email user input</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult register(string userName, string userPassword, string gender,string email)
        {
            try
            {
                UserInfo user = new UserInfo();
                user.UserName = DESHelper.DESDecrypt(userName);
                user.UserPassword = DESHelper.DESDecrypt(userPassword);
                user.UserGender = DESHelper.DESDecrypt(gender);
                user.UserEmail = DESHelper.DESDecrypt(email);

                ResponseModel response = _userLogic.Register(user);

                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new { Code = "0009", Msg = "exception" });
            }
        }

        [HttpGet]
        public ActionResult getuserinfo(string uName)
        {
            var user = _userLogic.GetUserById(_userLogic.GetUIDbyUserName(uName));

            var json = new
            {
                Code = "0000",
                Data = user
            };
            return Json(json,JsonRequestBehavior.AllowGet);
        }

    }
}
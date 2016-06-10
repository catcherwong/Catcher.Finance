using Catcher.Finance.Common;
using Catcher.Finance.Logic;
using Nancy;
using Nancy.Authentication.Forms;
using System;

namespace Catcher.Finance.WebAdmin.Modules
{
    public class LoginModule : NancyModule
    {
        private IAdminLogic _adminLogic;

        public LoginModule(IAdminLogic adminLogic) :base("/")
        {
            this._adminLogic = adminLogic;

            //the login page
            Get["/"] = _ => GetLoginPage();

            //login 
            Post["/"] = _ => Login(Request.Form["username"], Request.Form["password"]);            

            //sing out
            Get["/signout"] = _ => SignOut();            
        }

        /// <summary>
        /// sing out
        /// </summary>
        /// <returns></returns>
        private dynamic SignOut()
        {
            return this.LogoutAndRedirect("~/");
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="name">the name user input</param>
        /// <param name="pwd">the password user input</param>
        /// <returns></returns>
        private dynamic Login(string name,string pwd)
        {            
            Guid adminID = _adminLogic.LogInAndReturnUID(name, HMACMD5Encrypt.GetEncryptResult(pwd));

            if (adminID != new Guid())
            {
                Session["name"] = name;

                return this.LoginAndRedirect(adminID, fallbackRedirectUrl: "/main");
            }
            else
            {
                return View["index"];
            }
        }

        /// <summary>
        /// get the login page
        /// </summary>
        /// <returns></returns>
        private dynamic GetLoginPage()
        {
            return View["index"];
        }
    }
}
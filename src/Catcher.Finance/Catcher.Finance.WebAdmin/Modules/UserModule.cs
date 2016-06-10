using Catcher.Finance.Entities.ViewModels;
using Catcher.Finance.Logic;
using Nancy;
using Nancy.Security;
using Newtonsoft.Json;

namespace Catcher.Finance.WebAdmin.Modules
{
    public class UserModule : NancyModule
    {
        private IUserLogic _userLogic;

        public UserModule(IUserLogic userLogic):base("/main/user")
        {
            this.RequiresAuthentication();

            this._userLogic = userLogic;

            Get["/"] = _ => ShowUserPage();

            Post["/getall"] = _ => GetAllUser();

            Post["/getone"] = _ => 
            {
                UserVM vm = _userLogic.GetUserVM(Request.Form["id"]);
                var json = new
                {
                    Code = "0000",
                    Row = vm
                };
                return Response.AsJson(json) ;
            };
        }

        /// <summary>
        /// get all the user infomation
        /// </summary>
        /// <returns></returns>
        private dynamic GetAllUser()
        {
            var list = _userLogic.GetAll();
            var json = new
            {
                Code = "0000",
                Row = list
            };

            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get the user page
        /// </summary>
        /// <returns></returns>
        private dynamic ShowUserPage()
        {
            ViewBag.name = Request.Session["name"];
            return View["index"];
        }
    }
}
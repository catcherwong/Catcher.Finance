using Catcher.Finance.Common;
using Catcher.Finance.Logic;
using Catcher.Finance.Entities;
using Nancy;
using Newtonsoft.Json;

namespace Catcher.Finance.DataServiceViaNancyFx.Modules
{
    public class UserModule : NancyModule
    {
        private IUserLogic _userLogic;
        public UserModule(IUserLogic userLogic) :base("/user")
        {
            this._userLogic = userLogic;
            Get["/"] = _ =>
            {
                var json = new
                {
                    Code = "0000",
                    Row = _userLogic.GetAll()
                };
                
                return Response.AsText(JsonConvert.SerializeObject(json), "application/json;charset=UTF-8");
            };


            Post["/login"] = _ => Login(Request.Form["userName"], Request.Form["userPassword"]);


            Post["/register"] = _ => Register(Request.Form["userName"], Request.Form["userPassword"], Request.Form["gender"], Request.Form["email"]);

            Get["/getuserinfo"] = _ => GetUserInfo(Request.Form["uName"]);
           
        }

        /// <summary>
        /// get user's infomation
        /// </summary>
        /// <param name="uName">the name of user</param>
        /// <returns></returns>
        private dynamic GetUserInfo(string uName)
        {            
            var json = new
            {
                Code = "0000",
                Data = _userLogic.GetUserById(_userLogic.GetUIDbyUserName(uName))
            };

            return Response.AsText(JsonConvert.SerializeObject(json), "application/json;charset=UTF-8");
        }

        /// <summary>
        /// register
        /// </summary>
        /// <param name="userName">the name user input</param>
        /// <param name="userPassword">the password user input</param>
        /// <param name="gender">the gender user select</param>
        /// <param name="email">the email user input</param>
        /// <returns></returns>
        private dynamic Register(string userName, string userPassword, string gender, string email)
        {
            UserInfo user = new UserInfo();
            user.UserName = DESHelper.DESDecrypt(userName);
            user.UserPassword = DESHelper.DESDecrypt(userPassword);
            user.UserGender = DESHelper.DESDecrypt(gender);
            user.UserEmail = DESHelper.DESDecrypt(email);

            ResponseModel response = _userLogic.Register(user);

            return Response.AsText(JsonConvert.SerializeObject(response), "application/json;charset=UTF-8");
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="userName">the name user input</param>
        /// <param name="userPassword">the password user input</param>
        /// <returns></returns>
        private dynamic Login(string userName, string userPassword)
        {            
            ResponseModel response = _userLogic.Login(DESHelper.DESDecrypt(userName), DESHelper.DESDecrypt(userPassword));

            return Response.AsText(JsonConvert.SerializeObject(response), "application/json;charset=UTF-8");
        }
    }
}
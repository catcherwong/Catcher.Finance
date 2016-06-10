using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Catcher.Finance.Logic;
using System;

namespace Catcher.Finance.WebAdmin
{
    public class UserMapper :IUserMapper
    {
        private IAdminLogic _adminLogic;
        public UserMapper(IAdminLogic adminLogic)
        {
            this._adminLogic = adminLogic;
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            //valid the user
            var admin = _adminLogic.ValidAdmin(identifier);
            if (admin==null)
            {
                return null;
            }
            else
            {
                return new UserIdentity
                {
                    UserName = admin.AdminName,
                    Claims = new[] { "SystemUser" }
                };
            }
        }
    }
}
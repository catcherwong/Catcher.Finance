using Nancy;
using Nancy.Authentication.Forms;
using System;

namespace Catcher.Finance.WebAdmin.Extension
{
    public static class ModuleExtension
    {
        public static Response LoginAndRedirect(this INancyModule module, Guid userIdentifier, DateTime? cookieExpiry = null, string fallbackRedirectUrl = "/main")
        {
            return FormsAuthentication.UserLoggedInRedirectResponse(module.Context, userIdentifier, cookieExpiry, fallbackRedirectUrl);
        }
    }
}
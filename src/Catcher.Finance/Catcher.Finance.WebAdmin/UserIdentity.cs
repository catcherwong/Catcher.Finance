using Nancy.Security;
using System.Collections.Generic;

namespace Catcher.Finance.WebAdmin
{
    public class UserIdentity : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}
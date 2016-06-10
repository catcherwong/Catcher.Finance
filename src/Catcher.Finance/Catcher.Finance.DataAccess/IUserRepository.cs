using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using System.Collections.Generic;

namespace Catcher.Finance.DataAccess
{
    public interface IUserRepository : IBaseRepository<UserInfo>
    {
        bool LogIn(string userName,string userPassword);

        IList<UserVM> GetAllUserVM();

        string GetUIDbyUserName(string userName);

        int GetAllActiveUserCount();

        UserVM GetUserVM(string id);
    }
}

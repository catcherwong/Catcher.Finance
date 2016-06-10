using System;
using System.Collections.Generic;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;

namespace Catcher.Finance.Logic
{
    public interface IUserLogic
    {
        ResponseModel Login(string uesrName,string userPassword);

        ResponseModel Register(UserInfo user);

        IList<UserVM> GetAll();

        string GetUIDbyUserName(string userName);

        UserInfo GetUserById(object uid);

        int GetAllActiveUserCount();

        UserVM GetUserVM(string id);
    }
}

using System;
using System.Collections.Generic;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;

namespace Catcher.Finance.Logic
{
    public interface IAdminLogic
    {
        ResponseModel Login(string adminName,string adminPassword);

        AdminInfo ValidAdmin(System.Guid id);

        System.Guid LogInAndReturnUID(string adminName, string adminPassword);
    }
}

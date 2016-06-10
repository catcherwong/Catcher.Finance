using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using System.Collections.Generic;

namespace Catcher.Finance.DataAccess
{
    public interface IAdminRepository: IBaseRepository<AdminInfo>
    {
        bool LogIn(string adminName,string adminPassword);

        AdminInfo ValidAdmin(System.Guid id);

        System.Guid LogInAndReturnUID(string adminName, string adminPassword);
    }
}

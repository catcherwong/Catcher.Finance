using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using System.Collections.Generic;

namespace Catcher.Finance.DataAccess
{
    public interface ICategoryRepository : IBaseRepository<CategoryInfo>
    {     
        IList<CategoryVM> GetAllCategory();
    }
}

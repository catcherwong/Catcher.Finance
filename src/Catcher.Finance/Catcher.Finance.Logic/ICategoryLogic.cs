using System;
using System.Collections.Generic;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
namespace Catcher.Finance.Logic
{
    public interface ICategoryLogic
    {
        IList<CategoryVM> GetAll();

        ResponseModel AddCategory(CategoryInfo category);

        ResponseModel DeleteCategory(object id);

        CategoryInfo GetCategoryById(object id);

        ResponseModel UpdateCategory(CategoryInfo category);
    }
}

using System;
using System.Collections.Generic;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using Catcher.Finance.DataAccess.ImplementByMongoDB;
using Catcher.Finance.DataAccess;
namespace Catcher.Finance.Logic.ImplementByMongoDB
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryRepository _repo;

        public CategoryLogic()
        {
            _repo = new CategoryRepository();
        }

        public ResponseModel AddCategory(CategoryInfo category)
        {
            ResponseModel model = new ResponseModel();
            if (_repo.Add(category))
            {
                model.Code = "0000";
                model.Msg = "add success";
            }
            else
            {
                model.Code = "0001";
                model.Msg = "add fail";
            }
            return model;
        }

        public ResponseModel DeleteCategory(object id)
        {
            ResponseModel model = new ResponseModel();
            if (_repo.DeleteById(id))
            {
                model.Code = "0000";
                model.Msg = "delete success";
            }
            else
            {
                model.Code = "0001";
                model.Msg = "delete fail";
            }
            return model;
        }

        public IList<CategoryVM> GetAll()
        {
            return _repo.GetAllCategory();
        }

        public CategoryInfo GetCategoryById(object id)
        {
            return _repo.GetById(id);
        }

        public ResponseModel UpdateCategory(CategoryInfo category)
        {
            ResponseModel model = new ResponseModel();
            if (_repo.Update(category))
            {
                model.Code = "0000";
                model.Msg = "update success";
            }
            else
            {
                model.Code = "0001";
                model.Msg = "update fail";
            }
            return model;
        }
    }
}

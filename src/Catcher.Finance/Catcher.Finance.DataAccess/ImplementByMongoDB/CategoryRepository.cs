using Catcher.Finance.Entities;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Catcher.Finance.Entities.ViewModels;

namespace Catcher.Finance.DataAccess.ImplementByMongoDB
{
    public class CategoryRepository : ICategoryRepository
    {
        MongoRepository<CategoryInfo> repo = new MongoRepository<CategoryInfo>();

        /// <summary>
        /// add a new category
        /// </summary>
        /// <param name="entity">the category</param>
        /// <returns></returns>
        public bool Add(CategoryInfo entity)
        {
            return repo.Add(entity)!=null;
        }

        public bool Delete(CategoryInfo entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// delete the category by id
        /// </summary>
        /// <param name="Id">the identity of the category</param>
        /// <returns></returns>
        public bool DeleteById(object Id)
        {
            repo.Delete(GetById(Id));
            return true;
        }

        /// <summary>
        /// get the categories
        /// </summary>
        /// <returns></returns>
        public IList<CategoryInfo> GetAll()
        {
            return repo.ToList();            
        }

        public IList<CategoryVM> GetAllCategory()
        {
            return repo.Select(x => new CategoryVM
            {
                Id = x.Id,
                CategoryName = x.CategoryName
            }).ToList();
        }

        /// <summary>
        /// get the category by id
        /// </summary>
        /// <param name="Id">the identity of the category</param>
        /// <returns></returns>
        public CategoryInfo GetById(object Id)
        {
            return repo.GetById((string)Id);
        }        

        public bool Update(CategoryInfo entity)
        {
            return repo.Update(entity) != null;
        }
    }
}

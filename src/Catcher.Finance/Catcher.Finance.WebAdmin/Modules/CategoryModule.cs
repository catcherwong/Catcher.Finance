using Catcher.Finance.Logic;
using Catcher.Finance.Entities;
using Nancy;
using Nancy.Security;
using Newtonsoft.Json;
using Nancy.ModelBinding;

namespace Catcher.Finance.WebAdmin.Modules
{
    public class CategoryModule : NancyModule
    {
        private ICategoryLogic _cateLogic;
        public CategoryModule(ICategoryLogic cateLogic) : base("/main/category")
        {
            this._cateLogic = cateLogic;

            this.RequiresAuthentication();

            Get["/"] = _ => ShowCategoryPage();

            //get all categories
            Post["/getall"] = _ => GetAllCategories();

            //add a category
            Post["/add"] = _ => AddCategory(Request.Form["name"]);

            //delete a category
            Post["/delete"] = _ => DeleteCategory(Request.Form["id"]);

            //Post["/getone/{id}"] = _ => 
            //{                
            //    return Response.AsJson(_cateLogic.GetCategoryById((string)_.id));
            //};

            Post["/edit"] = _ => 
            {
                //string id = _.id;
                var entity = this.Bind<CategoryInfo>();



                return Response.AsJson(_cateLogic.UpdateCategory(entity)) ;
            };
        }

        /// <summary>
        /// delete the category
        /// </summary>
        /// <param name="id">the identity of the category</param>
        /// <returns></returns>
        private dynamic DeleteCategory(string id)
        {
            ResponseModel json = _cateLogic.DeleteCategory(id);

            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// add the category
        /// </summary>
        /// <param name="name">the name of the category you want to add</param>
        /// <returns></returns>
        private dynamic AddCategory(string name)
        { 
            CategoryInfo entity = new CategoryInfo { CategoryName = name };

            ResponseModel json = _cateLogic.AddCategory(entity);

            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        private dynamic GetAllCategories()
        {           
            var json = new
            {
                Code = "0000",
                Msg = "success",
                Row = _cateLogic.GetAll()
            };         
            return Response.AsText(JsonConvert.SerializeObject(json), "application/json; charset =UTF-8");
        }

        /// <summary>
        /// get the category page
        /// </summary>
        /// <returns></returns>
        private dynamic ShowCategoryPage()
        {
            ViewBag.name = Request.Session["name"];
            return View["index"];
        }
    }
}
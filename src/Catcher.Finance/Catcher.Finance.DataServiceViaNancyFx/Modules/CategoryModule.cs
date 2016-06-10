using Catcher.Finance.Logic;
using Catcher.Finance.Entities;
using Nancy;
using Newtonsoft.Json;
using System;

namespace Catcher.Finance.DataServiceViaNancyFx.Modules
{
    public class CategoryModule : NancyModule
    {
        private ICategoryLogic _categoryLogic;
        public CategoryModule(ICategoryLogic categoryLogic) : base("/category")
        {
            this._categoryLogic = categoryLogic;

            Get["/getallcategory"] = _ => //GetAllCategories();
            {
                try
                {
                    var json = new
                    {
                        Code = "0000",
                        Data = _categoryLogic.GetAll()
                    };

                    return Response.AsText(JsonConvert.SerializeObject(json), "application/json;charset=UTF-8");
                }
                catch (Exception ex)
                {
                    return Response.AsText(JsonConvert.SerializeObject(new ResponseModel() { Code = "0009", Msg = ex.Message }), "application/json;charset=UTF-8");
                }
            };
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        private dynamic GetAllCategories()
        {
            try
            {
                var json = new
                {
                    Code = "0000",
                    Data = _categoryLogic.GetAll()
                };

                return Response.AsText(JsonConvert.SerializeObject(json), "application/json;charset=UTF-8");
            }
            catch (Exception ex)
            {
                return Response.AsText(JsonConvert.SerializeObject(new ResponseModel() { Code = "0009", Msg = ex.Message }), "application/json;charset=UTF-8");
            }
        }
    }
}
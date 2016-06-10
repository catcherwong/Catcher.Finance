using Catcher.Finance.Logic;
using Catcher.Finance.Entities;
using System;
using System.Web.Mvc;

namespace Catcher.Finance.DataServiceViaMVC.Controllers
{
    public class categoryController : Controller
    {
        private ICategoryLogic _categoryLogic;
        public categoryController(ICategoryLogic categoryLogic)
        {
            this._categoryLogic = categoryLogic;
        }
        
        /// <summary>
        /// get all of the categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getallcategory()
        {
            try
            {
                var list = _categoryLogic.GetAll();
                var json = new
                {
                    Code = "0000",
                    Data = list
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseModel() { Code="0009",Msg=ex.Message });
            }            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Catcher.Finance.APP.Models
{
    public class CategoryInfo 
    {        
        public int CategoryID { get; set; }
        
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return this.CategoryID.ToString();
        }
    }

    public class Category : Java.Lang.Object
    {
        public string CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
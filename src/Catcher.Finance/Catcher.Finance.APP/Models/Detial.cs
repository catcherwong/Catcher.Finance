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
    public class Detial
    {
        public string MoneyId{get;set;}
        public string CategoryName { get; set; }
        public string MoneyAbout { get; set; }
        public string MoneyType { get; set; }
        public string MoneyDate { get; set; }
        public string MoneyValue { get; set; }
    }
}
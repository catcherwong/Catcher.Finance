using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher.Finance.Models.ViewModel
{
    public class MoneyListViewVM
    {
        public Guid MoneyId { get; set; }
        public string MoneyDate { get; set; }
        public string MoneyAbout { get; set; }
        public string MoneyType { get; set; }
        public string MoneyValue { get; set; }
        public string CategoryName { get; set; }
    }
}

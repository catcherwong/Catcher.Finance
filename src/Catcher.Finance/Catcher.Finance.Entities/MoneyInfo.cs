using MongoRepository;
using System;

namespace Catcher.Finance.Entities
{
    [CollectionName("moneyinfo")]
    public class MoneyInfo : Entity
    {
        public string MoneyUID { get; set; }

        public string MoneyType { get; set; }

        public string MoneyCategoryID { get; set; }

        public decimal MoneyValue { get; set; }

        public DateTime MoneyDate { get; set; }

        public string MoneyAbout { get; set; }
    }
}

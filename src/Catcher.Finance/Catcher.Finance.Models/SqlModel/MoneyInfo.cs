namespace Catcher.Finance.Models.SqlModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MoneyInfo")]
    public partial class MoneyInfo
    {
        [Key]
        public Guid MoneyID { get; set; }

        public Guid MoneyUID { get; set; }

        [Required]
        [StringLength(50)]
        public string MoneyType { get; set; }

        public int MoneyCategoryID { get; set; }

        public decimal MoneyValue { get; set; }

        public DateTime MoneyDate { get; set; }

        public string MoneyAbout { get; set; }

        //public virtual CategoryInfo CategoryInfo { get; set; }

        //public virtual UserInfo UserInfo { get; set; }
    }
}

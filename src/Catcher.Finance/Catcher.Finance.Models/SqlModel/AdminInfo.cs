namespace Catcher.Finance.Models.SqlModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;    

    [Table("AdminInfo")]
    public partial class AdminInfo
    {
        [Key]
        public Guid AdminID { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminPassword { get; set; }

        public int AdminState { get; set; }
    }
}

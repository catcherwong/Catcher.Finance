using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher.Finance.Models.ViewModel
{
    public class UserVM
    {        
        public Guid UserID { get; set; }
        
        public string UserName { get; set; }
        
        public string UserPassword { get; set; }
        
        public string UserGender { get; set; }
        
        public string UserEmail { get; set; }

        public int UserState { get; set; }
    }
}

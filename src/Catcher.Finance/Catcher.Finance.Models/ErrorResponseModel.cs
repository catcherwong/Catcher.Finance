using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher.Finance.Models
{
    public class ErrorResponseModel:ResponseModel
    {
        public string Error { get; set; }

        public static ErrorResponseModel GetError(string err)
        {
            ErrorResponseModel m = new ErrorResponseModel();

            m.Code = "1111";
            m.Msg = "error";
            m.Error = err;
            return m;
        }

    }
}

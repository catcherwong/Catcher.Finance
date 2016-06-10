using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catcher.Finance.DataAccess;
using Catcher.Finance.DataAccess.ImplementByMongoDB;
using Catcher.Finance.Entities;

namespace Catcher.Finance.Logic.ImplementByMongoDB
{
    public class AdminLogic : IAdminLogic
    {
        private IAdminRepository _repo;
        public AdminLogic()
        {
            _repo = new AdminRepository();
        }

        public ResponseModel Login(string adminName, string adminPassword)
        {
            bool flag = _repo.LogIn(adminName, adminPassword);
            ResponseModel responseModel = new ResponseModel();

            if (flag)
            {
                responseModel.Code = "0000";
                responseModel.Msg = "login success";
            }
            else
            {
                responseModel.Code = "0001";
                responseModel.Msg = "login failed";
            }

            return responseModel;
        }

        public Guid LogInAndReturnUID(string adminName, string adminPassword)
        {
            return _repo.LogInAndReturnUID(adminName,adminPassword);
        }

        public AdminInfo ValidAdmin(Guid id)
        {
            return _repo.ValidAdmin(id);
        }
    }
}

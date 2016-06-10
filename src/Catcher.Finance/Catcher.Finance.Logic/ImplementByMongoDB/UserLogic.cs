using System;
using System.Collections.Generic;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using Catcher.Finance.DataAccess.ImplementByMongoDB;
using Catcher.Finance.DataAccess;

namespace Catcher.Finance.Logic.ImplementByMongoDB
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository _repo;
        public UserLogic()
        {
            _repo = new UserRepository();
        }
        
        public IList<UserVM> GetAll()
        {
            return _repo.GetAllUserVM();
        }

        public int GetAllActiveUserCount()
        {
            return _repo.GetAllActiveUserCount();
        }

        public string GetUIDbyUserName(string userName)
        {
            return _repo.GetUIDbyUserName(userName);
        }

        public UserInfo GetUserById(object uid)
        {
            try
            {
                return _repo.GetById(uid);
            }
            catch (Exception ex)
            {
                return new UserInfo();
            }
        }

        public UserVM GetUserVM(string id)
        {
            return _repo.GetUserVM(id);
        }

        public ResponseModel Login(string userName, string userPassword)
        {
            bool flag = _repo.LogIn(userName, userPassword);
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

        public ResponseModel Register(UserInfo user)
        {
            bool flag = _repo.Add(user);
            ResponseModel responseModel = new ResponseModel();

            if (flag)
            {
                responseModel.Code = "0000";
                responseModel.Msg = "register success";
            }
            else
            {
                responseModel.Code = "0001";
                responseModel.Msg = "register failed";
            }

            return responseModel;
        }
    }
}

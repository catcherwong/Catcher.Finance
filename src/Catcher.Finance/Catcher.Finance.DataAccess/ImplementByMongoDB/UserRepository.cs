using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catcher.Finance.DataAccess.ImplementByMongoDB
{
    public class UserRepository : IUserRepository
    {
        MongoRepository<UserInfo> repo = new MongoRepository<UserInfo>();

        /// <summary>
        /// add a new user
        /// </summary>
        /// <param name="entity">the user entity</param>
        /// <returns>success or fail</returns>
        public bool Add(UserInfo entity)
        {
            entity.UserState = 1;
            return repo.Add(entity) != null;
        }

        public bool Delete(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(object Id)
        {
            throw new NotImplementedException();
        }

        public IList<UserInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get the count of actived user
        /// </summary>
        /// <returns></returns>
        public int GetAllActiveUserCount()
        {
            return repo.Count(x => x.UserState == 1);
        }

        /// <summary>
        /// get the list of user
        /// </summary>
        /// <returns></returns>
        public IList<UserVM> GetAllUserVM()
        {
            return repo.Select(x => new UserVM
            {
                UserID = x.Id,
                UserEmail = x.UserEmail,
                UserName = x.UserName,
                UserState = x.UserState,
                UserGender = x.UserGender
            }).ToList();
        }

        /// <summary>
        /// get the user by id
        /// </summary>
        /// <param name="Id">the Identity of the user</param>
        /// <returns></returns>
        public UserInfo GetById(object Id)
        {
            return repo.GetById((string)Id);
        }

        /// <summary>
        /// get the identity of the user by user's name
        /// </summary>
        /// <param name="userName">the name of user</param>
        /// <returns></returns>
        public string GetUIDbyUserName(string userName)
        {
            return repo.First(x => x.UserName == userName).Id;
        }

        /// <summary>
        /// get the user's view model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserVM GetUserVM(string id)
        {
            UserInfo user = repo.GetById(id);
            UserVM vm = new UserVM
            {
                UserID = user.Id,
                UserEmail = user.UserEmail,
                UserGender = user.UserGender,
                UserName = user.UserName,
                UserState = user.UserState
            };
            return vm;
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="userName">the name user input</param>
        /// <param name="userPassword">the password user input</param>
        /// <returns></returns>
        public bool LogIn(string userName, string userPassword)
        {
            return repo.FirstOrDefault(x => x.UserName == userName && x.UserPassword == userPassword) != null;
        }

        public bool Update(UserInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
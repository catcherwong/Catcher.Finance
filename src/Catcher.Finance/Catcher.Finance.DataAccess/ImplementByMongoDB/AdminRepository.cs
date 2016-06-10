using System;
using System.Collections.Generic;
using System.Linq;
using Catcher.Finance.Entities;
using MongoRepository;

namespace Catcher.Finance.DataAccess.ImplementByMongoDB
{
    public class AdminRepository : IAdminRepository
    {
        MongoRepository<AdminInfo> repo = new MongoRepository<AdminInfo>();

        public bool Add(AdminInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AdminInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(object Id)
        {
            throw new NotImplementedException();
        }

        public IList<AdminInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public AdminInfo GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public bool LogIn(string adminName, string adminPassword)
        {
            return repo.FirstOrDefault(x => x.AdminName == adminName && x.AdminPassword == adminPassword) != null;
        }

        public Guid LogInAndReturnUID(string adminName, string adminPassword)
        {
            return Guid.Parse(repo.First(x => x.AdminName == adminName && x.AdminPassword == adminPassword&&x.AdminState==1).AdminID);
        }

        public bool Update(AdminInfo entity)
        {
            throw new NotImplementedException();
        }

        public AdminInfo ValidAdmin(Guid id)
        {
            string adminId = id.ToString();
            return repo.First(x=>x.AdminID==adminId && x.AdminState==1);
        }
    }
}

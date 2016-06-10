using MongoRepository;

namespace Catcher.Finance.Entities
{
    [CollectionName("userinfo")]
    public class UserInfo : Entity
    {        
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserGender { get; set; }

        public string UserEmail { get; set; }

        public int UserState { get; set; }
    }
}

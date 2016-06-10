using MongoRepository;

namespace Catcher.Finance.Entities
{
    [CollectionName("admininfo")]
    public class AdminInfo : Entity
    {
        public string AdminID { get; set; }

        public string AdminName { get; set; }
        
        public string AdminPassword { get; set; }

        public int AdminState { get; set; }
    }
}

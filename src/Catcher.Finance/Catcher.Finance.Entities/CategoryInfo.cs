using MongoRepository;

namespace Catcher.Finance.Entities
{
    [CollectionName("categoryinfo")]
    public class CategoryInfo : Entity
    {
        public string CategoryName { get; set; }
    }
}

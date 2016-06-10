using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Catcher.Finance.DataAccess.Test
{
    public class CategoryRepositoryTest
    {
        private Mock<ICategoryRepository> _fakeObject;
        private IList<CategoryVM> _vmList;
        private CategoryInfo _category;
        public CategoryRepositoryTest()
        {
            _fakeObject = new Mock<ICategoryRepository>();
            _vmList = GetVMList();
            _category = GetCategory();
        }

        [Fact]
        public void get_all_categories_should_success()
        {
            _fakeObject.Setup(x => x.GetAllCategory()).Returns(_vmList);

            var actual = _fakeObject.Object.GetAllCategory();

            Assert.Equal(2,actual.Count);
        }

        [Fact]
        public void add_category_should_success()
        {
            _fakeObject.Setup(x => x.Add(It.IsAny<CategoryInfo>())).Returns(true);

            var actual = _fakeObject.Object.Add(_category);

            Assert.Equal(true,actual);
        }

        [Fact]
        public void get_by_id_should_success_and_return_category()
        {
            _fakeObject.Setup(x => x.GetById(It.IsAny<string>())).Returns(_category);

            var actual = _fakeObject.Object.GetById("574655b05e40360f6cc04b3d");

            Assert.IsType<CategoryInfo>(actual);
            Assert.Equal("name",actual.CategoryName);
        }

        [Fact]
        public void delete_category_by_id_should_success_and_return_true()
        {
            _fakeObject.Setup(x => x.DeleteById(It.IsAny<string>())).Returns(true);

            var actual = _fakeObject.Object.DeleteById("574655b05e40360f6cc04b3d");

            Assert.Equal(true,actual);
        }

        private IList<CategoryVM> GetVMList()
        {
            return new List<CategoryVM>()
            {
                new CategoryVM { Id="574655b05e40360f6cc04b3d", CategoryName="name1" },
                new CategoryVM { Id="574655b05e40360f6cc04b3e",CategoryName="name2"},
            };
        }

        private CategoryInfo GetCategory()
        {
            return new CategoryInfo()
            {
                Id = "574655b05e40360f6cc04b3d",
                CategoryName = "name"
            };
        }
    }
}

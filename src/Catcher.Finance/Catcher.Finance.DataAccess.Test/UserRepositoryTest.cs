using Catcher.Finance.Common;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Catcher.Finance.DataAccess.Test
{
    public class UserRepositoryTest
    {
        private List<UserVM> _userList;
        private UserInfo _user;
        private Mock<IUserRepository> _fakeObject;

        public UserRepositoryTest()
        {
            _userList = GetVMList();
            _user = GetUserInfo();
            _fakeObject = new Mock<IUserRepository>();
        }

        [Fact]
        public void login_should_be_success_and_return_true()
        {

            _fakeObject.Setup(x => x.LogIn(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var actual = _fakeObject.Object.LogIn("test1", HMACMD5Encrypt.GetEncryptResult("123"));

            Assert.Equal(true, actual);
        }

        [Fact]
        public void login_should_be_faile_and_return_false()
        {
            _fakeObject.Setup(x => x.LogIn(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            var actual = _fakeObject.Object.LogIn("test", HMACMD5Encrypt.GetEncryptResult("123"));

            Assert.Equal(false, actual);
        }

        [Fact]
        public void get_user_list_should_success()
        {
            _fakeObject.Setup(x => x.GetAllUserVM()).Returns(_userList);

            var actual = _fakeObject.Object.GetAllUserVM();

            Assert.Equal(2, actual.Count);

            Parallel.ForEach(actual, x => Assert.Equal("male", x.UserGender));
        }

        [Fact]
        public void get_all_active_user_count_should_success()
        {
            _fakeObject.Setup(x => x.GetAllActiveUserCount()).Returns(1);

            var actual = _fakeObject.Object.GetAllActiveUserCount();

            Assert.Equal(1, actual);
        }

        [Fact]
        public void get_uid_by_username_should_success()
        {
            _fakeObject.Setup(x => x.GetUIDbyUserName(It.IsAny<string>())).Returns("5746536c5e4036287cab2584");

            var actual = _fakeObject.Object.GetUIDbyUserName("name");

            Assert.Equal("5746536c5e4036287cab2584", actual);
        }

        private List<UserVM> GetVMList()
        {
            List<UserVM> list = new List<UserVM>();
            list.Add(new UserVM { UserID = "5746536c5e4036287cab2584", UserEmail = "test1@qq.com", UserGender = "male", UserName = "test1", UserPassword = "6DE767819DC54477DFC4C670F74FFFA7", UserState = 1 });
            list.Add(new UserVM { UserID = "5746536c5e4036287cab2584", UserEmail = "test2@126.com", UserGender = "male", UserName = "test2", UserPassword = "6DE767819DC54477DFC4C670F74FFFA7", UserState = 0 });
            return list;
        }

        private UserInfo GetUserInfo()
        {
            return new UserInfo
            {
                Id = "5746536c5e4036287cab2584",
                UserEmail = "name@qq.com",
                UserGender = "male",
                UserName = "name",
                UserPassword = "6DE767819DC54477DFC4C670F74FFFA7",
                UserState = 1
            };
        }

    }
}
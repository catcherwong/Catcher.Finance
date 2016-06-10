using Catcher.Finance.Common;
using Catcher.Finance.Entities;
using Moq;
using Xunit;
namespace Catcher.Finance.DataAccess.Test
{
    public class AdminRepositoryTest
    {
        private Mock<IAdminRepository> _fakeObject;
        private AdminInfo _admin;

        public AdminRepositoryTest()
        {
            _fakeObject = new Mock<IAdminRepository>();
            _admin = GetAdminInfo();
        }
        
        [Fact]
        public void valid_admin_should_success_and_return_admin_infomation()
        {
            _fakeObject.Setup(x=>x.ValidAdmin(It.IsAny<System.Guid>())).Returns(_admin);

            var actual = _fakeObject.Object.ValidAdmin(System.Guid.Parse("d2903097-cfd1-46e5-b197-e8c51f1d20e2"));

            Assert.IsType<AdminInfo>(actual);
            Assert.Equal("admin",actual.AdminName);            
        }

        [Fact]
        public void login_should_success_and_return_uid()
        {
            _fakeObject.Setup(x => x.LogInAndReturnUID(It.IsAny<string>(),It.IsAny<string>())).Returns(System.Guid.Parse("d2903097-cfd1-46e5-b197-e8c51f1d20e2"));

            var actual = _fakeObject.Object.LogInAndReturnUID("admin",HMACMD5Encrypt.GetEncryptResult("123"));

            Assert.Equal(System.Guid.Parse("d2903097-cfd1-46e5-b197-e8c51f1d20e2"),actual);
        }

        private AdminInfo GetAdminInfo()
        {
            return new AdminInfo { AdminID = "d2903097-cfd1-46e5-b197-e8c51f1d20e2", AdminName = "admin", AdminPassword = "6DE767819DC54477DFC4C670F74FFFA7", AdminState = 1, Id = "574657be5e4036142c205234" };
        }
    }
}

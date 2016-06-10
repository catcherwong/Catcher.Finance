using Xunit;

namespace Catcher.Finance.Common.Test
{
    public class HMACMD5EncryptTest
    {
        [Fact]
        public void HMACMD5Encrypt_Should_Be_Right()
        {
            string data = "123";
            string expectedResult = "6DE767819DC54477DFC4C670F74FFFA7";

            string actualResult = HMACMD5Encrypt.GetEncryptResult(data);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void HMACMD5Encrypt_Should_Be_False()
        {
            string data = "123";
            string expectedResult = "6DE767819DC54477DFC4C670F74FFFA6";

            string actualResult = HMACMD5Encrypt.GetEncryptResult(data);

            Assert.NotEqual(expectedResult, actualResult);
        }

    }
}

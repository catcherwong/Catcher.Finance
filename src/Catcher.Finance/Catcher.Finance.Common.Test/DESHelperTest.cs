using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Catcher.Finance.Common;

namespace Catcher.Finance.Common.Test
{
    public class DESHelperTest
    {
        [Fact]
        public void encrypt_and_decrypt_should_success()
        {
            string data = "123";

            string str = DESHelper.DESEncrypt(data);

            Assert.Equal(data,DESHelper.DESDecrypt(str));
        }
        
    }
}

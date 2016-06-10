using Catcher.Finance.Common;
using Catcher.Finance.Entities;
using Catcher.Finance.Entities.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Catcher.Finance.DataAccess.Test
{
    public class MoneyRepositoryTest 
    {
        private Mock<IMoneyRepository> _fakeObject;
        private IList<MoneyVM> _vmList;

        public MoneyRepositoryTest()
        {
            _fakeObject = new Mock<IMoneyRepository>();

        }


        private IList<MoneyVM> GetVMList()
        {
            IList<MoneyVM> vmList = new List<MoneyVM>();
            vmList.Add(new MoneyVM
            {
                 
            });

            return vmList;
        }

    }
}

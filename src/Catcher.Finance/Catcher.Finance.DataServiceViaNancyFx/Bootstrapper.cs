using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.TinyIoc;
using Catcher.Finance.Logic;
using Catcher.Finance.Logic.ImplementByMongoDB;

namespace Catcher.Finance.DataServiceViaNancyFx
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IUserLogic, UserLogic>();
            container.Register<ICategoryLogic, CategoryLogic>();
            container.Register<IMoneyLogic, MoneyLogic>();
        }
    }
}
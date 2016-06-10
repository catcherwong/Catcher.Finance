using Autofac;
using Autofac.Integration.Mvc;
using Catcher.Finance.Logic;
using Catcher.Finance.Logic.ImplementByMongoDB;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Catcher.Finance.DataServiceViaMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ContainerBuilder builder = new ContainerBuilder();
            
            SetupResolveRules(builder);
            
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));           
        }

        private void SetupResolveRules(ContainerBuilder builder)
        {
            builder.RegisterType<UserLogic>().As<IUserLogic>();
            builder.RegisterType<CategoryLogic>().As<ICategoryLogic>();   
            builder.RegisterType<MoneyLogic>().As<IMoneyLogic>();           
        }
    }
}

using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Catcher.Finance.Logic;
using Catcher.Finance.Logic.ImplementByMongoDB;
using Nancy.Session;
using Nancy.Authentication.Forms;
using Nancy.Conventions;

namespace Catcher.Finance.WebAdmin
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            //enable session
            CookieBasedSessions.Enable(pipelines);
            StaticConfiguration.DisableErrorTraces = false;
        }
       
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            //config the ioc register
            container.Register<IUserLogic,UserLogic>();
            container.Register<ICategoryLogic, CategoryLogic>();
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register<IUserMapper, UserMapper>();
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            var formsAuthConfiguration = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/",
                UserMapper = container.Resolve<IUserMapper>(),
            };
            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Contents"));
        }
    }
}
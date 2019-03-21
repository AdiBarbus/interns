using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;
using Interns.Services.Service;

namespace Interns.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(Global).Assembly);
            builder.RegisterModelBinders(typeof(Global).Assembly);
            builder.RegisterModelBinderProvider();

            //Insert injections here
            //builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            //builder.RegisterType<AdvertiseRepository>().As<IAdvertiseRepository>();
            //builder.RegisterType<DomainRepository>().As<IDomainRepository>();
            //builder.RegisterType<QaRepository>().As<IQaRepository>();
            //builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            //builder.RegisterType<SubDomainRepository>().As<ISubDomainRepository>();
            //builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(InternsServices)))
            //    .Where(t => t.Namespace.Contains("Service"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<DomainService>().As<IDomainService>();
            builder.RegisterType<SubDomainService>().As<ISubDomainService>();
            builder.RegisterType<AdvertiseService>().As<IAdvertiseService>();
            builder.RegisterType<QAService>().As<IQaService>();
            //builder.RegisterType<AddressBll>().As<IAddressBll>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
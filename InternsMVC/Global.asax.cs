﻿using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using InternsBusiness.Business;
using InternsDataAccessLayer.Repository;

namespace InternsMVC
{
    public class MvcApplication : System.Web.HttpApplication
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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            //Insert injections here
            //builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            builder.RegisterType<AdvertiseRepository>().As<IAdvertiseRepository>();
            builder.RegisterType<DomainRepository>().As<IDomainRepository>();
            builder.RegisterType<QaRepository>().As<IQaRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<SubDomainRepository>().As<ISubDomainRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterType<UserBll>().As<IUserBll>();
            builder.RegisterType<RoleBll>().As<IRoleBll>();
            builder.RegisterType<DomainBll>().As<IDomainBll>();
            builder.RegisterType<SubDomainBll>().As<ISubDomainBll>();
            builder.RegisterType<AdvertiseBll>().As<IAdvertiseBll>();
            builder.RegisterType<QABll>().As<IQABll>();
           // builder.RegisterType<AddressBll>().As<IAddressBll>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}

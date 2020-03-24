using Autofac;
using Autofac.Integration.WebApi;
using ECIT.GIS.Service;
using System.Reflection;
using System.Web.Http;

namespace ECIT.GIS.WebService
{
    public class AutofacRegister
    {
        /// <summary>
        /// 注入用
        /// </summary>
        public static System.Web.Http.Dependencies.IDependencyResolver ApiResolver;
        /// <summary>
        /// 初始化autofac
        /// </summary>
        public static void InitAutoFac()
        {
            var build = new ContainerBuilder();
            var configuration = GlobalConfiguration.Configuration;
            build.RegisterModule(new ServiceModule());

            ///注册webapi 到autofac
            build.RegisterApiControllers(Assembly.GetExecutingAssembly());
            build.RegisterWebApiFilterProvider(configuration);
            build.RegisterWebApiModelBinderProvider();

            
            var container = build.Build();

            ///DI--wepi
            var apiResolver =  new AutofacWebApiDependencyResolver(container);
            ApiResolver = apiResolver;
            GlobalConfiguration.Configuration.DependencyResolver = apiResolver;
        }
    }
}
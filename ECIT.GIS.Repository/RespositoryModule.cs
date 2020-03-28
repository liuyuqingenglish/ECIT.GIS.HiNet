/*
* ==============================================================================
*
* Filename: RespositoryModule
* ClrVersion: 4.0.30319.42000
* Description: RespositoryModule
*
* Version: 1.0
* Created: 2020/1/11 9:38:58
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using Autofac;
using System.Linq;
using System.Reflection;

namespace ECIT.GIS.Repository
{
    public static class RespositoryModule
    {
        public static void Register(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}
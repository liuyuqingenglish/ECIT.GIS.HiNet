/*
* ==============================================================================
*
* Filename: ServiceModule
* ClrVersion: 4.0.30319.42000
* Description: ServiceModule
*
* Version: 1.0
* Created: 2020/1/11 11:22:46
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using Autofac;
using System.Linq;
using ECIT.GIS.Repository;
namespace ECIT.GIS.Service
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(c => c.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.Register();
        }
    }
}
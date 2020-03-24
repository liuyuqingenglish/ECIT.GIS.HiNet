/*
* ==============================================================================
*
* Filename: AutoMapperConfig
* ClrVersion: 4.0.30319.42000
* Description: AutoMapperConfig
*
* Version: 1.0
* Created: 2020/1/11 11:28:20
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using AutoMapper;

namespace ECIT.GIS.Service
{
    public static class AutoMapperConfig
    {
        private static IMapper mapper;

        public static void InitConfig()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DepartmentProfile>());
            mapper = config.CreateMapper();
        }

        public static TResult ToDto<TResult>(this object obj)
        {
            return mapper.Map<TResult>(obj);
        }
    }
}
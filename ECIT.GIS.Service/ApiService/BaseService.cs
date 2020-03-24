/*
* ==============================================================================
*
* Filename: BaseService
* ClrVersion: 4.0.30319.42000
* Description: BaseService
*
* Version: 1.0
* Created: 2020/1/11 9:10:34
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using ECIT.GIS.Repository;

namespace ECIT.GIS.Service
{
    public class BaseService
    {
        internal IUnitOfWork Unit;

        public BaseService(IUnitOfWork unit)
        {
            Unit = unit;
        }
    }
}
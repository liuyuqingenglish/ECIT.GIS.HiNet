using System;
using System.Collections;
using System.Collections.Generic;
using ECIT.GIS.Entity;
namespace ECIT.GIS.Service
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetDto();
    }
}
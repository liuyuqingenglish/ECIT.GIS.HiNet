using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECIT.GIS.Repository
{
   public interface IUnitOfWork
    {
        IDepartmentRepository DepartmentRepository { get; }
    }
}

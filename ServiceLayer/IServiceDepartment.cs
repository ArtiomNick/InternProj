using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IServiceDepartment
    {
        IList<DepartmentDto> GetAllDepartments();
    }
}

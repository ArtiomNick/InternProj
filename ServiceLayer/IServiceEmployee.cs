using Domain.Dto;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IServiceEmployee
    {
        IList<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployee(long id);
    }
}
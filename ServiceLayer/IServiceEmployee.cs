﻿using Domain.Dto;
using System.Collections.Generic;
using Repository;
using Domain;
using System;

namespace ServiceLayer
{
    public interface IServiceEmployee
    {
        void CreateEmployee(Employee employee);
        void EditEmployee(Employee employee, long id);
        void DeleteEmployee(Employee employee);
        IList<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeDto(long id);
        Employee GetEmployee(long id);

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;

namespace Repository.Interfaces
{
    public interface IDepartmentRepository : IRepository
    {
        IList<DepartmentDto> GetAllDepartments();
    }
}
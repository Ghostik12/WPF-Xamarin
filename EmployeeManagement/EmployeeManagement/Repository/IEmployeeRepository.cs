﻿using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(Guid id);

        void Add(Employee employee);

        void Delete(Guid id);
    }
}

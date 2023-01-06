using System;
using SS63Tiers.Api.Models;

namespace SS63Tiers.Api.Service;

public interface IEmployeeService
{
    Task<List<Employee>> EmployeeList();
    Task<Employee> EmployeeList(Guid Id);
    Task<List<Employee>> Search(string name);
    Task<bool> Save(Employee employee);
    Task<bool> Delete(Guid Id);
    Task<bool> Update(Employee employee,Guid Id);
}


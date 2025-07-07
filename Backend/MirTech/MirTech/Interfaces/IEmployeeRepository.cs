using MirTech.Entity.EntityModels;
using MirTech.Entity.Filters;

namespace MirTech.Interfaces;

public interface IEmployeeRepository
{
    public Task<Employee?> GetEmployeeAsync(int id);

    public Task<List<Employee>> GetEmployeesAsync(EmployeeFilter filter, string sortedBy, bool descOrder);

    public Task AddEmployeeAsync(Employee employee);

    public Task UpdateEmployeeAsync(Employee employee);

    public Task DeleteEmployeeAsync(int id);
}
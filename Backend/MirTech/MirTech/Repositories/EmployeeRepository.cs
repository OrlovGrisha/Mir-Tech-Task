using Microsoft.EntityFrameworkCore;
using MirTech.Data;
using MirTech.Entity.EntityModels;
using MirTech.Entity.Filters;
using MirTech.Extensions;
using MirTech.Interfaces;

namespace MirTech.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly MirContext _context;
    public EmployeeRepository(MirContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetEmployeeAsync(int id)
    {
        return await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
    }

    public async Task<List<Employee>> GetEmployeesAsync(EmployeeFilter filter, string sortedBy, bool descOrder)
    {
        var query = _context.Employees.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.FullName))
        {
            query = query.Where(employee => employee.FullName.Contains(filter.FullName));
        }

        if (!string.IsNullOrWhiteSpace(filter.Department))
        {
            query = query.Where(employee => employee.Department.Contains(filter.Department));
        }

        // Фильтрация зарплаты в разные стороны
        if (filter.LeftSalary.HasValue)
        {
            query = query.Where(employee => employee.Salary >= filter.LeftSalary);
        }

        if (filter.RightSalary.HasValue)
        {
            query = query.Where(employee => employee.Salary <= filter.RightSalary);
        }

        // Фильтрация даты найма в разные стороны
        if (filter.LeftHireDate.HasValue)
        {
            query = query.Where(employee => employee.HireDate >= filter.LeftHireDate);
        }

        if (filter.RightHireDate.HasValue)
        {
            query = query.Where(employee => employee.HireDate <= filter.RightHireDate);
        }
        
        // Фильтрация дня рождения сотрудника в разные стороны
        if (filter.LeftBirthday.HasValue)
        {
            query = query.Where(employee => employee.Birthday >= filter.LeftBirthday);
        }

        if (filter.RightBirthday.HasValue)
        {
            query = query.Where(employee => employee.Birthday <= filter.RightBirthday);
        }

        // Сортировка методом расширения
        query = query.SortEmployees(sortedBy, descOrder);

        return await query.ToListAsync();
    }

    public async Task AddEmployeeAsync(Employee employees)
    {
        await _context.Employees.AddAsync(employees);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee); // посмотреть ExecuteUpdateAsync()
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await _context.Employees
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync(); // посмотреть ExecuteDeleteAsync()
        
        await _context.SaveChangesAsync();
    }
}
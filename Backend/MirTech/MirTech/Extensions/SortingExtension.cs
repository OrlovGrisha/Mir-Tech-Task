using MirTech.Entity;
using MirTech.Entity.EntityModels;

namespace MirTech.Extensions;

public static class SortingExtension
{
    public static IQueryable<Employee> SortEmployees(this IQueryable<Employee> query, string sortedBy, bool descOrder)
    {
        return sortedBy.ToLower() switch
        {
            "fullname" => descOrder ? 
                query.OrderByDescending(e => e.FullName) : 
                query.OrderBy(e => e.FullName),
            
            "department" => descOrder ? 
                query.OrderByDescending(e => e.Department) : 
                query.OrderBy(e => e.Department),
            
            "salary" => descOrder ? 
                query.OrderByDescending(e => e.Salary) : 
                query.OrderBy(e => e.Salary),
            
            "birthday" => descOrder ? 
                query.OrderByDescending(e => e.Birthday) : 
                query.OrderBy(e => e.Birthday),
            
            "hiredate" => descOrder ?
                query.OrderByDescending(e => e.HireDate) :
                query.OrderBy(e => e.HireDate),
            
            // Дефолтная реализация
            _ => query.OrderBy(e => e.FullName)
        };
    }
}
namespace MirTech.Entity.Filters;

public class EmployeeFilter
{
    public string? Department { get; set; }
    public string? FullName { get; set; }
    
    public DateTime? LeftBirthday { get; set; }
    public DateTime? RightBirthday { get; set; }
    
    public DateTime? LeftHireDate { get; set; }
    public DateTime? RightHireDate { get; set; }
    
    public int? LeftSalary { get; set; }
    public int? RightSalary { get; set; }
}
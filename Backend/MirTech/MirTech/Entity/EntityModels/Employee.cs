namespace MirTech.Entity.EntityModels;

public class Employee
{
    public int Id { get; set; }
    public string Department { get; set; }
    public string FullName { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
}
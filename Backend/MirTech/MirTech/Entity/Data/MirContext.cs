using Microsoft.EntityFrameworkCore;
using MirTech.Entity.EntityModels;

namespace MirTech.Data;

public class MirContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public MirContext(DbContextOptions<MirContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
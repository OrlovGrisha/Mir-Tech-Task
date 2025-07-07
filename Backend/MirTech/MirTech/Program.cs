using Microsoft.EntityFrameworkCore;
using MirTech.Automapper;
using MirTech.Data;
using MirTech.Interfaces;
using MirTech.Repositories;

namespace MirTech;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularDev", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        builder.Services.AddDbContext<MirContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        app.UseCors("AllowAngularDev");
        
        app.MapControllers();

        app.Run();
    }
}
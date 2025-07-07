using AutoMapper;
using MirTech.Entity;
using MirTech.Entity.EntityModels;

namespace MirTech.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDTO>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Исправлено Condition
        
        CreateMap<EmployeeDTO, Employee>()
            .ForMember(dest => dest.Department,
                opt => opt.Condition(src => src.Department != null))
            .ForMember(dest => dest.FullName,
                opt => opt.Condition(src => src.FullName != null))
            .ForMember(dest => dest.Birthday,
                opt => opt.Condition(src => src.Birthday.HasValue))
            .ForMember(dest => dest.HireDate,
                opt => opt.Condition(src => src.HireDate.HasValue))
            .ForMember(dest => dest.Salary,
                opt => opt.Condition(src => src.Salary.HasValue));

        CreateMap<EmployeeUpdateDTO, Employee>()
            .ForMember(dest => dest.Department,
                opt => opt.Condition(src => src.Department != null))
            .ForMember(dest => dest.FullName,
                opt => opt.Condition(src => src.FullName != null))
            .ForMember(dest => dest.Birthday,
                opt => opt.Condition(src => src.Birthday.HasValue))
            .ForMember(dest => dest.HireDate,
                opt => opt.Condition(src => src.HireDate.HasValue))
            .ForMember(dest => dest.Salary,
                opt => opt.Condition(src => src.Salary.HasValue));
    }
}
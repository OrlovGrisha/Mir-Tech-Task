using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MirTech.Entity;
using MirTech.Entity.EntityModels;
using MirTech.Entity.Filters;
using MirTech.Interfaces;

namespace MirTech.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeesController(IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetEmployees([FromQuery] EmployeeFilter filter, 
        [FromQuery] string sortedBy = "FullName", 
        [FromQuery] bool descOrder = true)
    {
        var result = await _employeeRepository.GetEmployeesAsync(filter, sortedBy, descOrder);
        
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employeeDto) 
    {
        Employee employee = _mapper.Map<Employee>(employeeDto); // используется AutoMapper, так как у меня нет id пользователя при добавлении
        
        await _employeeRepository.AddEmployeeAsync(employee);
        
        return Ok();
    }
    
    [HttpPatch("update/{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO? dto)
    {
        var employee = await _employeeRepository.GetEmployeeAsync(id);
        
        if (employee == null)
            return NotFound();
        
        _mapper.Map(dto, employee);

        await _employeeRepository.UpdateEmployeeAsync(employee);
        
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteEmployeeAsync(id);
        
        return Ok();
    }
}
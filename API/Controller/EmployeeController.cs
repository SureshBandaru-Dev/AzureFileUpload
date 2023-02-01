using AutoMapper;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
     private IMapper _mapper { get; }
    public EmployeeController(IEmployeeService employeeService,IMapper mapper)
    {
        _employeeService = employeeService;
         _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _employeeService.GetEmployeeRecordsAsync();
        return result != null ? (IActionResult)Ok(result) : StatusCode(500);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] EmployeeDto employeeDto)
    {
        if (ModelState.IsValid)
        {
            Guid obj = Guid.NewGuid();                            
            var model= _mapper.Map<Employee>(employeeDto);
            model.id = obj.ToString();
            await _employeeService.AddEmployeeRecordAsync(model);
            return Ok(new { StatusCode = StatusCodes.Status201Created });
        }
        return StatusCode(StatusCodes.Status400BadRequest);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(string id)
    {
        var result = await _employeeService.GetEmployeeSingleRecordAsync(id);
        return result != null ? (IActionResult)Ok(result) : StatusCode(500);
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync([FromBody] Employee employee)
    {
        if (ModelState.IsValid)
        {
            var details = await _employeeService.GetEmployeeSingleRecordAsync(employee.id);
            if (details != null)
            {
                await _employeeService.UpdateEmployeeRecordAsync(employee);
                return Ok(new { StatusCode = StatusCodes.Status201Created });
            }
            else
            {
                return Ok(new { StatusCode = StatusCodes.Status404NotFound });
            }
        }
        return Ok(new { StatusCode = StatusCodes.Status400BadRequest });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfirmedAsync(string id)
    {
        var data = await _employeeService.GetEmployeeSingleRecordAsync(id);
        if (data == null)
        {
            return Ok(new { StatusCode = StatusCodes.Status404NotFound });
        }
        else
        {
            await _employeeService.DeleteEmployeeRecordAsync(data);
            return Ok(new { StatusCode = StatusCodes.Status201Created });
        }

    }
}
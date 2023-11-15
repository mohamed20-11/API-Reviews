using ChrAPI1.DTO;
using ChrAPI1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChrAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        SystemEntity context;
        public EmployeeController(SystemEntity context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult ShowAll()
        {
            List <Employee> employees = context.Employees.ToList();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult ShowAll(int id)
        {
            Employee EmployeesModel = context.Employees.Include(e => e.Department)
                .FirstOrDefault(e=>e.Id==id);

            EmployeeWithDepartmentDTO employeeWithDepartmentDTO = new EmployeeWithDepartmentDTO();
            employeeWithDepartmentDTO.EmpId = EmployeesModel.Id;
            employeeWithDepartmentDTO.EmpName = EmployeesModel.Name;
            employeeWithDepartmentDTO.DepartmentName=EmployeesModel.Department.Name;
            return Ok(employeeWithDepartmentDTO);
        }
    }
}

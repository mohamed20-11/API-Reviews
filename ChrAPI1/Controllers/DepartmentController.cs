using ChrAPI1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChrAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        SystemEntity context;
        public DepartmentController(SystemEntity _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult GetOk()
        {
            List<Department> departmentList = context.Department.ToList();
            return Ok(departmentList);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            Department department = context.Department.FirstOrDefault(x => x.Id == id);
            return Ok(department);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            Department department = context.Department.FirstOrDefault(x => x.Name == name);
            return Ok(department);
        }
        [HttpPost]
        public IActionResult New(Department dept)
        {
            if (ModelState.IsValid)
            {
                context.Department.Add(dept);
                context.SaveChanges();
                return Ok("Created Successfully");
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(int id, Department newDept)
        {
            if (ModelState.IsValid)
            {
                Department dept = context.Department.FirstOrDefault(e => e.Id == id);
                dept.Name = newDept.Name;
                dept.ManagerName = newDept.ManagerName;
                context.SaveChanges();
                return Ok("Updated");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Department department = context.Department.FirstOrDefault(e => e.Id == id);
                context.Department.Remove(department);
                context.SaveChanges();
                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}

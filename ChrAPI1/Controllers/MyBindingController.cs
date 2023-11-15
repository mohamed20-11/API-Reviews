using ChrAPI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChrAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBindingController : ControllerBase
    {
        [HttpGet("{Name}/{ManagerName}")]
        public IActionResult get(int id , string name, [FromRoute]Department deptObj)
        {

            return Ok($"{id}  : {name}");
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            return Ok($"{department.Name}");
        }
    }
}

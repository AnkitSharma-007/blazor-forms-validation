using BlazorFormsValidation.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFormsValidation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly List<string> userNameList = new();

        public EmployeeController()
        {
            userNameList.Add("ankit");
            userNameList.Add("simon");
            userNameList.Add("neha");
        }

        [HttpPost]
        public IActionResult Post(Employee employeeData)
        {
            if (userNameList.Contains(employeeData.Username.ToLower()))
            {
                ModelState.AddModelError(nameof(employeeData.Username), "This User Name is not available.");
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(ModelState);
            }
        }
    }
}

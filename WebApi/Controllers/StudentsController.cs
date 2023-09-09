using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents(CancellationToken CancellationToken)
        {
            var students = await _studentService.GetAllStudents(CancellationToken);
            return Ok(students);
        }
    }
}

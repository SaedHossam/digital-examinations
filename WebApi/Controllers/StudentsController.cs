using Microsoft.AspNetCore.Mvc;
using Models;
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
        public async Task<ActionResult> GetStudents()
        {
            var students = await _studentService.GetAllStudents();
            ApiResponseDto<Student> response = new() { IsSuccess = true, Results = students };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Student student = await _studentService.GetStudentDetails(id);
            if (student == null)
            {
                return NotFound(new ApiResponseDto<Student>()
                {
                    IsSuccess = false,
                    Message = "Student not found"
                });
            }
            ApiResponseDto<Student> response = new() { IsSuccess = true, Result = student };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] CreateStudentDto payload)
        {
            await _studentService.CreateStudent(payload);
            ApiResponseDto<Student> response = new() { IsSuccess = true };
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] CreateStudentDto payload)
        {
            Student student = await _studentService.GetStudentDetails(id);
            if (student == null)
            {
                return NotFound(new ApiResponseDto<Student>()
                {
                    IsSuccess = false,
                    Message = "Student not found"
                });
            }

            await _studentService.UpdateStudent(id, payload);
            ApiResponseDto<Student> response = new() { IsSuccess = true };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            Student student = await _studentService.GetStudentDetails(id);
            if (student == null)
            {
                return NotFound(new ApiResponseDto<Student>()
                {
                    IsSuccess = false,
                    Message = "Student not found"
                });
            }

            await _studentService.DeleteStudent(id);
            ApiResponseDto<Student> response = new() { IsSuccess = true };
            return Ok(response);
        }
    }
}

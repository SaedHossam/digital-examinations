using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<ActionResult> GetExams()
        {
            List<Exam> exams = await _examService.GetExams();
            return Ok(new ApiResponseDto<Exam>()
            {
                IsSuccess = true,
                Results = exams
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateExam([FromBody] CreateExamDto payload)
        {
            bool isValid = _examService.ValidateExamData(payload);
            if (!isValid)
            {
                return BadRequest(new ApiResponseDto<Exam>()
                {
                    IsSuccess = false,
                    Message = "Exam data not valid"
                });
            }
            await _examService.CreateExam(payload);
            return Ok(new ApiResponseDto<Exam>()
            {
                IsSuccess = true
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExam(int id)
        {
            Exam? exam = await _examService.GetExam(id);
            if(exam == null)
            {
                return NotFound(new ApiResponseDto<Exam>()
                {
                    IsSuccess = false,
                    Message = "Exam not found"
                });
            }
            return Ok(new ApiResponseDto<Exam>()
            {
                IsSuccess = true,
                Result = exam
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Exam? exam = await _examService.GetExam(id);
            if (exam == null)
            {
                return NotFound(new ApiResponseDto<Exam>()
                {
                    IsSuccess = false,
                    Message = "Exam not found"
                });
            }
            await _examService.Delete(id);
            return Ok(new ApiResponseDto<Exam>()
            {
                IsSuccess = true
            });
        }

    }
}

using Domain.UseCase.Gateways;
using Microsoft.AspNetCore.Mvc;
using VirtualEducation.DDD.Domain.Student.Commands;

namespace VirtualEducation.DDD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
       

        private readonly IStudentUseCase _useCase;

        public StudentController(IStudentUseCase createStudentUseCase)
        {
            _useCase = createStudentUseCase;
        }

        [HttpPost]
        public async Task Post(CreateStudentCommand command)
        {
            await _useCase.CreateStudent(command);
        }

        [HttpPost("addAcount")]
        public async Task Add_Account_To_Student(AddAccountCommand command)
        {
            await _useCase.AddAcountToStudent(command);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Student.Commands;
using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Student.Repositories;

namespace Domain.UseCase.Gateways
{
    public interface IStudentUseCase
    {

        Task CreateStudent(CreateStudentCommand command);

        Task AddAcountToStudent(AddAccountCommand command);
    }
}

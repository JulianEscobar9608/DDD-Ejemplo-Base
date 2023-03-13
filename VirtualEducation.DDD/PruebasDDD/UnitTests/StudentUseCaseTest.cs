using Domain.UseCase.Gateways;
using Domain.UseCase.UseCases;
using Moq;
using PruebasDDD.Builders;
using UseCaseTests.Builders;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.Student.Commands;
using Xunit;

namespace UseCaseTests.UnitTests
{
    public class StudentUseCaseTest
    {

        private readonly Mock<IStoredEventRepository<StoredEvent>> _mockRepository;

        public StudentUseCaseTest() {

            _mockRepository = new();
            
        }

        [Fact]
        public async Task Create_Student()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<int>(200));

            //Act
            var useCase = new StudentUseCase(_mockRepository.Object);

            await useCase.CreateStudent(GetStudentCommand());

            //Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()),Times.Exactly(2));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Add_Account_To_Student()
        {
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .Returns(Task.FromResult(GetListStoredEvent()));

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            var useCase = new StudentUseCase(_mockRepository.Object);

            await useCase.AddAcountToStudent(GetAddAccountCommand());

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.GetEventsByAggregateId(It.IsAny<string>()), Times.Once);

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }




        private CreateStudentCommand GetStudentCommand() =>
            new CreateStudentCommandBuilder()
                .WithName("John")
                .WithLastName("Doe")
                .WithAge(25)
                .WithGender("Male")
                .Build();


        private StoredEvent GetStoredEvent() => 
            new StoredEventBuilder()
                .WithStoredId("1")
                .WithStoredName("StudentCreated")
                .WithAggregateId("Aggregate1")
                .WithEventBody("{\"Type\":\"datosPersonales.agregados\",\"PersonalData\":{\"Name\":\"string\",\"LastName\":\"string\",\"Age\":0,\"Gender\":\"string\"}}")
                .Build();


        private List<StoredEvent> GetListStoredEvent() =>
            new()
            {
                new StoredEventBuilder()
                .WithStoredId("1")
                .WithStoredName("PersonalDataAdded")
                .WithAggregateId("c11d7c42-10d5-4e77-ac50-f1ec4dc8d388")
                .WithEventBody("{\"Type\":\"datosPersonales.agregados\",\"PersonalData\":{\"Name\":\"string\",\"LastName\":\"string\",\"Age\":0,\"Gender\":\"string\"}}")
                .Build(),

                new StoredEventBuilder()
                .WithStoredId("2")
                .WithStoredName("StudentCreated")
                .WithAggregateId("012dfccf-ceaf-457a-a0b7-87d6b9b9b3fc")
                .WithEventBody("{\"Type\":\"estudiante.creado\",\"StudentID\":\"VirtualEducation.DDD.Domain.Student.ValueObjects.Student.StudentID\"}")
                .Build()
            };


        private AddAccountCommand GetAddAccountCommand() =>
        new AddAccountCommandBuilder()
                .WithStudentId("c11d7c42-10d5-4e77-ac50-f1ec4dc8d388")
                .WithUsername("johndoe")
                .WithPersonalMail("johndoe@gmail.com")
                .WithInstitutionalMail("johndoe@university.edu")
                .Build();

    }
}

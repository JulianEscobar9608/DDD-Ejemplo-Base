using Domain.UseCase.Gateways;
using Newtonsoft.Json;
using VirtualEducation.DDD.Domain.Student.Commands;
using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Student.Events;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace Domain.UseCase.UseCases
{
    public class StudentUseCase : IStudentUseCase
    {

        private readonly IStoredEventRepository<StoredEvent> _storedEventRepository;

        public StudentUseCase(IStoredEventRepository<StoredEvent> studentRepository)
        {
            _storedEventRepository = studentRepository;
        }

        public async Task AddAcountToStudent(AddAccountCommand command)
        {
            var studentChange = new StudentChangeApply();
            var listDomainEvent = await GetEventsByAggregateID(command.StudentId);
            var studentId = StudentID.Of(Guid.Parse(command.StudentId));
            var studentGenerated = studentChange.CreateAggregate(listDomainEvent, studentId);

            Account newAccount = new Account(AccountID.Of(Guid.NewGuid()));

            studentGenerated.SetAccountToStudent(newAccount);

            List<DomainEvent> listDomain = studentGenerated.getUncommittedChanges();
            await SaveEvents(listDomain);

        }

        public async Task CreateStudent(CreateStudentCommand command)
        {

            var student = new Student(StudentID.Of(Guid.NewGuid()));
            var personalData = PersonalData.Create(
                       command.Name,
                       command.LastName,
                       command.Age,
                       command.Gender
                    );

            student.SetPersonalData(personalData);
            List<DomainEvent> listDomain = student.getUncommittedChanges();
            await SaveEvents(listDomain);

        }

        private async Task SaveEvents(List<DomainEvent> list)
        {
            var array = list.ToArray();
            for (var index = 0; index < array.Length; index++)
            {
                var stored = new StoredEvent();
                stored.StoredId = Guid.NewGuid().ToString();
                stored.AggregateId = array[index].GetAggregateId();
                stored.StoredName = array[index].GetAggregate();
                switch (array[index])
                {
                    case StudentCreated studentCreated:
                        stored.EventBody = JsonConvert.SerializeObject(studentCreated);
                        break;
                    case PersonalDataAdded personalDataAdded:
                        stored.EventBody = JsonConvert.SerializeObject(personalDataAdded);
                        break;
                    case AccountAdded accountAdded:
                        stored.EventBody = JsonConvert.SerializeObject(accountAdded);
                        break;
                    case AccountDetailAdded accountDetailAdded:
                        stored.EventBody = JsonConvert.SerializeObject(accountDetailAdded);
                        break;
                }
                await _storedEventRepository.AddAsync(stored);

            }

            await _storedEventRepository.SaveChangesAsync();

        }

        private async Task<List<DomainEvent>> GetEventsByAggregateID(string aggregateId)
        {
           var listadoStoredEvents = await _storedEventRepository.GetEventsByAggregateId(aggregateId);

           if (listadoStoredEvents == null)
                throw new ArgumentException("No existe el Id del agregado en la base de datos");

            return listadoStoredEvents.Select(ev =>
           {
               string nombre = $"VirtualEducation.DDD.Domain.Student.Events.{ev.StoredName}, VirtualEducation.DDD.Domain";
               Type tipo = Type.GetType(nombre);
               DomainEvent eventoParseado = (DomainEvent) JsonConvert.DeserializeObject(ev.EventBody,tipo);
               return eventoParseado;

           }).ToList();
        }


        
    }
}

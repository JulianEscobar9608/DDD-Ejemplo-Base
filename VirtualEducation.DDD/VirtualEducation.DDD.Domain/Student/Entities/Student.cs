using System.Globalization;
using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.CommonsDDD;
using VirtualEducation.DDD.Domain.Student.Events;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class Student : AggregateEvent<StudentID>
    {
        public StudentID StudentID { get; init; }


        public RegistrationID ClassroomRegistrationID { get; private set; }

        public PersonalData PersonalData { get; private set; }

        public virtual Account Account { get; private set; }

        public virtual ClassroomRegistration classroomregistration { get; private set; }



        #region Metodos del agregado como manejador de eventos

        public Student(StudentID id) : base(id)
        {

            AppendChange(new StudentCreated(id.ToString()));
        }


        public void SetPersonalData(PersonalData personalData)
        {
            AppendChange(new PersonalDataAdded(personalData));
        }

        public void SetAccountToStudent(Account accountToStudent)
        {
            AppendChange(new AccountAdded(accountToStudent));
        }

        public void SetDetailsToAccount(Account accountToStudent)
        {
            AppendChange(new AccountAdded(accountToStudent));
        }

        #endregion

        #region Metodos de cambio del agregado como entidad

        public void SetPersonalDataAggregate(PersonalData personalData)
        {
            PersonalData = personalData;
        }

        public void SetAccountAggregate(Account account)
        {
            Account = account;
        }

        #endregion



        public void SetClassroomRegistrationID(RegistrationID registrationID)
        {
            this.ClassroomRegistrationID = registrationID;
        }

    }
}

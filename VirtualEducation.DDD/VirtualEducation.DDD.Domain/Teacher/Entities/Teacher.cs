using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class Teacher
    {
        //variables
        public Guid TeacherID { get; init; }
        public AccountID AccountID { get; private set; }
        public RegistrationID ClassroomRegistrationID { get; private set; }
        public PersonalData PersonalData { get; private set; }
        //virtual navigation
        [JsonIgnore]
        public virtual Account? Account { get; private set; }
        public virtual ClassroomRegistration? ClassroomRegistration { get; private set; }
        //constructor
        public Teacher(Guid id)
        {
            this.TeacherID = id;
        }
        //set method for account id
        public void SetAccountID(AccountID accountID)
        {
            this.AccountID = accountID;
        }
        //set method for classroom registration id
        public void SetClassroomRegistrationID(RegistrationID registrationID)
        {
            this.ClassroomRegistrationID = registrationID;
        }
        //set method for personal data
        public void SetPersonalData(PersonalData personalData)
        {
            this.PersonalData = personalData;
        }
        //set method for account
        public void SetAccount(Account account)
        {
            this.Account = account;
        }
        //set method for classroom registration
        public void SetClassroomRegistration(ClassroomRegistration classroomRegistration)
        {
            this.ClassroomRegistration = classroomRegistration;
        }
    }
}

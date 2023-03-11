using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class ClassroomRegistration
    {
        //variables
        public Guid RegistrationID { get; init; }
        public RegistrationDetail RegistrationDetail { get; private set; }
        //constructor
        public ClassroomRegistration(Guid id)
        {
            this.RegistrationID = id;
        }
        //set method for registration detail
        public void SetRegistrationDetail(RegistrationDetail registrationDetail)
        {
            this.RegistrationDetail = registrationDetail;
        }
    }
}

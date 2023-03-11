using VirtualEducation.DDD.Domain.CommonsDDD;

namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Student
{
    public class StudentID : Identity
    {
        //constructor
        public StudentID(Guid id) : base(id) { }


        //create method
        public static StudentID Of(Guid id)
        {
            return new StudentID(id);
        }




    }
}

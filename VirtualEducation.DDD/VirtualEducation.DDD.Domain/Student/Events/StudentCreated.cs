using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class StudentCreated : DomainEvent
    {

        public string StudentID { get; init; }


        public StudentCreated(string studentID) : base("estudiante.creado")
        {
            StudentID = studentID;
        }
    }
}

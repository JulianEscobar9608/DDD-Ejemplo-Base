using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class PersonalDataAdded : DomainEvent
    {

        public PersonalData PersonalData { get; set; }

        public PersonalDataAdded(PersonalData personalData) : base("datosPersonales.agregados")
        {

            PersonalData = personalData;
        }
    }
}

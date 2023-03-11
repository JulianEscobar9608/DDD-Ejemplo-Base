using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.CommonsDDD;
using VirtualEducation.DDD.Domain.Student.Events;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class StudentChangeApply
    {

        public Student CreateAggregate(List<DomainEvent> ev,StudentID id)
        {
            Student student =  new Student(id); 
            ev.ForEach(evento =>
            {
                switch (evento)
                {
                    case PersonalDataAdded personalDataAdded:
                        student.SetPersonalDataAggregate(personalDataAdded.PersonalData);
                        break;

                    case AccountDetailAdded accountDetailAdded:
                        student.Account.SetAccountDetail(accountDetailAdded.AccountDetail);
                        break;

                    case AccountAdded accountAdded:
                        student.SetAccountAggregate(accountAdded.Account);
                        break;
                }

            });
            return student;
        }
       
    }
}

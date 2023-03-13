using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualEducation.DDD.Domain.Student.Commands
{
    public class AddAccountCommand
    {
        public AddAccountCommand(string studentId, string username, string personalMail, string institutionalMail)
        {
            StudentId = studentId;
            Username = username;
            PersonalMail = personalMail;
            InstitutionalMail = institutionalMail;
        }

        public string StudentId { get; init; }

        public string Username { get; init; }

        public string PersonalMail { get; init; }

        public string InstitutionalMail { get; init; }
    }
}

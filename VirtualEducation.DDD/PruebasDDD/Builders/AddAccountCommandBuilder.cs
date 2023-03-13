using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Student.Commands;

namespace PruebasDDD.Builders
{
    public class AddAccountCommandBuilder
    {
        private string studentId;
        private string username;
        private string personalMail;
        private string institutionalMail;

        public AddAccountCommandBuilder WithStudentId(string studentId)
        {
            this.studentId = studentId;
            return this;
        }

        public AddAccountCommandBuilder WithUsername(string username)
        {
            this.username = username;
            return this;
        }

        public AddAccountCommandBuilder WithPersonalMail(string personalMail)
        {
            this.personalMail = personalMail;
            return this;
        }

        public AddAccountCommandBuilder WithInstitutionalMail(string institutionalMail)
        {
            this.institutionalMail = institutionalMail;
            return this;
        }

        public AddAccountCommand Build()
        {
            return new AddAccountCommand(studentId, username, personalMail, institutionalMail);
        }
    }
}

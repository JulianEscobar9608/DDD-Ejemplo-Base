using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Student.Commands;

namespace UseCaseTests.Builders
{
    public class CreateStudentCommandBuilder
    {
        private string _name;
        private string _lastName;
        private int _age;
        private string _gender;

        public CreateStudentCommandBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CreateStudentCommandBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public CreateStudentCommandBuilder WithAge(int age)
        {
            _age = age;
            return this;
        }

        public CreateStudentCommandBuilder WithGender(string gender)
        {
            _gender = gender;
            return this;
        }

        public CreateStudentCommand Build()
        {
            return new CreateStudentCommand(_name, _lastName, _age, _gender);
        }

    }
}

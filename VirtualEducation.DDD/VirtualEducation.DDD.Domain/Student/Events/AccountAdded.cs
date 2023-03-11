using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Student.Entities;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class AccountAdded : DomainEvent
    {
        public Account Account { get; set; } 

        public AccountAdded(Account Account) : base("cuenta.agregada")
        {
            this.Account = Account;
        }
    }
}

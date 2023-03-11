using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class AccountDetailAdded : DomainEvent
    {

        public AccountDetail AccountDetail { get; set; }

        public AccountDetailAdded(AccountDetail accountDetail) : base("detalledecuenta.agregado")
        {
            AccountDetail= accountDetail;
        }
    }
}

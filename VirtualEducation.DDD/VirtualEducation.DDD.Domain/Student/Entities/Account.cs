﻿using VirtualEducation.DDD.Domain.CommonsDDD;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class Account : Entity<AccountID>
    {
        //variables
        public AccountDetail AccountDetail { get; private set; }
        public Email Email { get; private set; }
        public Permissions Permissions { get; private set; }
        //constructor
        public Account(AccountID id) : base(id)
        {
            
        }
        //set method for account detail
        public void SetAccountDetail(AccountDetail accountDetail)
        {
            this.AccountDetail = accountDetail;
        }
        //set method for email
        public void SetEmail(Email email)
        {
            this.Email = email;
        }
        //set method for permissions
        public void SetPermissions(Permissions permissions)
        {
            this.Permissions = permissions;
        }
    }
}

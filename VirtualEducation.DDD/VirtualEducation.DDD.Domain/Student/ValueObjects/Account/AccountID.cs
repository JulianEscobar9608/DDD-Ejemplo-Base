using VirtualEducation.DDD.Domain.CommonsDDD;

namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Account
{
    public class AccountID : Identity
    {

        internal AccountID(Guid id) : base(id)
        {

        }
        //create method
        public static AccountID Of(Guid id)
        {
            return new AccountID(id);
        }

    }
}

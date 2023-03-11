using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Repositories
{
    public interface IAccountRepository
    {
        Task AddAccount(Account account);
        Task UpdateAccountDetail(AccountID accountID, AccountDetail accountDetail);
    }
}

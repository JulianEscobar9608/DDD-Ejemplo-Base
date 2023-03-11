using VirtualEducation.DDD.Domain.Teacher.Entities;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Repositories
{
    public interface IAccountRepository
    {
        Task AddAccount(Account account);
        Task UpdateEmail(AccountID accountID, Email email);
    }
}

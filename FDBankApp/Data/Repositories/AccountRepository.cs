using FDBankApp.Data.Context;
using FDBankApp.Data.Entities;
using FDBankApp.Data.Interfaces;

namespace FDBankApp.Data.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext context)
        {
            _context = context;
        }
        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}

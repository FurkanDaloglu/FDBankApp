using FDBankApp.Data.Entities;

namespace FDBankApp.Data.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
    }
}

using FDBankApp.Data.Entities;
using FDBankApp.Models;

namespace FDBankApp.Mapping
{
    public class AccountMapper:IAccountMapper
    {
        public Account Map(AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            };
        }
    }
}

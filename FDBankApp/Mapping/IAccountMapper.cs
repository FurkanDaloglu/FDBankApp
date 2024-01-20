using FDBankApp.Data.Entities;
using FDBankApp.Models;

namespace FDBankApp.Mapping
{
    public interface IAccountMapper
    {
        public Account Map(AccountCreateModel model);

    }
}

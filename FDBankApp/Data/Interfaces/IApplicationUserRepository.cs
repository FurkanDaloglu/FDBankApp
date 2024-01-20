using FDBankApp.Data.Entities;

namespace FDBankApp.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
    }
}

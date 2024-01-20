using FDBankApp.Data.Context;
using FDBankApp.Data.Entities;
using FDBankApp.Data.Interfaces;

namespace FDBankApp.Data.Repositories
{
    public class ApplicationUserRepository: IApplicationUserRepository
    {
        private readonly BankContext _context;

        public ApplicationUserRepository(BankContext context)
        {
            _context = context;
        }
        public List<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }
        public ApplicationUser GetById(int id)
        {
            return _context.ApplicationUsers.SingleOrDefault(x => x.Id == id);
        }
    }
}

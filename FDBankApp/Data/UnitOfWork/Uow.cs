using FDBankApp.Data.Context;
using FDBankApp.Data.Interfaces;
using FDBankApp.Data.Repositories;
using NuGet.Packaging.Core;

namespace FDBankApp.Data.UnitOfWork
{
    public class Uow:IUow
    {
        private readonly BankContext _context;

        public Uow(BankContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> GetRepository<T>() where T:class, new()
        {
            return new GenericRepository<T>(_context);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

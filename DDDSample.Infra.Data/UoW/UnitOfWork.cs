using DDDSample.Domain.Interfaces;
using DDDSample.Infra.Data.Context;

namespace DDDSample.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackEndTestContext _context;

        public UnitOfWork(BackEndTestContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

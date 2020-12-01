using System.Linq;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.Models;
using DDDSample.Infra.Data.Context;

namespace DDDSample.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BackEndTestContext context) : base(context)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}

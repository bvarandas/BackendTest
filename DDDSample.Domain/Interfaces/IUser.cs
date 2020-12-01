using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
    }
}

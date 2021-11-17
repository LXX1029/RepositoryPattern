using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
    }
}

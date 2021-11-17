using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
  public  interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }
        Task<int> SaveAsync();
    }
}

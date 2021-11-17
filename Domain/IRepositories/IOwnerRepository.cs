using Domain.Entities;
using Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        Task<PagedList<Owner>> GetOwnersAsync(OwnerParameters ownerParameters);
        Task<Owner> GetOwnerByIdAsync(Guid ownerId);
        Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId);
        Task<bool> IsExistOwnerName(Owner owner);
        Task<bool> IsExistOwner(Owner owner);
    }
}

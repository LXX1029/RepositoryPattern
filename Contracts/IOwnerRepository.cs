using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOwnerRepository
    {
        Task<PagedList<Owner>> GetOwners(OwnerParameters ownerParameters);
        Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(Guid ownerId);
        Task<Owner> GetOwnerWithDetails(Guid ownerId);
        bool IsExistOwnerName(Owner owner);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}

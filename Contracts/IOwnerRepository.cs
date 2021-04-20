using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities;

namespace Contracts
{
    public interface IOwnerRepository
    {
        PagedList<Owner> GetOwners(OwnerParameters ownerParameters);
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);
        Owner GetOwnerWithDetails(Guid ownerId);
        bool IsExistOwnerName(Owner owner);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}

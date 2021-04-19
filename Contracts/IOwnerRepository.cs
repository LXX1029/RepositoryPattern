using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);
        Owner GetOwnerWithDetails(Guid ownerId);
        bool IsExistOwnerName(Owner owner);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}

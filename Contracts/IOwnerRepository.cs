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
    }
}

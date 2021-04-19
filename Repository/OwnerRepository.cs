using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                    .Include(i => i.Accounts)
                    .OrderBy(o => o.Name)
                    .ToList();
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(o => o.OwnerId.Equals(ownerId)).FirstOrDefault();
        }
    }
}

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
        private readonly RepositoryContext _repositoryContext;

        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
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

        public Owner GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(o => o.OwnerId.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefault();
        }

        public bool IsExistOwnerName(Owner owner)
        {
            return this._repositoryContext.Set<Owner>().Any(m => m.OwnerId != owner.OwnerId && m.Name == owner.Name);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }
    }
}

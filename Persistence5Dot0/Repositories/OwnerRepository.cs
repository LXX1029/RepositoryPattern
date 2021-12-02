using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence5Dot0.Repositories
{
    internal class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        private readonly RepositoryContext _dbContext;

        public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            this._dbContext = repositoryContext;
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid ownerId)
        {
            return await this._dbContext.Owners.SingleOrDefaultAsync(x => x.OwnerId.Equals(ownerId));
        }

        public Task<IQueryable<Owner>> GetOwnersAsync()
        {
            return Task.FromResult(FindAll());
        }
        public Task<IQueryable<Owner>> GetOwnersByConditiionAsync(Expression<Func<Owner, bool>> expression)
        {
            return Task.FromResult(FindByCondition(expression));
        }

        public async Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId)
        {
            return await this._dbContext.Owners.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.OwnerId.Equals(ownerId));
        }



        public async Task<bool> IsExistOwnerName(Owner owner)
        {
            return await this._dbContext.Owners.AnyAsync(x => x.Name.Equals(owner.Name) && x.OwnerId != owner.OwnerId);
        }

        public async Task<bool> IsExistOwner(Owner owner)
        {
            return await this._dbContext.Owners.AnyAsync(x => x.OwnerId == owner.OwnerId);
        }


    }
}

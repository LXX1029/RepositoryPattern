using Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        Task<IQueryable<Owner>> GetOwnersAsync();
        Task<IQueryable<Owner>> GetOwnersByConditiionAsync(Expression<Func<Owner, bool>> expression);
        Task<Owner> GetOwnerByIdAsync(Guid ownerId);
        Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId);
        Task<bool> IsExistOwnerName(Owner owner);
        Task<bool> IsExistOwner(Owner owner);
    }
}

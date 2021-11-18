using Contracts5Dot0;
using Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IOwnerService
    {
        Task<PagedList<OwnerDto>> GetOwners(OwnerParameters ownerParameters);
        Task<OwnerDto> GetOwnerById(Guid ownerId);
        Task<OwnerWithAccountDto> GetOwnerWithDetails(Guid ownerId);
        Task<bool> IsExistOwnerName(OwnerDto ownerDto);
        Task<bool> IsExistOwner(OwnerDto ownerDto);
        Task<OwnerDto> CreateOwnerAsync(OwnerForCreationDto ownerDto);
        Task<OwnerDto> UpdateOwnerAsync(OwnerDto ownerDto);
        Task DeleteOwnerAsync(OwnerDto ownerDto);
    }
}

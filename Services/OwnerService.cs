using AutoMapper;
using Contracts5Dot0;
using Domain.Entities;
using Domain.IRepositories;
using Mapster;
using Models.QueryModel;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class OwnerService : IOwnerService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public OwnerService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            this._mapper = mapper;
        }

        public async Task<OwnerDto> CreateOwnerAsync(OwnerForCreationDto ownerDto)
        {
            var owner = ownerDto.Adapt<Owner>();
            this._repositoryWrapper.Owner.Insert(owner);
            await this._repositoryWrapper.SaveAsync();
            return owner.Adapt<OwnerDto>();
        }

        public async Task DeleteOwnerAsync(OwnerDto ownerDto)
        {
            var owner = ownerDto.Adapt<Owner>();
            this._repositoryWrapper.Owner.Remove(owner);
            await this._repositoryWrapper.SaveAsync();
        }

        public async Task<OwnerDto> UpdateOwnerAsync(OwnerDto ownerDto)
        {
            var owner = ownerDto.Adapt<Owner>();
            this._repositoryWrapper.Owner.Update(owner);
            await this._repositoryWrapper.SaveAsync();
            return owner.Adapt<OwnerDto>();
        }

        public async Task<OwnerDto> GetOwnerById(Guid ownerId)
        {
            var owner = await this._repositoryWrapper.Owner.GetOwnerByIdAsync(ownerId);
            var ownerDto = owner.Adapt<OwnerDto>();
            return ownerDto;
        }


        public async Task<PagedList<OwnerDto>> GetOwners(OwnerParameters ownerParameters)
        {
            //if (!string.IsNullOrEmpty(ownerParameters.Name))
            //    owners = owners.Where(x => x.Name.Contains(ownerParameters.Name));
            Expression<Func<Owner, bool>> expression = (x) => true;
            if (!string.IsNullOrEmpty(ownerParameters.Name))
                expression = (x) => x.Name.Contains(ownerParameters.Name);

            var str = expression.Body.ToString();

            var owners = await this._repositoryWrapper.Owner.GetOwnersByConditiionAsync(expression);

            var ownerPageList = PagedList<Owner>.ToPagedList(owners, ownerParameters.CurrentPage, ownerParameters.PageSize);
            var ownerDtos = ownerPageList.Adapt<PagedList<OwnerDto>>();
            ownerDtos.CurrentPageIndex = ownerPageList.CurrentPageIndex;
            ownerDtos.TotalCount = ownerPageList.TotalCount;
            ownerDtos.TotalPages = ownerPageList.TotalPages;
            ownerDtos.PageSize = ownerPageList.PageSize;
            ownerDtos.NextPageIndex = ownerPageList.NextPageIndex;
            ownerDtos.PreviousPageIndex = ownerPageList.PreviousPageIndex;
            return ownerDtos;
        }

        public async Task<OwnerWithAccountDto> GetOwnerWithDetails(Guid ownerId)
        {
            var owner = await this._repositoryWrapper.Owner.GetOwnerWithDetailsAsync(ownerId);
            return owner.Adapt<OwnerWithAccountDto>();
        }

        public async Task<bool> IsExistOwnerName(OwnerDto ownerDto)
        {
            var owner = ownerDto.Adapt<Owner>();
            return await this._repositoryWrapper.Owner.IsExistOwnerName(owner);

        }

        public async Task<bool> IsExistOwner(OwnerDto ownerDto)
        {
            var owner = ownerDto.Adapt<Owner>();
            return await this._repositoryWrapper.Owner.IsExistOwner(owner);
        }
    }
}

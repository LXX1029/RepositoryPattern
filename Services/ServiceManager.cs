using AutoMapper;
using Domain.IRepositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<IOwnerService> _ownerService;
        public ServiceManager(IRepositoryWrapper repositoryWrapper,IMapper mapper)
        {
            _ownerService = new Lazy<IOwnerService>(() => new OwnerService(repositoryWrapper,mapper));
        }
        public IOwnerService OwnerService => _ownerService.Value;
    }
}

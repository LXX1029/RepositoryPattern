using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence5Dot0.Repositories
{
    public sealed class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _dbContext;
        private Lazy<IOwnerRepository> _lazyOwnerRepository;
        public RepositoryWrapper(RepositoryContext context)
        {
            this._dbContext = context;
            _lazyOwnerRepository = new Lazy<IOwnerRepository>(() => new OwnerRepository(context));
        }
        public IOwnerRepository Owner => _lazyOwnerRepository.Value;

        public IAccountRepository Account => throw new NotImplementedException();

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

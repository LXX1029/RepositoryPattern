using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext RepositoryContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null)
                    _owner = new OwnerRepository(RepositoryContext);
                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                    _account = new AccountRepository(RepositoryContext);
                return _account;
            }
        }

        public async Task SaveAsync()
        {
            //this.RepositoryContext.SaveChanges();
            await this.RepositoryContext.SaveChangesAsync();
        }
    }
}

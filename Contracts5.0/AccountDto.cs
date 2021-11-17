using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts5Dot0
{
    public class AccountDto
    {
        public Guid AccountId { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountType { get; set; }
    }
}

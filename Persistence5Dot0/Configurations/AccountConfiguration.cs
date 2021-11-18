using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence5Dot0.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account { OwnerId = Guid.Parse("EFD9B8E4-B759-434D-BDA1-21D268531FB3"), AccountId = Guid.NewGuid(), AccountType = "网易" },
                new Account { OwnerId = Guid.Parse("EFD9B8E4-B759-434D-BDA1-21D268531FB3"), AccountId = Guid.NewGuid(), AccountType = "腾讯" },
                new Account { OwnerId = Guid.Parse("E8253D32-603A-45C3-8D7B-48B2971B20E5"), AccountId = Guid.NewGuid(), AccountType = "京东" },
                new Account { OwnerId = Guid.Parse("54AEB677-A1FC-479F-B095-98476A027E6D"), AccountId = Guid.NewGuid(), AccountType = "CSDN" }
             );
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence5Dot0.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            //builder.Property(x=>x.Name).IsRequired().HasMaxLength(200).ValueGeneratedOnAdd();

            // 配置Owner类属性
            builder.HasData(
                new Owner { OwnerId = Guid.Parse("EFD9B8E4-B759-434D-BDA1-21D268531FB3"), Name = "Name1", Address = "河南", DateOfBirth = DateTime.Parse("1999-03-02") },
                new Owner { OwnerId = Guid.Parse("BE24D142-C750-4CEE-90EB-2B99D942B33C"), Name = "Name2", Address = "河北", DateOfBirth = DateTime.Parse("1990-03-02") },
                new Owner { OwnerId = Guid.Parse("E8253D32-603A-45C3-8D7B-48B2971B20E5"), Name = "Name3", Address = "湖南", DateOfBirth = DateTime.Parse("1992-03-02") },
                new Owner { OwnerId = Guid.Parse("54AEB677-A1FC-479F-B095-98476A027E6D"), Name = "Name4", Address = "湖北", DateOfBirth = DateTime.Parse("1991-03-02") }
             );
            builder.HasMany<Account>(x => x.Accounts)
                .WithOne()
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contracts5Dot0
{
    public class OwnerDto
    {
        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public ICollection<AccountDto> Accounts { get; set; }
    }
    public class OwnerForCreationDto
    {
        [Required(ErrorMessage = "Name 不能为空")]
        [StringLength(60, ErrorMessage = "Name长度不能大于60")]
        public string Name { get; set; }

        [Required(ErrorMessage = "DateOfBirth 不能为空")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address 不能为空")]
        [StringLength(100, ErrorMessage = "Address长度不能大于60")]
        public string Address { get; set; }
    }

    public class OwnerForUpdateDto
    {
        public Guid OwnerId { get; set; }
        [Required(ErrorMessage = "Name 不能为空")]
        [StringLength(60, ErrorMessage = "Name长度不能大于60")]
        public string Name { get; set; }

        [Required(ErrorMessage = "DateOfBirth 不能为空")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address 不能为空")]
        [StringLength(100, ErrorMessage = "Address长度不能大于60")]
        public string Address { get; set; }
    }
}

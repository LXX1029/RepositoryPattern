using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        public Guid OwnerId { get; set; }

        [Required(ErrorMessage = "Name 不能为空")]
        [StringLength(60, ErrorMessage = "Name长度不能大于60")]
        public string Name { get; set; }

        [Required(ErrorMessage = "DateOfBirth 不能为空")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address 不能为空")]
        [StringLength(100, ErrorMessage = "Address长度不能大于60")]
        public string Address { get; set; }

        public ICollection<Account> Accounts { get; set; }

    }
}

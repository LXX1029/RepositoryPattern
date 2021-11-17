using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("Account")]
    public class Account
    {
        public Guid AccountId { get; set; }
        [Required(ErrorMessage = "DateCreated 不能为空")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "AccountType 不能为空")]
        public string AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}

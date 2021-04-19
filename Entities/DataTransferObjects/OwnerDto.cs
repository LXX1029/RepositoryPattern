using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class OwnerDto
    {
        public Guid OwnerId { get; set; }


        public string Name { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }


    }
}

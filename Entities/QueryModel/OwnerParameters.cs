using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class OwnerParameters : QueryStringParameters
    {
        public int? MinYearOfBirth { get; set; }
        public int? MaxYearOfBirth { get; set; } = DateTime.Now.Year;
        public bool ValidYearRang => MaxYearOfBirth > MinYearOfBirth;

        public string Name { get; set; }

    }
}

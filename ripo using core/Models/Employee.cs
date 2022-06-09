using System;
using System.Collections.Generic;

namespace ripo_using_core.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
    }
}

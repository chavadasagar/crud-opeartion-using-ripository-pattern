using System;
using System.Collections.Generic;

namespace ripo_using_core.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public int Age { get; set; }
        public string? Comments { get; set; }
        public string Email { get; set; } = null!;
        public int Gender { get; set; }
    }
}

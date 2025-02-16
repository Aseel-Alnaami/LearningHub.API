using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Student
    {
        public Student()
        {
            Logins = new HashSet<Login>();
            Stdcourses = new HashSet<Stdcourse>();
        }

        public decimal Studentid { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime? Dateofbirth { get; set; }
        public decimal? Marks { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Stdcourse> Stdcourses { get; set; }
    }
}

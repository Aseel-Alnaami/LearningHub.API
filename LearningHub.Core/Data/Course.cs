using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Course
    {
        public Course()
        {
            Stdcourses = new HashSet<Stdcourse>();
        }

        public decimal Courseid { get; set; }
        public string Coursename { get; set; } = null!;
        public decimal? Categoryid { get; set; }
        public string? Imagename { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public decimal? Price { get; set; }

        public virtual Categoryy? Category { get; set; }
        public virtual ICollection<Stdcourse> Stdcourses { get; set; }
    }
}

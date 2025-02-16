using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Categoryy
    {
        public Categoryy()
        {
            Courses = new HashSet<Course>();
        }

        public decimal Categoryid { get; set; }
        public string Categoryname { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}

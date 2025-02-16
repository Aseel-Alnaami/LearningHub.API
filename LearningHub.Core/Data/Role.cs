using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public decimal Idrol { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}

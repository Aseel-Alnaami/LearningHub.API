using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Role1
    {
        public Role1()
        {
            Logins = new HashSet<Login>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; } = null!;

        public virtual ICollection<Login> Logins { get; set; }
    }
}

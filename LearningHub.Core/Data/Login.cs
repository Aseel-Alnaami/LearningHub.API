using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Login
    {
        public decimal Loginid { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? Roleid { get; set; }
        public decimal? Studentid { get; set; }

        public virtual Role1? Role { get; set; }
        public virtual Student? Student { get; set; }
    }
}

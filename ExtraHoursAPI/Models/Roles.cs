using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExtraHoursAPI.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Options = new HashSet<Options>();
            Users = new HashSet<Users>();
        }

        public int IdRol { get; set; }
        public string RolName { get; set; }

        public virtual ICollection<Options> Options { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}

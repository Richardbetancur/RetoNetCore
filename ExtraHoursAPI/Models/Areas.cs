using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExtraHoursAPI.Models
{
    public partial class Areas
    {
        public Areas()
        {
            UsersxAreas = new HashSet<UsersxAreas>();
        }

        public int IdArea { get; set; }
        public string AreaName { get; set; }
        public string Status { get; set; }

        public virtual ICollection<UsersxAreas> UsersxAreas { get; set; }
    }
}

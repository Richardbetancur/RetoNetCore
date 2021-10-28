using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExtraHoursAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            ApplicationsColaboratorNavigation = new HashSet<Applications>();
            ApplicationsLeaderNavigation = new HashSet<Applications>();
            ExtraHours = new HashSet<ExtraHours>();
            UsersxAreas = new HashSet<UsersxAreas>();
        }

        public int IdUser { get; set; }
        public int IdRol { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        public virtual ICollection<Applications> ApplicationsColaboratorNavigation { get; set; }
        public virtual ICollection<Applications> ApplicationsLeaderNavigation { get; set; }
        public virtual ICollection<ExtraHours> ExtraHours { get; set; }
        public virtual ICollection<UsersxAreas> UsersxAreas { get; set; }
    }
}

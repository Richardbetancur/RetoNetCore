using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExtraHoursAPI.Models
{
    public partial class UsersxAreas
    {
        public int Id { get; set; }
        public int IdArea { get; set; }
        public int IdUser { get; set; }
        public bool? Lider { get; set; }

        public virtual Areas IdAreaNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}

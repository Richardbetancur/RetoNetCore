using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExtraHoursAPI.Models
{
    public partial class Options
    {
        public int IdOption { get; set; }
        public int? IdRol { get; set; }
        public string OptionName { get; set; }
        public string UrlOption { get; set; }
        public int Position { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
    }
}

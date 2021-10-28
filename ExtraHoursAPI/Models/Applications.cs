using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExtraHoursAPI.Models
{
    public partial class Applications
    {
        public int IdApplication { get; set; }
        public int? Leader { get; set; }
        public int? Colaborator { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Reason { get; set; }
        public bool? ApplicationStatus { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string Comments { get; set; }
        public DateTime? CompensationStar { get; set; }
        public DateTime? CompensationEnd { get; set; }

        public virtual Users ColaboratorNavigation { get; set; }
        public virtual Users LeaderNavigation { get; set; }
    }
}

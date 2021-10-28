using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExtraHoursAPI.Models
{
    public partial class ExtraHours
    {
        public int Id { get; set; }
        public int? UserName { get; set; }
        public DateTime RegisterDate { get; set; }
        public TimeSpan StarTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Quatity { get; set; }
        public int? Area { get; set; }
        public string Descripcion { get; set; }
        public bool? Compensa { get; set; }

        public virtual Users UserNameNavigation { get; set; }
    }
}

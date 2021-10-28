using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraHoursAPI.Models.Response
{
    public class Response
    {
        public int Exito { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}

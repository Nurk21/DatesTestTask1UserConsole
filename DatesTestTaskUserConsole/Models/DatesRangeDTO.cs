using System;
using System.Collections.Generic;
using System.Text;

namespace DatesTestTaskUserConsole.Models
{
    public class DatesRangeDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DatesRangeDTO(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }

    }
}

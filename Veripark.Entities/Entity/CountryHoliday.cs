using System;
using System.Collections.Generic;

namespace Veripark.Entities.Models
{
    public partial class CountryHoliday
    {
        public int ID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<System.DateTime> Holiday { get; set; }
        public virtual Country Country { get; set; }
    }
}

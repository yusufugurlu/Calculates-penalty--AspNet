using System;
using System.Collections.Generic;

namespace Veripark.Entities.Models
{
    public partial class Country
    {
        public Country()
        {
            this.CountryHolidays = new List<CountryHoliday>();
        }

        public int ID { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<CountryHoliday> CountryHolidays { get; set; }
    }
}

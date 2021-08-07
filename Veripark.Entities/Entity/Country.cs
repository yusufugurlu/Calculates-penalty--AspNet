using System;
using System.Collections.Generic;
using Veripark.Entities.Entity.Abstract;

namespace Veripark.Entities.Models
{
    public partial class Country: IEntity
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

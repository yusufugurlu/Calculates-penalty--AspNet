using System;
using System.Collections.Generic;
using Veripark.Entities.Entity.Abstract;

namespace Veripark.Entities.Models
{
    public partial class CountryHoliday: IEntity
    {
        public int ID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<System.DateTime> Holiday { get; set; }
        public virtual Country Country { get; set; }
    }
}

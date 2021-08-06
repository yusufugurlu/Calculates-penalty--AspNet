using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veripark.Entities.Models;

namespace Veripark.Business.Abstract
{
   public interface ICountryHolidayService
    {
        List<CountryHoliday> GetList();
        List<CountryHoliday> GetListWithCountry();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veripark.Entities.Models;

namespace Veripark.DataAccess.Abstract
{
   public interface ICountryHolidayDal
    {
        List<CountryHoliday> GetAll();
        List<CountryHoliday> GetAllWithCountry();
        CountryHoliday GetByID(int id);
        bool Insert(CountryHoliday book);
        bool Delete(int id);
    }
}

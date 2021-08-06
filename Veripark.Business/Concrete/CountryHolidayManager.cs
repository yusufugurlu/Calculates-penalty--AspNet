using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veripark.Business.Abstract;
using Veripark.DataAccess.Abstract;
using Veripark.Entities.Models;

namespace Veripark.Business.Concrete
{
    public class CountryHolidayManager : ICountryHolidayService
    {
        private ICountryHolidayDal _ICountryWeekendDal;

        public CountryHolidayManager(ICountryHolidayDal _ICountryWeekendDal)
        {
            this._ICountryWeekendDal = _ICountryWeekendDal;
        }

        public List<CountryHoliday> GetList()
        {
            return _ICountryWeekendDal.GetAll();
        }

        public List<CountryHoliday> GetListWithCountry()
        {
            return _ICountryWeekendDal.GetAllWithCountry();
        }
    }
}

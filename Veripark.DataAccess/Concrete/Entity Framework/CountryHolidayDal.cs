using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veripark.DataAccess.Abstract;
using Veripark.Entities.Models;

namespace Veripark.DataAccess.Concrete.Entity_Framework
{
    public class CountryHolidayDal : ICountryHolidayDal
    {
        private VeriParkDBContext veriParkDBContext;
        public CountryHolidayDal()
        {
            veriParkDBContext = new VeriParkDBContext();
        }

        public bool Delete(int id)
        {
            var entity = veriParkDBContext.CountryHolidays.First(x => x.ID == id);
            if (entity != null)
            {
                veriParkDBContext.CountryHolidays.Remove(entity);
                if (veriParkDBContext.SaveChanges() > 0)
                    return true;
                return false;
            }
            else
            {
                return false;
            }
        }

        public List<CountryHoliday> GetAll()
        {
            return veriParkDBContext.CountryHolidays.ToList();
        }

        public List<CountryHoliday> GetAllWithCountry()
        {
            return veriParkDBContext.CountryHolidays.Include("Country").ToList();
        }

        public CountryHoliday GetByID(int id)
        {
            return veriParkDBContext.CountryHolidays.First(x => x.ID == id);
        }

        public bool Insert(CountryHoliday book)
        {
            veriParkDBContext.CountryHolidays.Add(book);
            if (veriParkDBContext.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}

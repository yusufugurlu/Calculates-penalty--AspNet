using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veripark.DataAccess.Abstract;
using Veripark.Entities.Models;

namespace Veripark.DataAccess.Concrete.Entity_Framework
{
    public class CountryDal : ICountryDal
    {
        private VeriParkDBContext veriParkDBContext;
        public CountryDal()
        {
            veriParkDBContext = new VeriParkDBContext();
        }

        public bool Delete(int id)
        {
            var entity = veriParkDBContext.Countries.First(x => x.ID == id);
            if (entity != null)
            {
                veriParkDBContext.Countries.Remove(entity);
                if (veriParkDBContext.SaveChanges() > 0)
                    return true;
                return false;
            }
            else
            {
                return false;
            }
        }

        public List<Country> GetAll()
        {
            return veriParkDBContext.Countries.ToList();
        }

        public Country GetByID(int id)
        {
            return veriParkDBContext.Countries.First(x => x.ID == id);
        }

        public bool Insert(Country book)
        {
            veriParkDBContext.Countries.Add(book);
            if (veriParkDBContext.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Update(Country book)
        {
            var entity = veriParkDBContext.Countries.First(x => x.ID == book.ID);
            if (entity != null)
            {
                entity.CountryName = book.CountryName;
                if (veriParkDBContext.SaveChanges() > 0)
                    return true;
                return false;

            }
            else
            {
                return false;
            }
        }
    }
}

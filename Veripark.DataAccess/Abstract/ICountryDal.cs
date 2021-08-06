using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veripark.Entities.Models;

namespace Veripark.DataAccess.Abstract
{
   public interface ICountryDal
    {
        List<Country> GetAll();
        Country GetByID(int id);
        bool Insert(Country book);
        bool Update(Country book);
        bool Delete(int id);
    }
}

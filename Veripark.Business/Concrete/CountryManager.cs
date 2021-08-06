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
    public class CountryManager : ICountryService
    {
        private ICountryDal _ICountryDal;

        public CountryManager(ICountryDal _ICountryDal)
        {
            this._ICountryDal = _ICountryDal;
        }

        public List<Country> GetList()
        {
            return _ICountryDal.GetAll();
        }
    }
}

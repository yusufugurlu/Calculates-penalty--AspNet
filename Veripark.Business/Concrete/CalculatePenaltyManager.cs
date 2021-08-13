using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veripark.Business.Abstract;
using Veripark.Core.Utilits;
using Veripark.DataAccess.Concrete.Entity_Framework;
using Veripark.Entities.Enum;
using Veripark.Entities.Models;
using Veripark.Entities.Request;
using Veripark.Entities.Response;

namespace Veripark.Business.Concrete
{
    public class CalculatePenaltyManager : ICalculatePenalty
    {

        private CountryHolidayDal _ICountryHolidayDal;
        public CalculatePenaltyManager()
        {
            _ICountryHolidayDal = new CountryHolidayDal();
        }


        public rsCalculatePenalty CalculatePenalty(rqCalculatePenalty _rqCalculatePenalty)
        {
            TimeSpan DayDifference = _rqCalculatePenalty.dateReturn.Subtract(_rqCalculatePenalty.dateCheck);
            string[] splitCountries = null;
            if (_rqCalculatePenalty.countries.IndexOf(",") > 0)
            {
                splitCountries = _rqCalculatePenalty.countries.Split(',');
            }
            else
            {
                splitCountries = new string[] { _rqCalculatePenalty.countries };
            }
            if (DayDifference.TotalDays > 0)
            {
                List<string> lPaymant = new List<string>();
              
                foreach (string countryID in splitCountries)
                {
                    int holiday = 0;
                    List<CountryHoliday> lst = _ICountryHolidayDal.GetAllWithCountry();
                    var tmpList = lst.Where(x => x.Country.ID == int.Parse(countryID)).ToList();
                    string countryName = "";
                    holiday = SetWeekend((enCountry)int.Parse(countryID), DayDifference, _rqCalculatePenalty.dateCheck);

                    if (tmpList.Count > 0)
                    {
                        foreach (var item in tmpList)
                        {
                            if ((_rqCalculatePenalty.dateCheck.Year <= item.Holiday.Value.Year && _rqCalculatePenalty.dateReturn.Year >= item.Holiday.Value.Year) && (_rqCalculatePenalty.dateCheck.Month <= item.Holiday.Value.Month && _rqCalculatePenalty.dateReturn.Month >= item.Holiday.Value.Month) && (_rqCalculatePenalty.dateCheck.Day <= item.Holiday.Value.Day && _rqCalculatePenalty.dateReturn.Day >= item.Holiday.Value.Day))
                            {
                                holiday++;
                            }
                            countryName = item.Country.CountryName;
                        }
                    }

                    int result = ((int)(_rqCalculatePenalty.dateReturn - _rqCalculatePenalty.dateCheck).TotalDays) - holiday;
                    if (isReturnDay(result))
                    {
                        double resultAdd = double.Parse((result - Utilities.Day).ToString()) * Utilities.DayOfMoney;
                        lPaymant.Add("Country: " + countryName + ", TotalDay(s)= "+result.ToString()+" , " + (result - Utilities.Day).ToString() + " Day(s) X " + Utilities.DayOfMoney + "$  = " + resultAdd.ToString() + " $");

                    }
                    else
                    {
                        double resultAdd = double.Parse((result - Utilities.Day).ToString()) * Utilities.DayOfMoney;
                        lPaymant.Add("Country: " + countryName + ", TotalDay(s)="+result.ToString()+" 0 day(s) =  0 $");
                    }
                }

                return new rsCalculatePenalty()
                {
                    isSuccess = true,
                    Data = lPaymant
                };
            }
            else
            {
                return new rsCalculatePenalty()
                {
                    isSuccess = false,
                    Error = "The date the book was returned The date the book was checked must be large."
                };
            }
        }

        private int SetWeekend(enCountry country, TimeSpan diff, DateTime startDate)
        {
            int totalWeekend = 0;
            switch (country)
            {

                case enCountry.Dubai:
                    totalWeekend = GetCountWeekend(diff, startDate);
                    break;
                case enCountry.Turkey:
                case enCountry.ABD:
                case enCountry.England:
                    totalWeekend = GetCountWeekend1(diff, startDate);
                    break;
            }
            return totalWeekend;
        }


        private int GetCountWeekend1(TimeSpan diff, DateTime startDate)
        {
            int total = 0;
            int days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                var testDate = startDate.AddDays(i);
                switch (testDate.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Saturday:
                        total++;
                        break;
                }
            }
            return total;
        }

        private int GetCountWeekend(TimeSpan diff, DateTime startDate)
        {
            int total = 0;
            int days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                var testDate = startDate.AddDays(i);
                switch (testDate.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                    case DayOfWeek.Saturday:
                        total++;
                        break;
                }
            }
            return total;
        }
        #region Eski
        /*
      public rsCalculatePenalty CalculatePenalty(rqCalculatePenalty _rqCalculatePenalty)
      {
          TimeSpan DayDifference = _rqCalculatePenalty.dateReturn.Subtract(_rqCalculatePenalty.dateCheck);
          string[] splitCountries = null;
          if (_rqCalculatePenalty.countries.IndexOf(",") > 0)
          {
              splitCountries = _rqCalculatePenalty.countries.Split(',');
          }
          else
          {
              splitCountries = new string[] { _rqCalculatePenalty.countries };
          }
          if (DayDifference.TotalDays > 0)
          {
              List<string> lPaymant = new List<string>();
              Utilities.Utility();
              foreach (string countryID in splitCountries)
              {
                  int holiday = 0;
                  List<CountryHoliday> lst = _ICountryHolidayService.GetListWithCountry();
                  var tmpList = lst.Where(x => x.Country.ID == int.Parse(countryID)).ToList();
                  string countryName = "";
                  if (tmpList.Count > 0)
                  {
                      foreach (var item in tmpList)
                      {
                          if ((_rqCalculatePenalty.dateCheck.Year <= item.Holiday.Value.Year && _rqCalculatePenalty.dateReturn.Year >= item.Holiday.Value.Year) && (_rqCalculatePenalty.dateCheck.Month <= item.Holiday.Value.Month && _rqCalculatePenalty.dateReturn.Month >= item.Holiday.Value.Month) && (_rqCalculatePenalty.dateCheck.Day <= item.Holiday.Value.Day && _rqCalculatePenalty.dateReturn.Day >= item.Holiday.Value.Day))
                          {
                              holiday++;
                          }
                          countryName = item.Country.CountryName;
                      }
                  }

                  int result = ((int)(_rqCalculatePenalty.dateReturn - _rqCalculatePenalty.dateCheck).TotalDays) - holiday;
                  if (isReturnDay(result))
                  {
                      double resultAdd = double.Parse((result - Utilities.Day).ToString()) * Utilities.DayOfMoney;
                      lPaymant.Add("Country: " + countryName + ", " + (result - Utilities.Day).ToString() + " Day(s) X " + Utilities.DayOfMoney + "$  = " + resultAdd.ToString() + " $");

                  }
                  else
                  {
                      double resultAdd = double.Parse((result - Utilities.Day).ToString()) * Utilities.DayOfMoney;
                      lPaymant.Add("Country: " + countryName + ", 0 day(s) =  0 $");
                  }
              }

              return new rsCalculatePenalty()
              {
                  isSuccess = true,
                  Data = lPaymant
              };



          }
          else
          {
              return new rsCalculatePenalty()
              {
                  isSuccess = false,
                  Error = "Error"
              };
          }
      }
      */ 
        #endregion
        private bool isReturnDay(int result)
        {
            if (result > Utilities.Day) return true;
            return false;
        }
    }
}

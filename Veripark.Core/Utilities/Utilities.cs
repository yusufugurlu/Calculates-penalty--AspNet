using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veripark.Core.Utilits
{
   public class Utilities
    {
        private static Utilities _Utilities;

        public Utilities()
        {
            Day = 10;
            DayOfMoney = 5;
        }

        public static Utilities Utility()
        {
                if (_Utilities == null)
                {
                    _Utilities = new Utilities();
                }
                return _Utilities;
           
        }
        public static int Day { get; set; }
        public static double DayOfMoney { get; set; }
    }
}

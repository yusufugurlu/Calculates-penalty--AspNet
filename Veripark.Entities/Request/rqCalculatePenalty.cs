using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veripark.Entities.Request
{
 public   class rqCalculatePenalty
    {
        public DateTime dateCheck { get; set; }
        public DateTime dateReturn { get; set; }
        public string countries { get; set; }

    }
}

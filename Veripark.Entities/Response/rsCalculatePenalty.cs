using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veripark.Entities.Response
{
   public class rsCalculatePenalty
    {
        public bool isSuccess { get; set; }
        public string Error { get; set; }
        public Object Data { get; set; }
    }
}

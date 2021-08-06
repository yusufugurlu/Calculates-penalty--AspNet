using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veripark.Entities.Request;
using Veripark.Entities.Response;

namespace Veripark.Business.Abstract
{
  public  interface ICalculatePenalty
    {
        rsCalculatePenalty CalculatePenalty(rqCalculatePenalty _rqCalculatePenalty);
    }
}

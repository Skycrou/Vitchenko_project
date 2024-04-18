using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExtraChagreManager.Controllers
{
    public class ExtraChargeManagerController : ApiController
    {
        // GET: api/ExtraChargeManager/CostPrice/percent
        public double GetExtraChargeValue(double CostPrice, double percent)
        {
            double extracharge = (CostPrice / (100 - percent)) * 100;
            var extraCOST = string.Format("{0:0.###}", extracharge);
            double EXTRA = double.Parse(extraCOST);
            return EXTRA;
        }
    }
}

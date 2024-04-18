using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnalysisManager.Controllers
{
    public class AnalysisManagerController : ApiController
    {
        // GET: api/AnalysisManager/sales_ofLastYear/sales_ofNewYear
        public string GetAnalysisSales(double sales_ofLastYear, double sales_ofNewYear)
        {
            string result;
            double res = ((sales_ofNewYear / sales_ofLastYear) - 1) * 100;
            result = string.Format("{0:0.#####}", res + " %");// 3.14
            return result;
        }
    }
}

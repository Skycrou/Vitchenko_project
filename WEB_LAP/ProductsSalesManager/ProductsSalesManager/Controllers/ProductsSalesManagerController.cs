using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsSalesManager.Controllers
{
    public class ProductsSalesManagerController : ApiController
    {
        // GET: api/ProductsSalesManager/GrossProfit/RealizationProduct
        public string GetProfitability(double GrossProfit, double RealizationProduct)
        {
            double percent_value;
            string result;
            double GrossProfitability = GrossProfit / RealizationProduct;
            percent_value = GrossProfitability * 100;
            result = string.Concat(percent_value.ToString(), " %");
            return result;
        }
    }
}

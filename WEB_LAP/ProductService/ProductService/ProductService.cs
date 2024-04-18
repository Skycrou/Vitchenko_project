using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace ProductService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ProductService" в коде и файле конфигурации.
    public class ProductService : IProductService
    {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AnalysisSales
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "AnalysisSales" в коде и файле конфигурации.
    public class AnalysisSales : IAnalysisSales
    {
        public string GetAnalysisSales(double sales_ofLastYear, double sales_ofNewYear)
        {
            string result;
            double res = ((sales_ofNewYear / sales_ofLastYear) - 1) * 100;
            result = string.Format("{0:0.#####}", res + " %");// 3.14
            return result;
        }
    }
}

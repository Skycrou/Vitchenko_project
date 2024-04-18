using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExtraCharge
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ExtraCharge" в коде и файле конфигурации.
    public class ExtraCharge : IExtraCharge
    {
        public double ExtraChargeValue(double CostPrice, double percent)
        {
            double extracharge = (CostPrice / (100 - percent)) * 100;
            var extraCOST = string.Format("{0:0.###}", extracharge);
            double EXTRA = double.Parse(extraCOST);
            return EXTRA;
        }
    }
}

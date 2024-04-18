using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExtraCharge
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IExtraCharge" в коде и файле конфигурации.
    [ServiceContract]
    public interface IExtraCharge
    {
        [OperationContract]
        double ExtraChargeValue(double CostPrice, double percent);
    }
}

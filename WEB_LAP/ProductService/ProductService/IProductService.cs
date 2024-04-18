using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IProductService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        string GetProfitability(double GrossProfit, double RealizationProduct);
    }
}

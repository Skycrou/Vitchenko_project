using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AnalysisSales
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IAnalysisSales" в коде и файле конфигурации.
    [ServiceContract]
    public interface IAnalysisSales
    {
        [OperationContract]
        string GetAnalysisSales(double sales_ofLastYear, double sales_ofNewYear);
    }
}

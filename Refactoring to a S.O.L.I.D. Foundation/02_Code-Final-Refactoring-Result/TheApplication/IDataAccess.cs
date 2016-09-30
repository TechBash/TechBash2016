using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
    public interface IReportDataAccess
    {
        IList<DataElement> GetReportData();
    }

    public interface IDataAccess : IReportDataAccess
    {
        void SaveData(DataElement dataElement);
        IList<DataElement> QueryData(string criteria);
        
    }

}

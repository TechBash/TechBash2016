using System.Collections.Generic;

namespace Demo.SOLID
{
    public interface IGetReportData
    {
        void GetData();
    }

    public interface IQueryData
    {
        IEnumerable<DataItem> DoQuery(string criteria);
    }

    public interface IPersistData
    {
        void SaveData(IEnumerable<DataItem> data);
        void DeleteData(IEnumerable<DataItem> data);
    }

    public interface IDataAccess : IGetReportData, IQueryData, IPersistData
    {
    }
}
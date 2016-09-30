using System;
using System.Collections.Generic;

namespace Demo.SOLID
{
    public class DataAccess : IGetReportData
    {
        public void GetData()
        {
            Console.WriteLine("\nGetting Data from database...");
        }

        //public IEnumerable<DataItem> DoQuery(string criteria)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveData(IEnumerable<DataItem> data)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteData(IEnumerable<DataItem> data)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
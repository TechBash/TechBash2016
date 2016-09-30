using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{

    public class ReportDataAccess : IReportDataAccess
    {
        public IList<DataElement> GetReportData()
        {
            Console.WriteLine("\nGetting Data from database...");
            return new List<DataElement>();
        }

     

    }
}

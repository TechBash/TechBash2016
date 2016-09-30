using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{

    public interface IReportPrinter
    {
        void Print();
    }
    public abstract class ReportPrinter : IReportPrinter
    {
        public abstract void Print();
    }
}
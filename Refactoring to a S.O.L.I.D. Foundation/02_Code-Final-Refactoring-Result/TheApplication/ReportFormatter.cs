using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
    public interface IReportFormatter
    {
        void FormatReport();
    }
    public abstract class ReportFormatter : IReportFormatter
    {
          public abstract void FormatReport();
    }
}
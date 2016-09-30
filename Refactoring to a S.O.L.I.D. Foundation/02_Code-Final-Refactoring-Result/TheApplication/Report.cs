using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{

    public interface IReport
    {
        void Print();
    }
    public abstract class Report : IReport
    {
        public abstract void Print();
    }

}

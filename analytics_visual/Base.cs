using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analytics_visual
{
    abstract public class Base
    {
        abstract public double calculate(List<double> values);
        abstract public double calculate(string[] values, int ValuePos);
    }
}

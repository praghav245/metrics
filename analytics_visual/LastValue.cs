using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analytics_visual
{
    public class LastValue : Base
    {
        override
        public double calculate(List<double> values)
        {
            if (0 < values.Count)
            {
                return values[values.Count - 1];
            }
            return 0;
        }

        override
        public double calculate(string[] values, int ValuePos)
        {
            double last_value;
            if (0 <= ValuePos)
            {
                if (Double.TryParse(values[values.Count() - 1], out last_value))
                {
                    return last_value;
                }
            }
            return 0.0;
        }
    }
}

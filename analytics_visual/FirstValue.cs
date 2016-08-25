using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analytics_visual
{
    public class FirstValue : Base
    {
        override
        public double calculate(List<double> values)
        {
            if (0 < values.Count)
            {
                return values[0];
            }
            return 0;
        }

        override
        public double calculate(string[] values, int ValuePos)
        {
            double first_value;
            if (0 <= ValuePos && ValuePos < values.Count())
            {
                if (Double.TryParse(values[ValuePos], out first_value))
                {
                    return first_value;
                }
            }
            return 0.0;
        }
    }
}

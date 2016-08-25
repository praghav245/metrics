using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analytics_visual
{
    public class MaxValue : Base
    {
        override
        public double calculate(List<double> values)
        {
            if (0 >= values.Count)
            {
                return 0;
            }
            double maximum_value = values[0];

            foreach (double value in values)
            {
                if (value > maximum_value)
                {
                    maximum_value = value;
                }
            }
            return maximum_value;
        }

        override
        public double calculate(string[] values, int ValuePos)
        {
            double maximum_value = 0.0;
            double value;

            if (0 <= ValuePos)
            {
                for (var index = ValuePos; index < values.Length; index++)
                {
                    if (Double.TryParse(values[index], out value))
                    {
                        if (value > maximum_value)
                        {
                            maximum_value = value;
                        }
                    }
                }
            }
            return maximum_value;
        }
    }
}

using System;
using System.Collections.Generic;


namespace analytics_visual
{
    public class MinValue : Base
    {
        override
        public double calculate(List<double> values)
        {
            if (0 >= values.Count)
            {
                return 0;
            }
            double minimum_value = values[0];

            foreach (double value in values)
            {
                if (value < minimum_value)
                {
                    minimum_value = value;
                }
            }
            return minimum_value;
        }

        override
        public double calculate(string[] values, int ValuePos)
        {
            double minimum_value;
            double value;

            if (0 > ValuePos || ValuePos >= values.Length)
            {
                return 0;
            }

            Double.TryParse(values[ValuePos], out minimum_value);

            for (var index = ValuePos; index < values.Length; index++)
            {
                if (Double.TryParse(values[index], out value))
                {
                    if (value < minimum_value)
                    {
                        minimum_value = value;
                    }
                }
            }
            return minimum_value;
        }
    }
}

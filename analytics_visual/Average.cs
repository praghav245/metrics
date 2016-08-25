using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analytics_visual
{
    public class Average : Base
    {
        override
        public double calculate(List<double> values)
        {
            if (0 >= values.Count)
            {
                return 0;
            }
            double total_sum = 0.0;

            foreach (double value in values)
            {
                total_sum += value;
            }
            return (double) (total_sum/values.Count);
        }

        override
        public double calculate(string[] values, int ValuePos)
        {
            double total_sum = 0.0;
            double value;

            if (0 > ValuePos || ValuePos >= values.Length)
            {
                return 0;
            }

            for (var index = ValuePos; index < values.Length; index++)
            {
                if (Double.TryParse(values[index], out value))
                {
                    total_sum += value;
                }
            }
            return (double)(total_sum / (values.Length - ValuePos));
        }
    }
}

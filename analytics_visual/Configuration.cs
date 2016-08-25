using System;
using System.Collections.Generic;

namespace analytics_visual
{
    public class Configuration
    {
        string varName;
        string statistic;
        string period;
        double result;
        List<double> statistic_list;
        public Configuration(string p_varName, string p_statistic, string p_period)
        {
            varName = p_varName;
            statistic = p_statistic;
            period = p_period;
            result = 0.0;
            statistic_list = new List<double>();
        }

        public Configuration() 
        {
            varName = null;
            statistic = null;
            period = null;
            result = 0.0;
            statistic_list = new List<double>();
        }
        public string GetVarName()
        {
            return varName;
        }
        public string GetStatistic()
        {
            return statistic;
        }
        public string GetPeriod()
        {
            return period;
        }

        public void CalculatePeriod(Factory statistics_factory, string[] split_config, TempHeader temp_header)
        {
            try
            {
                double position_result = statistics_factory.plugin_dictionary[period].calculate(split_config, temp_header.GetValuePos());
                statistic_list.Add(position_result);
            } catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return;
            }
        }

        public void CalculateStatistic(Factory statistics_factory)
        {
            try
            {
                result = statistics_factory.plugin_dictionary[statistic].calculate(statistic_list);
            } catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return;
            }
        }

        public void PrintStatistic(System.IO.StreamWriter Output)
        {
            Output.WriteLine(varName + "\t" + statistic + "\t" + result);
        }

        public void CalculateAndPrintStatistic(Factory statistics_factory, System.IO.StreamWriter Output)
        {
            CalculateStatistic(statistics_factory);
            PrintStatistic(Output);
        }
    }
}

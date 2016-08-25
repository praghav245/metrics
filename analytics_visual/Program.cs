using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace analytics_visual
{
    class Program
    {
        /*Read the configuration file*/
        static void ReadConfiguration(string config_path, ref List<Configuration> config_array)
        {
            string line;
            System.IO.StreamReader configuration_reader = null;

            try
            {
                configuration_reader = new System.IO.StreamReader(config_path);
                while (null != (line = configuration_reader.ReadLine()))
                {
                    string[] split_config = line.Split(',');
                    Configuration config_line = new Configuration(split_config[0], split_config[1], split_config[2]);
                    config_array.Add(config_line);
                }
                configuration_reader.Close();
            } catch(Exception e)
            {
                Console.WriteLine("Error reading from {0}. Message = {1}", config_path, e.Message);
                Environment.Exit(0);
            } finally
            {
                if (null != configuration_reader)
                {
                    configuration_reader.Close();
                }
            }            

        }

        /*Parse the TotalTemp file */
        static void parseTotalTempAndApplyStatistic(string totaltemp_path, List<Configuration> config_array, 
                                                    Factory statistics_factory)
        {
            System.IO.StreamReader TotalTemp = null;
            string line;

            try
            {
                TotalTemp = new System.IO.StreamReader(totaltemp_path);
                TempHeader temp_header = new TempHeader(TotalTemp);

                while (null != (line = TotalTemp.ReadLine()))
                {
                    string[] split_config = line.Split('\t');

                    foreach (Configuration config in config_array)
                    {
                        if (split_config.Contains(config.GetVarName()))
                        {
                            config.CalculatePeriod(statistics_factory, split_config, temp_header);
                        }

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading TotalTemp file. Message = {1}", e.Message);
                Environment.Exit(0);

            }
            finally
            {
                if (null != TotalTemp)
                {
                    TotalTemp.Close();
                }
            }
        }

        /*Write to the output file*/
        static void WriteOutput(List<Configuration> config_array, Factory statistics_factory)
        {
            System.IO.StreamWriter Output = null;
            try
            {
                Output = new System.IO.StreamWriter(@"output.txt");

                foreach (Configuration config in config_array)
                {
                    config.CalculateAndPrintStatistic(statistics_factory, Output);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing output. Message = {1}", e.Message);
                Environment.Exit(0);
            }
            finally
            {
                if (null != Output)
                {
                    Output.Close();
                }
            }

        }
        static void Main(string[] args)
        {
            List<Configuration> config_array = new List<Configuration>();
            Factory statistics_factory = Factory.Instance;

            if (args.Length != 2)
            {
                Console.WriteLine("input file paths for TotalTemp and configuration fie need to be provided");
                Environment.Exit(0);
            }

            ReadConfiguration(args[1], ref config_array);

            parseTotalTempAndApplyStatistic(args[0], config_array, statistics_factory);

            WriteOutput(config_array, statistics_factory);
        }
    }
}

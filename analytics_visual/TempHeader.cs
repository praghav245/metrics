using System;

namespace analytics_visual
{
    public class TempHeader
    {
        private int ScenIdPos;
        private int VarNamePos;
        private int ValuePos;

        public void ReadTotalTempHeader(System.IO.StreamReader TotalTemp)
        {
            ScenIdPos = -1;
            VarNamePos = -1;
            ValuePos = -1;

            string header = TotalTemp.ReadLine();
            if (null != header)
            {
                string[] split_header = header.Split('\t');
                try
                {
                    ScenIdPos = Array.IndexOf(split_header, "ScenId");
                    VarNamePos = Array.IndexOf(split_header, "VarName");
                    ValuePos = Array.IndexOf(split_header, "Value000");
                } catch(Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    return;
                }

                return;
            }
            return;
        }

        public TempHeader(System.IO.StreamReader TotalTemp)
        {
            ReadTotalTempHeader(TotalTemp);
        }

        public TempHeader()
        {
            ScenIdPos = -1;
            VarNamePos = -1;
            ValuePos = -1;
        }

        public int GetScenIdPos()
        {
            return ScenIdPos;
        }

        public int GetVarNamePos()
        {
            return VarNamePos;
        }

        public int GetValuePos()
        {
            return ValuePos;
        }
    }
}

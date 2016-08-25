using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analytics_visual
{
    public class Factory
    {
        private static Factory instance;
        public Dictionary<string, Base> plugin_dictionary = new Dictionary<string, Base>();
        private Factory()
        {
            RegisterAnalyticObjects();
        }
        void RegisterAnalyticObjects()
        {
            plugin_dictionary.Add("Firstvalue", (new FirstValue()));
            plugin_dictionary.Add("Lastvalue", (new LastValue()));
            plugin_dictionary.Add("Minvalue", (new MinValue()));
            plugin_dictionary.Add("Maxvalue", (new MaxValue()));
            plugin_dictionary.Add("Average", (new Average()));
        }

        public static Factory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Factory();
                }

                return instance;
            }
        }
    }
}

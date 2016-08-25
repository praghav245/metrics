using Microsoft.VisualStudio.TestTools.UnitTesting;
using analytics_visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analytics_visual.Tests
{
    [TestClass()]
    public class ConfigurationTests
    {
        [TestMethod()]
        public void ConfigurationTest()
        {
            Configuration config = new Configuration();
            Assert.AreEqual(null, config.GetPeriod());
            Assert.AreEqual(null, config.GetStatistic());
            Assert.AreEqual(null, config.GetVarName());
        }

        [TestMethod()]
        public void ConfigurationTest1()
        {
            Configuration config = new Configuration("cashPrem","Average","Minvalue");
            Assert.AreEqual("Minvalue", config.GetPeriod());
            Assert.AreEqual("Average", config.GetStatistic());
            Assert.AreEqual("cashPrem", config.GetVarName());
        }

        [TestMethod()]
        public void CalculatePeriodTest()
        {
            Factory statistics_factory = Factory.Instance;
            Configuration config = new Configuration("cashPrem", "Average", "");
            config.CalculatePeriod(statistics_factory, null, null);
        }

        [TestMethod()]
        public void CalculateStatisticTest()
        {
            Factory statistics_factory = Factory.Instance;
            Configuration config = new Configuration("cashPrem", "", "Lastvalue");
            config.CalculateStatistic(statistics_factory);
        }

        [TestMethod()]
        public void CalculateStatisticTestWithNullValues()
        {
            Factory statistics_factory = Factory.Instance;
            Configuration config = new Configuration("cashPrem", "Average", "Lastvalue");
            config.CalculateStatistic(statistics_factory);
        }

    }
}
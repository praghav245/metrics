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
    public class MaxValueTests
    {
        [TestMethod()]
        public void calculateTestEmptyList()
        {
            MaxValue value = new MaxValue();
            List<double> list_values = new List<double>();
            Assert.AreEqual(0, value.calculate(list_values));
        }

        [TestMethod()]
        public void calculateTestWithValuesinList()
        {
            MaxValue value = new MaxValue();
            List<double> list_values = new List<double>();
            list_values.Add(10.2);
            list_values.Add(20.2);
            list_values.Add(30.2);
            Assert.AreEqual(30.2, value.calculate(list_values));
        }

        [TestMethod()]
        public void calculateTestEmptystringArray()
        {
            MaxValue value = new MaxValue();
            string[] values = new string[10];
            Assert.AreEqual(0, value.calculate(values, 2));
        }

        [TestMethod()]
        public void calculateTestWithValuesinStringArray()
        {
            MaxValue value = new MaxValue();
            string[] values = new string[2];
            values[0] = "10.2";
            values[1] = "SceneId";
            Assert.AreEqual(10.2, value.calculate(values, 0));
        }

        [TestMethod()]
        public void calculateTestWithValuesinStringArrayWithNegativePos()
        {
            MaxValue value = new MaxValue();
            string[] values = new string[2];
            values[0] = "sceneId";
            values[1] = "10.2";
            Assert.AreEqual(0, value.calculate(values, -1));
        }

        [TestMethod()]
        public void calculateTestWithValuesinStringArrayWithPosOutOfRange()
        {
            MaxValue value = new MaxValue();
            string[] values = new string[2];
            values[0] = "sceneId";
            values[1] = "10.2";
            Assert.AreEqual(0, value.calculate(values, 3));
        }

        [TestMethod()]
        public void calculateTestWithCorrectValuesinStringArray()
        {
            MaxValue value = new MaxValue();
            string[] values = new string[3];
            values[0] = "sceneId";
            values[1] = "10.2";
            values[1] = "20.2";
            Assert.AreEqual(20.2, value.calculate(values, 1));
        }
    }
}
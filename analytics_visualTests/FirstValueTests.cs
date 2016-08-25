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
    public class FirstValueTests
    {
        [TestMethod()]
        public void calculateTestEmptyList()
        {
            FirstValue value = new FirstValue();
            List<double> list_values = new List<double>();
            Assert.AreEqual(0, value.calculate(list_values));
        }

        [TestMethod()]
        public void calculateTestWithValuesinList()
        {
            FirstValue value = new FirstValue();
            List<double> list_values = new List<double>();
            list_values.Add(10.2);
            list_values.Add(20.2);
            list_values.Add(30.2);
            Assert.AreEqual(10.2, value.calculate(list_values));
        }

        [TestMethod()]
        public void calculateTestEmptystringArray()
        {
            FirstValue value = new FirstValue();
            string[] values = new string[10];
            Assert.AreEqual(0, value.calculate(values, 2));
        }

        [TestMethod()]
        public void calculateTestWithValuesinStringArray()
        {
            FirstValue value = new FirstValue();
            string[] values = new string[2];
            values[0] = "sceneId";
            values[1] = "10.2";
            Assert.AreEqual(0, value.calculate(values, 0));
        }

        [TestMethod()]
        public void calculateTestWithValuesinStringArrayWithNegativePos()
        {
            FirstValue value = new FirstValue();
            string[] values = new string[2];
            values[0] = "sceneId";
            values[1] = "10.2";
            Assert.AreEqual(0, value.calculate(values, -1));
        }

        [TestMethod()]
        public void calculateTestWithValuesinStringArrayWithPosOutOfRange()
        {
            FirstValue value = new FirstValue();
            string[] values = new string[2];
            values[0] = "sceneId";
            values[1] = "10.2";
            Assert.AreEqual(0, value.calculate(values, -1));
        }

        [TestMethod()]
        public void calculateTestWithCorrectValuesinStringArray()
        {
            FirstValue value = new FirstValue();
            string[] values = new string[2];
            values[0] = "sceneId";
            values[1] = "10.2";
            Assert.AreEqual(10.2, value.calculate(values, 1));
        }

    }
}
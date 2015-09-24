using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using calc;


namespace calcTests
{
    [TestClass]
    public class calcOps
    {
        [TestMethod]
        public void AdditionTest()
        {
            AddIt testAdd = new AddIt();
            int answer = testAdd.Addition(5, 5);
            Assert.AreEqual(answer, 10);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            SubtractIt testSubtract = new SubtractIt();
            int answer = testSubtract.Subtraction(5, 5);
            Assert.AreEqual(answer, 0);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            MultiplyIt testMulti = new MultiplyIt();
            int answer = testMulti.Multiplication(5, 5);
            Assert.AreEqual(answer, 25);
        }

        [TestMethod]
        public void DivisionTest()
        {
            DivideIt testDiv = new DivideIt();
            int answer = testDiv.Division(5, 5);
            Assert.AreEqual(answer, 1);
        }

        [TestMethod]
        public void ModulusTest()
        {
            ModIt testMod = new ModIt();
            int answer = testMod.Modulation(5, 4);
            Assert.AreEqual(answer, 1);
        }
    }
}

using System;
using System.IO;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using calc;


namespace calcTests
{
    [TestClass]
    public class calcOps
    {
        //[TestMethod]
        //public void AdditionTest()
        //{
            //AddIt testAdd = new AddIt();
            //int answer = testAdd.Addition(5, 5);
            //Assert.AreEqual(answer, 10);
        //}

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

        [TestMethod]
        public void extractsNumsTest()
        {
            string input = "3 + 4";
            RegexUtil processor = new RegexUtil();
            ArrayList answer = processor.ExtractNums(input);
            ArrayList expected = new ArrayList();
            expected.Add(3);
            expected.Add(4);
            CollectionAssert.AreEqual(expected, answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void doesNotTakeBadInput()
        {
            string input = "3 +";
            RegexUtil processor = new RegexUtil();
            ArrayList answer = processor.ExtractNums(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotTakeBadInput2()
        {
            string input = "+ 24 5";
            RegexUtil processor = new RegexUtil();
            ArrayList answer = processor.ExtractNums(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotTakeNoOpPresent()
        {
            string input = "24";
            RegexUtil process = new RegexUtil();
            ArrayList answer = process.ExtractNums(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotTakeAlphabet()
        {
            string input = "abc + def";
            RegexUtil process = new RegexUtil();
            ArrayList answer = process.ExtractNums(input);
        }

        [TestMethod]
        public void ExtractsAddOperand()
        {
            string input = "3 + 4";
            RegexUtil adding = new RegexUtil();
            string answer = adding.ExtractsOp(input);
            string expected = "+";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void ExtractsSubOperand()
        {
            string input = "10 - 2";
            RegexUtil subtracting = new RegexUtil();
            string answer = subtracting.ExtractsOp(input);
            string expected = "-";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void ExtractsDivOperandTest()
        {
            string input = "10 / 2";
            RegexUtil dividing = new RegexUtil();
            string answer = dividing.ExtractsOp(input);
            string expected = "/";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void ExtractsMultiOperand()
        {
            string input = "10 * 2";
            RegexUtil multiplying = new RegexUtil();
            string answer = multiplying.ExtractsOp(input);
            string expected = "*";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void ExtractsModOperand()
        {
            string input = "10 % 2";
            RegexUtil modulusing = new RegexUtil();
            string answer = modulusing.ExtractsOp(input);
            string expected = "%";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void QuitProcessed()
        {
            ValidInputs TestQuit = new ValidInputs();
            bool answer = TestQuit.BreakingLoop("quit");
            Assert.AreEqual(false, answer);
        }

        [TestMethod]
        public void ExitProcessed()
        {
            ValidInputs TestExit = new ValidInputs();
            bool answer = TestExit.BreakingLoop("exit");
            Assert.AreEqual(false, answer);
        }

        // valid input takes anything that isn't an exit
        // if it is an improper input, RegexUtil will handle this
        [TestMethod]
        public void ValidInputRec4Regex()
        {
            string input = "3 + 4";
            ValidInputs TestRegexPass = new ValidInputs();
            bool answer = TestRegexPass.BreakingLoop(input);
            Assert.AreEqual(true, answer);
        }
    }
}
